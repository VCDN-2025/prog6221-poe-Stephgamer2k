# 🤖 WPF Cybersecurity Chatbot with NLP and Task Manager

This project is a desktop chatbot application built using C# and Windows Presentation Foundation (WPF). It simulates intelligent user interaction in the context of cybersecurity education and task management. The chatbot interprets flexible, natural language commands to add tasks, set reminders, and perform actions using basic NLP simulation techniques such as keyword recognition and string manipulation.

The goal of this project is to help users engage with cybersecurity-related activities in a conversational way while managing personal tasks and reminders through a graphical user interface. All interactions are logged and viewable in a separate activity log window, providing users with a clear summary of recent actions. The chatbot supports structured conversation flow, state management, sound greetings, dynamic user prompts, and context-aware responses.

This build serves both as a learning tool and a demonstration of integrating core software development skills: GUI design, state handling, event-driven logic, regex-based input parsing, and persistent user interaction logging. It was developed as part of the INSY6211 curriculum to demonstrate practical implementation of theoretical concepts from systems analysis and human-computer interaction.

---

## 🚀 Features

### 💬 Chatbot Core
- Text-based chatbot built in WPF
- Greets user with sound and custom welcome screen
- Interprets commands and responds to cybersecurity-related prompts

### 🧠 NLP Simulation
- Detects intent using flexible user phrasing like:
  - "Remind me to update my password"
  - "Add a task to enable 2FA"
  - "Set a reminder for tomorrow"
- Handles slight variations using `Regex` and `string.Contains()`

### 📋 Task Creation & Reminders
- Chatbot allows user to:
  - Add a task
  - Describe the task
  - Set a reminder (supports "in 3 days", "tomorrow", or full dates like `2025-07-01`)
- Task information is passed to a task manager window (if present)

### 📜 Activity Log (GUI)
- Logs every significant user action:
  - Task added
  - Reminder set
  - NLP interpretation
  - Quiz attempts (if implemented)
- Shows last 5–10 actions in a scrollable `LogWindow`
- Entries include timestamp and description

### 🖥️ Clean WPF GUI
- Built-in ASCII logo and welcome animation
- Uses `ListView` to display chatbot messages and activity logs
- `ObservableCollection<Output>` for UI binding

---

## 🛠️ Technologies

- C# .NET (WPF)
- Regex-based NLP
- ObservableCollection for UI updates
- XAML for interface design


---

## ✅ How to Use

1. Run the application
2. The build shows four buttons that give access to the Chatbot system, View added tasks, play the quiz game, and  The Log window
3. Click the button to the feature you want to access. Close the window to go back to the main window.
4. In the chatbot system you can type commands like:
   - `Add a task to install antivirus`
   - `Set a reminder to check settings tomorrow`
   - `What have you done for me?`
5. In the quiz game You will be prompted questions. You can answer and submit them with a button and textbox
6. Once you have added tasks through the chatbot system you can view them through the view task button on the main window
7. As you use the build you can view the history of activites that happened through the log window button on the main window.


---


