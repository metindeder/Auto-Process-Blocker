using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;
using System.Security.Principal;

namespace AutoProcessBlocker
{
    public partial class Form1 : Form
    {
        private string bannedListFile = "banned_programs.txt";
        private NotifyIcon trayIcon;
        private CancellationTokenSource cts;

        private int totalClosed = 0;
        private long totalMemorySavedKB = 0;

        public Form1()
        {
            InitializeComponent();
        }

        

      
        private void Form1_Load(object sender, EventArgs e)
        {
          
            SetupTray();
            LoadBannedListOnStart();
            StartMonitoring();
            chkstartup.Checked = IsStartupEnabled();
        }

        #region Tray ve Bildirim

        private void SetupTray()
        {
            trayIcon = new NotifyIcon();

            // Gömülü icon kullanımı
            var assembly = Assembly.GetExecutingAssembly();
            string resourceName = "AutoProcessBlocker.notify.ico";
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream != null)
                {
                    trayIcon.Icon = new Icon(stream);
                }
                else
                {
                    trayIcon.Icon = SystemIcons.Application;
                    MessageBox.Show("Resource bulunamadı: " + resourceName);
                   
                    string[] resources = assembly.GetManifestResourceNames();
                    string all = string.Join("\n", resources);
                    MessageBox.Show(all);
                }
            }

            trayIcon.Visible = true;
            trayIcon.Text = "Auto Process Blocker  - Çalışıyor";

            trayIcon.ContextMenuStrip = new ContextMenuStrip();
            trayIcon.ContextMenuStrip.Items.Add("Çıkış", null, (s, e) =>
            {
                StopMonitoring();
                trayIcon.Visible = false;
                Application.Exit();
            });

