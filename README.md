<div align="left" style="position: relative;">
<img src="https://images.icon-icons.com/4191/PNG/512/dartboard_focus_bullseye_marketing_arrow_business_target_icon_262501.png" align="right" width="30%" style="margin: -20px 0 0 20px;">
<h1>🛡️ AUTO PROCESS BLOCKER</h1>
<p align="left">
	<em><code>❯ A lightweight Windows utility that automatically blocks and terminates selected processes as soon as they start — helping you save RAM and keep your system clean.</code></em>
</p>
<p align="left">
	<img src="https://img.shields.io/github/license/metindeder/Auto-Process-Blocker?style=default&logo=opensourceinitiative&logoColor=white&color=0080ff" alt="license">
	<img src="https://img.shields.io/github/last-commit/metindeder/Auto-Process-Blocker?style=default&logo=git&logoColor=white&color=0080ff" alt="last-commit">
	<img src="https://img.shields.io/github/languages/top/metindeder/Auto-Process-Blocker?style=default&color=0080ff" alt="repo-top-language">
	<img src="https://img.shields.io/github/languages/count/metindeder/Auto-Process-Blocker?style=default&color=0080ff" alt="repo-language-count">
</p>
<p align="left"><!-- default option, no dependency badges. -->
</p>
<p align="left">
	<!-- default option, no dependency badges. -->
</p>
</div>
<br clear="right">

## 🔗 Table of Contents

