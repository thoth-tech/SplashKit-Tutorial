# Creating a 2D "Metroidvania" Game - Project Structure and Initialization
## The Essentials of Project Structure and Initialization for a Metroidvania Game
Creating a 2D Metroidvania game involves not just creativity and vision, but also a well-organized project structure and a solid initialization process. This tutorial will guide you through setting up the basic structure of a Metroidvania game project and initializing its core components.

## Project Structure: Organizing Your Game's Framework
A well-organized project structure is crucial for efficient game development. It helps in maintaining the code, assets, and other resources in an orderly manner. Here’s a basic structure you can follow:

### Code and Assets Directories:
- **Source Code(e.g., .cpp/.h files)**: Contains the game’s main codebase, including scripts for gameplay, UI, and game mechanics.
![Source Example](images/src.jpg)
- **Assets (e.g. fonts, images, sounds)**: A broad directory that includes all game assets such as sprites, audio files, textures, and scripts. It's often organized into subdirectories for better management.
![Assets Example](images/assets.jpg)

### Library and External Dependencies:
- **Libraries (e.g., Slashkit)**: This directory houses external libraries or frameworks your game uses, such as physics engines, rendering tools, or AI systems.
![Libraries Example](images/lib.jpg)

### Configuration and Build Scripts:
- **Build Configurations (e.g., 'builds' or 'bin')**: Contains compiled game builds or scripts for building the game on various platforms.
![Build Example](images/bin.jpg)
- **Configuration Files**: These may include settings for game engines, development tools, or project-specific configurations.
![Configuration Example](images/config.jpg)

### Documentation:
- Holds files related to game design documentation, mechanics explanations, and development notes.
![Documentation Example](images/doc.jpg)

## Game Initialization: Laying the Foundation
Initializing your Metroidvania game involves setting up the game window, loading assets, and preparing the game loop. Here's how to start:

### 1.Creating the Game Window:
- The first step in initializing your game is to open a window where your game will be rendered. Determine the size and title of your window based on your game's requirements.

    'open_window("Metroidvania Adventure", 800, 600);'

### 2.Loading Assets:
- Set up important game variables such as player health, score counters, or game state flags.

    ```
    bitmap hero_sprite = load_bitmap("hero", "assets/images/hero.png");
    music background_music = load_music("adventure_theme", "assets/sounds/theme.mp3");
    ```

### 3.Initializing Game Variables:
- Set up important game variables such as player health, score counters, or game state flags.

    ```
    int player_health = 100;
    int score = 0;
    bool game_over = false; 
    ```

### 4.Game Loop:
- The game loop is where the magic happens. It continuously updates game states and renders the graphics on the screen until the game is exited.
    ```
    while (!window_close_requested("Metroidvania Adventure"))
    {
        rocess_events();
        update_game();
        draw_game();
    }
    ```

## Ready to Start Your Adventure
With the project structure set and the game initialization in place, you're ready to dive deeper into the development of your Metroidvania game. Remember, the way you structure and initialize your game can significantly impact the development process and the final quality of your game.

Next steps include detailed character design, level creation, and implementing game mechanics that make Metroidvania games unique and engaging.