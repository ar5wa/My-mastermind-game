#Mastermind Console Game

A simple and fun console-based implementation of the classic **Mastermind** game built in **C#**.
---
##Game Concept
- The secret code consists of **4 distinct digits** from **0 to 8**.
- You have **10 attempts** (by default) to guess the code.
- After each guess, you'll receive:
  - **Well placed pieces** — correct digit in the correct position.
  - **Misplaced pieces** — correct digit but in the wrong position.
- If the code is guessed correctly, you win!
- If you reach the attempt limit, the game ends and reveals the code.
- The game handles **Ctrl+D** (EOF) gracefully as an exit.
  ---

 ## How to Run
 You need [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) or later.
 ### Run the game:
 ```bash
dotnet run
