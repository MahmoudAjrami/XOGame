# ❌⭕ XO Game - Tic-Tac-Toe

A simple and interactive **Tic-Tac-Toe desktop game** built using **Windows Forms**.  
The game allows two players to play against each other on the same computer, with automatic turn switching, winner detection, draw detection, and restart functionality.

---

## 📌 About the Project

**XO Game** is a desktop application designed to practice Windows Forms development, event-driven programming, game logic, and basic UI interaction.

The project implements the classic Tic-Tac-Toe game where two players take turns selecting cells. The application checks all possible winning combinations and updates the game status automatically.

---

## ✨ Features

- 🎮 Two-player gameplay
- ❌ Player 1 uses X
- ⭕ Player 2 uses O
- 🔁 Automatic turn switching
- 🏆 Winner detection
- 🤝 Draw detection
- 📊 Game status tracking
- 🟢 Highlights the winning line
- 🔄 Restart game button
- 🖼️ Uses image resources for X, O, and empty cells
- 🧩 Custom Tic-Tac-Toe grid drawn on the form

---

## 🖥️ Application Screens

The application interface includes:

- Game title
- Player turn indicator
- Winner/status label
- 3x3 Tic-Tac-Toe board
- Restart Game button

---

## 🧠 Game Logic

The game checks the winner by validating all possible winning combinations:

- Rows
- Columns
- Diagonals

When a player wins, the winning buttons are highlighted and the game displays the winner.  
If all 9 cells are filled without a winner, the game ends as a draw.

---

## 🛠️ Technologies Used

- Windows Forms
- .NET Framework
- Visual Studio
- Event-driven programming

---

## 📂 Project Structure

```text
XOGame/
│
├── Images/                 # Game images and assets
├── Properties/             # Project properties and resources
├── Resources/              # Resource files
├── res/                    # Additional resources
├── Form1.cs                # Main game logic
├── Form1.Designer.cs       # Windows Forms UI design
├── Form1.resx              # Form resources
├── Program.cs              # Application entry point
├── App.config              # App configuration
├── XO-Game-Final.csproj    # Project file
└── XO-Game-Final.sln       # Visual Studio solution
