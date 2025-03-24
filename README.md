# Knock It Down Game 🎯⚾💥

## About the Game ⚾🎮
This project is a simple yet fun physics-based game developed using **Unity** and **C#**. The goal of the game is to launch a ball toward a set of tin cans and knock them down. The player taps the screen to determine the direction of the ball and releases it to shoot. If the ball hits the cans, they fall due to physics interactions. The game currently operates in an endless loop and is still under development.

## Gameplay Mechanics 🕹️
- The game starts with a main menu screen where the player can press the Start button to begin.
- The ball initially remains stationary in the center of the screen. After the player launches the ball, a new ball enters from the left and moves to the right in an animated manner.
- The player taps the screen to set the direction and shoot the ball.
- The ball is launched in the chosen direction, and if it hits the cans, they fall.
- After each shot, a new ball appears and moves across the screen in an animated way.
- The game runs in an endless loop, meaning that even if all cans fall, balls continue to be launched.

## Planned Features 🚀
- **Level system**: Progression to the next level after knocking down a certain number of cans.
- **Scoring system**: Awarding points based on the number of cans knocked down.
- **Difficulty variations**: Introducing more cans or different layouts.
- **Sound effects and visual improvements**.

## Technical Details 🛠️
This game utilizes the following components:
- **Unity Engine** (Game development platform)
- **C#** (For game mechanics and animation control)
- **Rigidbody and Collider** (For physics-based collisions and movement)
- **Animator** (For ball entry animations)

## Code Overview 📂
- **Ball.cs**: Manages the ball’s movement, repositioning, and shooting mechanics.
- **Can.cs**: Controls the falling mechanics of the cans.
- **GameManager.cs**: Oversees the core gameplay logic.
- **UIManager.cs**: Manages the game’s user interface.

## Knock It Down Game - Live Demo 🎮

https://github.com/user-attachments/assets/9ea07e7a-688d-4aef-a3cd-2e230316f399

## Screenshots 📸

![1](https://github.com/user-attachments/assets/d7bd49e2-3fa1-4df0-b848-be8425cbabf6)

![2](https://github.com/user-attachments/assets/122ff707-1da3-4994-a7d7-6fccba33f5f6)

## Acknowledgment
This project was inspired by the UGuruz YouTube channel’s Unity Game Tutorial for Beginners - Knock IT Down video. Special thanks to them for their valuable content! 🎯
