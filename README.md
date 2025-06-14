<h1 align="center">📚 Bilingual Library Management System</h1>
<p align="center">
  <b>Console-based C# Library System</b> supporting both <b>English</b> and <b>Arabic</b> with animated ASCII art, right-to-left Arabic rendering, book borrowing/returning, file persistence, and more.
</p>

<p align="center">
  <img src="https://img.shields.io/badge/Language-C%23-239120?style=for-the-badge&logo=csharp&logoColor=white"/>
  <img src="https://img.shields.io/badge/Console-App-informational?style=for-the-badge"/>
  <img src="https://img.shields.io/badge/RTL-Arabic%20Support-blueviolet?style=for-the-badge"/>
</p>

---

## 🚀 Features

- 🌐 **Dual Language UI**: Full Arabic (RTL) and English language support
- 📖 **Borrow/Return Books**: Interactive book lending system
- 💾 **Persistent Storage**: Save and load borrowed books per user in `borrowed.txt`
- 🧠 **Search Function**: Search for books by title (partial match)
- 🎨 **ASCII Art Animation**: Custom intro animation using C# console art
- 🔐 **Simple Authentication**: Login system using usernames & passwords
- 🧼 **Clean UX**: Color-coded console output with clear prompts and RTL Arabic rendering

---

## 🛠️ Technologies Used

- **C# (.NET)**
- **System.IO** for file operations
- **Console** manipulation for:
  - Colored text output
  - Cursor positioning
  - Custom animation effects
- **Thread.Sleep** for animation timing
- **Right-To-Left rendering** using character reversal (`Reverse(string)`)

---

## 🧪 How to Run

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/bilingual-library.git
   cd bilingual-library
   ```

2. Open the project in **Visual Studio** or any C# IDE.

3. Build and run the project.

4. Create a user account via login prompt and start borrowing books!

---

## 📂 File Structure

```text
📁 Project Root
├── Program.cs           // Main logic file (provided)
├── borrowed.txt         // Stores borrowed books per user
├── README.md            // This file
```

---

## 📌 Sample Functionalities

- ✅ Borrow Arabic or English books
- ✅ Return specific borrowed books
- ✅ Save/load borrowing sessions by user credentials
- ✅ Display all available books with dynamic indexing
- ✅ Typing animations with dots and delays
- ✅ Animated banner: **EL3OMANY**

---

> 🔤 Reverse Arabic strings in code using `Reverse(string)` for correct display in console.

---

## 🔮 Future Ideas

- 🧑‍🤝‍🧑 Multi-user login system with roles (admin, student)
- 🖥 GUI version using Windows Forms or WPF
- 🌐 Save borrowed books to online database (Firebase, MongoDB)
- 📈 Usage statistics or borrowing history per user

---

## 🙌 Author

**Mahmoud Hesham** — "EL3OMANY" 🔥  
A bilingual C# wizard who blends design and logic like magic.  
[GitHub Profile](https://github.com/EL3oMaNy) • [LinkedIn](https://www.linkedin.com/in/mahmoud-hesham-7b6a97354/) 

---

## 📄 License

This software is for educational purposes only.
Use, share, or modify freely with credit. Not for commercial use.

---

## 🧠 Final Word

> “Programming is not just about code… It’s about **storytelling** in logic.  
> This project tells a **bilingual tale** of creativity, culture, and code.” 🌍📘💻