            this.Resize += (s, e) =>
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.Hide();
                    trayIcon.ShowBalloonTip(1000, "Auto Process Blocker", "Arka planda çalışıyor.", ToolTipIcon.Info);
                }
            };

            trayIcon.DoubleClick += (s, e) =>
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            };
        }

        private void ShowNotification(string message)
        {
            if (trayIcon != null)
            {
                trayIcon.ShowBalloonTip(1500, "Auto Process Blocker", message, ToolTipIcon.Info);
            }
        }

        #endregion

        #region Log

        private void AddLog(string message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => AddLog(message)));
            }
            else
            {
                string timeStamp = DateTime.Now.ToString("HH:mm:ss");
                lstLog.Items.Add($"[{timeStamp}] {message}");
                lstLog.TopIndex = lstLog.Items.Count - 1;
            }
        }

        #endregion

        #region Yasaklı Liste Yönetimi

        private void LoadBannedListOnStart()
        {
            if (File.Exists(bannedListFile))
            {
                var lines = File.ReadAllLines(bannedListFile);
                lstBannedPrograms.Items.Clear();
                lstBannedPrograms.Items.AddRange(lines);
                AddLog("Yasaklı program listesi yüklendi.");
            }
            else
            {
                AddLog("Yasaklı program listesi bulunamadı.");
            }
        }

        private void LoadBannedList()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Metin Dosyaları (*.txt)|*.txt|JSON Dosyaları (*.json)|*.json|Tüm Dosyalar (*.*)|*.*";
                openFileDialog.Title = "Yasaklı program listesini seç";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var lines = File.ReadAllLines(openFileDialog.FileName);
                        lstBannedPrograms.Items.Clear();
                        lstBannedPrograms.Items.AddRange(lines);
                        AddLog($"Liste yüklendi: {Path.GetFileName(openFileDialog.FileName)}");
                        MessageBox.Show("Liste başarıyla yüklendi.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Dosya okunurken hata oluştu: " + ex.Message);
                        AddLog("Yükleme hatası: " + ex.Message);
                    }
                }
            }
        }

        private void SaveBannedList()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Metin Dosyaları (*.txt)|*.txt|JSON Dosyaları (*.json)|*.json|Tüm Dosyalar (*.*)|*.*";
                saveFileDialog.Title = "Yasaklı program listesini kaydet";
                saveFileDialog.FileName = "banned_programs.txt"; // Varsayılan dosya adı

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.WriteAllLines(saveFileDialog.FileName, lstBannedPrograms.Items.Cast<string>());
                        AddLog($"Liste kaydedildi: {Path.GetFileName(saveFileDialog.FileName)}");
                        MessageBox.Show("Liste başarıyla kaydedildi.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Kaydetme hatası: " + ex.Message);
                        AddLog("Kaydetme hatası: " + ex.Message);
                    }
                }
            }
        }

        #endregion

        #region Program İzleme & Kapatma

        private void StartMonitoring()
        {
            cts = new CancellationTokenSource();

            Task.Run(() =>
            {
                while (!cts.Token.IsCancellationRequested)
                {
                    foreach (string bannedExe in lstBannedPrograms.Items)
                    {
                        string procName = System.IO.Path.GetFileNameWithoutExtension(bannedExe).ToLower();
                        var processes = Process.GetProcessesByName(procName);
                        foreach (var proc in processes)
                        {
                            try
                            {
                                long memUsageKB = proc.WorkingSet64 / 1024;
                                proc.Kill();

                                totalClosed++;
                                totalMemorySavedKB += memUsageKB;

                                this.Invoke((MethodInvoker)delegate
                                {
                                    lblStats.Text = $"Kapatılan: {totalClosed} - RAM Tasarrufu: {totalMemorySavedKB / 1024} MB";
                                    ShowNotification($"{bannedExe} kapatıldı.");
                                    System.Media.SystemSounds.Beep.Play();
                                    AddLog($"{bannedExe} kapatıldı, {memUsageKB / 1024} MB RAM tasarrufu.");
                                });
                            }
                            catch (Exception ex)
                            {
                                this.Invoke((MethodInvoker)delegate
                                {
                                    AddLog($"Hata: {ex.Message}");
                                });
                            }
                        }
                    }
                    Thread.Sleep(2000);
                }
            });
        }

        private void StopMonitoring()
        {
            cts?.Cancel();
        }

        #endregion

        #region Başlangıçta Otomatik Çalıştırma

        private void SetStartup(bool enable)
        {
            string runKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
            using (var startupKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(runKey, true))
            {
                if (enable)
                {
                    startupKey.SetValue("AutoProcessBlocker", Application.ExecutablePath);
                }
                else
                {
                    startupKey.DeleteValue("AutoProcessBlocker", false);
                }
            }
        }

        private bool IsStartupEnabled()
        {
            string runKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
            using (var startupKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(runKey, false))
            {
                if (startupKey == null) return false;
                var val = startupKey.GetValue("AutoProcessBlocker") as string;
                return !string.IsNullOrEmpty(val) && val == Application.ExecutablePath;
            }
        }

        private void chkStartup_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                SetStartup(chkstartup.Checked);
                AddLog("Başlangıçta otomatik çalışma " + (chkstartup.Checked ? "aktif" : "pasif") + " edildi.");
            }
            catch (Exception ex)
            {
                AddLog("Başlangıç ayarı değiştirilemedi: " + ex.Message);
            }
        }

        #endregion

        #region Button Click Events

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Kapatılacak programın EXE adını yazın (örn: notepad.exe)", "Program Ekle", "");
            if (!string.IsNullOrWhiteSpace(input))
            {
                if (!lstBannedPrograms.Items.Contains(input))
                {
                    lstBannedPrograms.Items.Add(input);
                    AddLog($"Program eklendi: {input}");
                }
                else
                {
                    MessageBox.Show("Program zaten listede.");
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstBannedPrograms.SelectedItem != null)
            {
                string removed = lstBannedPrograms.SelectedItem.ToString();
                lstBannedPrograms.Items.Remove(lstBannedPrograms.SelectedItem);
                AddLog($"Program silindi: {removed}");
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadBannedList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveBannedList();
        }

        #endregion
    }
}
