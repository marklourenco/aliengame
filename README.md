# Space Explorer

**Space Explorer** is a console-based space exploration game written in C#. In the game, you control a spaceship that navigates through the galaxy, collecting resources, avoiding or battling aliens, and trying to reach Venus at the coordinates (5, 5).

The game involves resource management (fuel and cargo), spaceship combat with aliens, and strategy for navigating through a randomly populated galaxy. The objective is to reach Venus while managing the spaceship's fuel and avoiding or defeating hostile alien entities.

## Features

- **Spaceship movement**: Navigate the galaxy using commands like `move up`, `move down`, etc.
- **Resource collection**: Collect various resources like `Ancient Artifacts` and `Space Minerals` to fill your cargo hold.
- **Alien encounters**: Battle against various alien species like `Martians`, `Zogarians`, and `Space Pirates` that attack the spaceship.
- **Spaceship damage**: Your spaceship has shields that can be damaged by alien attacks.
- **Fuel management**: The spaceship consumes fuel as it moves around the galaxy. If the spaceship runs out of fuel, the game ends.
- **Game objectives**: The primary objective is to reach Venus at coordinates (5, 5) while managing your spaceship's resources.
- **Game over**: If your spaceship is destroyed or you run out of fuel, the game ends.

## Gameplay

1. **Start a New Game**:
   Upon running the game, the spaceship starts at coordinates (0, 0) with limited fuel, shield strength, and cargo space. Your goal is to navigate the galaxy to reach Venus (5, 5).

2. **Navigating the Galaxy**:
   Use the command `move <direction>` to navigate the galaxy. Directions can be: `up`, `down`, `left`, `right`. Every move consumes 1 unit of fuel. You must manage your fuel efficiently to avoid running out.

3. **Collecting Resources**:
   When you land on a tile with resources (e.g., `Ancient Artifacts` or `Space Minerals`), use the `collect <resource>` command to collect them. Resources fill your cargo hold. If the cargo hold is full, you cannot collect more resources until space is available.

4. **Alien Encounters**:
   Aliens are scattered across the galaxy. If you land on a tile with aliens, they may attack your spaceship. If the spaceship survives, the aliens are destroyed. The combat system reduces the spaceship's shield strength based on alien attack power.

5. **Victory Condition**:
   You win the game when you reach the coordinates (5, 5) (Venus). 

6. **Game Over**:
   If your spaceship runs out of fuel or is destroyed by aliens, the game ends.

## Commands

Here are the primary commands you can use in the game:

- **Movement**: 
  - `move <direction>` (e.g., `move up`, `move down`, `move left`, `move right`)
  
- **Resource Collection**:
  - `collect <resource>` (e.g., `collect space minerals`, `collect ancient artifacts`)

- **Quit the Game**:
  - `quit` – Ends the game and stops the spaceship from moving.

## Game Setup

### Classes Overview

- **`Entity`**: The base class for all entities (like aliens) that have health. It allows them to take damage and check if they are still alive.
- **`Spaceship`**: Represents the player's spaceship. The spaceship has fuel, shields, cargo capacity, and the ability to move, collect resources, and take damage from aliens.
- **`Alien`**: Represents alien entities that can attack the spaceship. Each alien has a name, health, and attack power.
- **`Resource`**: Represents resources that can be collected by the spaceship, such as `Ancient Artifacts` and `Space Minerals`.
- **`Galaxy`**: Represents the galaxy. It contains a grid of locations, where each location may have aliens and/or resources.
- **`Game`**: The main game logic. It manages the galaxy, the spaceship, encounters with aliens, and the collection of resources.
- **`Program`**: The entry point of the game, which runs the game loop.

### Game Flow

1. **Initialization**:
   The game starts by creating a `Galaxy` with a predefined size (10x10 grid), where aliens and resources are placed randomly.

2. **Spaceship Setup**:
   The spaceship starts with a given amount of fuel, shield strength, and cargo capacity at the origin coordinates (0, 0).

3. **User Input**:
   The player can give commands to move the spaceship, collect resources, or quit the game.

4. **Alien Encounters**:
   When the spaceship moves to a location with aliens, the game handles combat by reducing the spaceship's shield strength based on the alien's attack power.

5. **Victory/Defeat**:
   If the spaceship reaches (5, 5), the player wins. If the spaceship runs out of fuel or is destroyed, the game ends.

## Example Gameplay

```
You are at coordinates (0, 0).
Fuel: 20 | Shield: 100 | Cargo: 0/50
Enter a command (move <direction>, collect <resource>, or quit):

move up
You are now at coordinates (0, 1).

Fuel: 19 | Shield: 100 | Cargo: 0/50
There are Space Minerals here. Would you like to collect them? (yes/no)

collect space minerals
You collected 10 Space Minerals.

Fuel: 19 | Shield: 100 | Cargo: 10/50
Enter a command (move <direction>, collect <resource>, or quit):

move right
You are now at coordinates (1, 1).

Fuel: 18 | Shield: 100 | Cargo: 10/50
A Martian attacks your spaceship!
Your spaceship takes 10 damage. Shield: 90
After the shootout, the Martian was destroyed.

Enter a command (move <direction>, collect <resource>, or quit):
```
![aliengame gif](https://github.com/user-attachments/assets/fec13a1d-5e1d-4ec1-addf-9662c8ebf118)

## How to Run the Game

1. Clone the repository:

   ```bash
   git clone https://github.com/marklourenco/space-explorer.git
   ```

2. Open the project in your preferred C# IDE (e.g., Visual Studio, Visual Studio Code).

3. Build and run the application:
   - In Visual Studio, press `Ctrl+F5` to run the game without debugging.
   - Or use the terminal with the following command:
     ```bash
     dotnet run
     ```

4. Follow the on-screen instructions to play the game.

## License

This project is open source and available under the MIT License. See the [LICENSE](LICENSE) file for more details.

---

### Notes:

- Replace `yourusername` with your actual GitHub username in the repository URL.
- Feel free to enhance the game with more features, such as adding more types of aliens, resources, or even a quest system!