- [📍 Overview](#-overview)
- [👾 Features](#-features)
- [📸 Screenshots](#-screenshots)
- [📁 Project Structure](#-project-structure)
- [🚀 Getting Started](#-getting-started)
  - [☑️ Prerequisites](#-prerequisites)
  - [⚙️ Installation](#-installation)
  - [🤖 Usage](#🤖-usage)
  - [🧪 Testing](#🧪-testing)
- [📌 Project Roadmap](#-project-roadmap)
- [🔰 Contributing](#-contributing)
- [🎗 License](#-license)
- [🙌 Acknowledgments](#-acknowledgments)

---

## 📍 Overview

**Auto Process Blocker** is a Windows-based utility developed in C# that monitors system processes in real time and **automatically terminates specific applications** as soon as they are launched.

Whether you're trying to reduce RAM usage, block unwanted background services, or prevent certain programs from opening — this tool provides a simple and effective solution.

No bloated interfaces, no extra features — just fast, silent, and customizable process blocking.

---

✅ **Key Highlights:**
- Real-time background monitoring
- Customizable blocklist via `config.txt`
- Requires admin privileges only once
- Boosts system performance
- Can optionally run at system startup

🎯 Ideal for:
- Gamers
- Developers
- IT admins
- Low-spec system users

---

## 👾 Features

Here’s what makes **Auto Process Blocker** powerful, flexible, and developer-friendly:

- 🔍 **Real-Time Monitoring**  
  Continuously scans active processes and reacts instantly.

- ❌ **Automatic Process Termination**  
  Instantly closes any process listed in `config.txt` upon detection.

- 🧾 **Customizable Blocklist (config.txt)**  
  Add or remove blocked process names easily using a plain text file.

- 💾 **Dynamic Config Management**  
  The app can read from and write to `config.txt` at runtime — allowing users to update the blocklist from the UI (if available) or programmatically.

- 📄 **Logging System (log.txt)**  
  Every block event is recorded with a timestamp, so you can review what was terminated and when.

- 🖥️ **Silent Background Operation**  
  Works silently in the tray or hidden without interrupting the user.

- 🔐 **One-Time Admin Privilege Prompt**  
  Requests administrator access only once; remembers for future launches.

- 🚀 **Startup Integration (Optional)**  
  Add the app to Windows startup using Task Scheduler or included `.reg` file.

- 🛠️ **Built with C# / .NET Framework**  
  Clean, fast, and reliable on all modern Windows systems.
---

## 📸 Screenshots

<img src="https://github.com/metindeder/Auto-Process-Blocker/blob/main/Screenshots/main.png" width="80%">
<img src="https://github.com/metindeder/Auto-Process-Blocker/blob/main/Screenshots/save-banned-programs.png" width="80%">
  

## 📁 Project Structure

```sh
└── Auto-Process-Blocker/
    ├── Auto Process Blocker
    │   ├── AutoProcessBlocker
    │   ├── AutoProcessBlocker.sln
    │   └── packages
    ├── LICENSE
    └── README.md
```



---
## 🚀 Getting Started

### ☑️ Prerequisites

Before building or running **Auto-Process-Blocker**, ensure your environment meets the following requirements:

- **OS:** Windows 10 or higher (x64)
- **IDE:** Visual Studio 2019 or newer
- **.NET Framework:** 4.7.2 or higher
- **Package Manager:** NuGet (built-in to Visual Studio)

---

### ⚙️ Installation

**Build from source:**

1. Clone the repository:

```sh
git clone https://github.com/metindeder/Auto-Process-Blocker.git
```

2.Open the solution file in Visual Studio::
```sh
❯ Auto-Process-Blocker.sln
```

3.Restore NuGet packages:


**Using `nuget`** &nbsp; [<img align="center"  src="https://store-images.s-microsoft.com/image/apps.37039.9007199266443154.b59c81b2-f4d0-4d4f-894a-62a177a2de87.d7425233-8c42-4268-8426-d28fbf82102c" height="50" width="50"/>]()

```sh
❯ Tools → NuGet Package Manager → Restore NuGet Packages
```




### 🤖 Usage
Build the solution:
**Using `visual studio 2022`** &nbsp; [<img align="center" src="https://upload.wikimedia.org/wikipedia/commons/thumb/2/2c/Visual_Studio_Icon_2022.svg/2048px-Visual_Studio_Icon_2022.svg.png" width="10%" />]()

```sh
❯ Build → Build Solution 
```
After building:

Run the application from Visual Studio (with Admin privileges)

Or navigate to the output folder and launch:

```sh
/bin/Debug/AutoProcessBlocker.exe
```

⚠️ Make sure config.txt is in the same directory as the executable.

### 🧪 Testing

Manual testing can be done by:

Adding known app names (e.g., notepad.exe) into config.txt

Running the app as Administrator

Launching one of the blocked apps to verify it is auto-closed

Checking log.txt for timestamped block entries


---
## 📌 Project Roadmap

- [X] **`Task 1`**: <strike> Real-time process blocker core.</strike>
- [X] **`Task 2`**: <strike>Config file support (read/write).</strike>
- [X] **`Task 3`**:  <strike>Logging to log..</strike>
- [X] **`Task 4`**:  <strike>System tray icon integration.</strike>
- [ ] **`Task 5`**: Basic GUI panel for config/logs.
- [ ] **`Task 6`**:  Multilingual support.

---

## 🔰 Contributing

- **💬 [Join the Discussions](https://github.com/metindeder/Auto-Process-Blocker/discussions)**: Share your insights, provide feedback, or ask questions.
- **🐛 [Report Issues](https://github.com/metindeder/Auto-Process-Blocker/issues)**: Submit bugs found or log feature requests for the `Auto-Process-Blocker` project.
- **💡 [Submit Pull Requests](https://github.com/metindeder/Auto-Process-Blocker/blob/main/CONTRIBUTING.md)**: Review open PRs, and submit your own PRs.

<details closed>
<summary>Contributing Guidelines</summary>

1. **Fork the Repository**: Start by forking the project repository to your github account.
2. **Clone Locally**: Clone the forked repository to your local machine using a git client.
   ```sh
   git clone https://github.com/metindeder/Auto-Process-Blocker/
   ```
3. **Create a New Branch**: Always work on a new branch, giving it a descriptive name.
   ```sh
   git checkout -b new-feature-x
   ```
4. **Make Your Changes**: Develop and test your changes locally.
5. **Commit Your Changes**: Commit with a clear message describing your updates.
   ```sh
   git commit -m 'Implemented new feature x.'
   ```
6. **Push to github**: Push the changes to your forked repository.
   ```sh
   git push origin new-feature-x
   ```
7. **Submit a Pull Request**: Create a PR against the original project repository. Clearly describe the changes and their motivations.
8. **Review**: Once your PR is reviewed and approved, it will be merged into the main branch. Congratulations on your contribution!
</details>

<details closed>
<summary>Contributor Graph</summary>
<br>
<p align="left">
   <a href="https://github.com{/metindeder/Auto-Process-Blocker/}graphs/contributors">
      <img src="https://contrib.rocks/image?repo=metindeder/Auto-Process-Blocker">
   </a>
</p>
</details>

---

## 🎗 License

This project is protected under the [MIT License](https://opensource.org/license/mit) License. For more details, refer to the [LICENSE](https://opensource.org/license/mit) file.

---

## 🙌 Acknowledgments

Special thanks to the following resources and individuals who inspired or supported the development of this project:

- 🧠 **Microsoft Docs** — For detailed .NET and Windows API documentation  
  https://learn.microsoft.com/en-us/dotnet/

- 🛠️ **Process Hacker** — Inspiration on how system-level process management can be handled  
  https://processhacker.sourceforge.io/

- 🤝 **Contributors & Testers** — Everyone who tested the app, gave feedback, or contributed code

- 🎥 **@metindeder** — Project lead & development
  https://www.youtube.com/@metindeder

> If you’d like to be added to the acknowledgments list, feel free to open a PR or discussion!

 ---
