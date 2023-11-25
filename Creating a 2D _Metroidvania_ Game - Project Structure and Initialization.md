# Creating a 2D "Metroidvania" Game - Project Structure and Initialization
## Introduction
This tutorial builds upon the foundational concepts presented in the "Basic Drawing and Graphics Tutorial" by Coskun Kilinc. Here, we dive deeper into setting up a structured and efficient project for a 2D "Metroidvania" game using SplashKit, focusing on both project organization and initial game setup.

## Extending the Basic Drawing and Graphics Tutorial
Before proceeding, ensure you are familiar with the basics covered in the [Basic Drawing and Graphics Tutorial](https://github.com/thoth-tech/SplashKit-Tutorial/blob/main/Tutorials/Creating%20a%202D%20Metroidvania%20Game%20Using%20Splashkit/2.%20Basic%20Drawing%20and%20Graphics.md). It provides essential knowledge on setting up a game window and basic drawing functions in SplashKit.

## Project Structure: Organizing Your Game's Framework
A well-organized project structure is crucial for efficient game development. It helps in maintaining the code, assets, and other resources in an orderly manner. Here’s a basic structure you can follow:

### Code and Assets Directories:
- **Source Code(e.g., .cpp/.h files)**: Contains the game’s main codebase, including scripts for gameplay, UI, and game mechanics.
- **Assets (e.g. fonts, images, sounds)**: A broad directory that includes all game assets such as sprites, audio files, textures, and scripts. It's often organized into subdirectories for better management.

### Library and External Dependencies:
- **Libraries (e.g., SlashKit)**: This directory houses external libraries or frameworks your game uses, such as physics engines, rendering tools, or AI systems.

### Configuration and Build Scripts:
- **Build Configurations (e.g., 'builds' or 'bin')**: Contains compiled game builds or scripts for building the game on various platforms.
- **Configuration Files**: These may include settings for game engines, development tools, or project-specific configurations.

### Documentation:
- Holds files related to game design documentation, mechanics explanations, and development notes.

## Utilizing SplashKit's New Project Structure
When you start a new project with SplashKit, the generated structure serves as a solid foundation for your game development. It's essential to understand and utilize this structure effectively.

### Setting Up Your Project
1. **Create a New SplashKit Project**: Use the SplashKit command to generate a new project.

Create a new directory for your project `mkdir my_metroidvania_game`. 
Then enter your project directory `cd my_metroidvania_game`.
Create a SplashKit C++ project `skm new c++`.
Now you can see include/SplashKit and program.cpp have been created in the project directory.
![Example of Create a New SplashKit Project1](images/Create%20a%20New%20SplashKit%20Project1.jpg)

2. **Adding Necessary Folders**: In the **my_metroidvania_game** directory, create the following folders:
- **src**: To store your source code files.
- **Resources**: To store game assets such as images, sounds, and fonts.
- **lib**: To store third-party library files (if you plan to use any).

3. **Moving and Organizing Initial Files**: Move the **program.cpp** file to **src** directory. Create and edit your source code files (.cpp and .h) in the src folder. You can start writing the logic of the game, such as character control, game interface, and the game loop.
![Example of Create a New SplashKit Project2](images/Create%20a%20New%20SplashKit%20Project2.jpg)

## Game Initialization: Laying the Foundation
Initializing your Metroidvania game involves setting up the game window, loading assets, and preparing the game loop. Here's how to start:

### 1.Creating the Game Window:
- The first step in initializing your game is to open a window where your game will be rendered. Determine the size and title of your window based on your game's requirements.

    `open_window("Metroidvania Adventure", 800, 600);`

### 2.Loading Assets:
- Set up important game variables such as player health, score counters, or game state flags.

    ```cpp
    bitmap hero_sprite = load_bitmap("hero", "assets/images/hero.png");
    music background_music = load_music("adventure_theme", "assets/sounds/theme.mp3");
    ```

### 3.Initializing Game Variables:
- Set up important game variables such as player health, score counters, or game state flags.

    ```cpp
    int player_health = 100;
    int score = 0;
    bool game_over = false; 
    ```

### 4.Game Loop:
- The game loop is where the magic happens. It continuously updates game states and renders the graphics on the screen until the game is exited.
    ```cpp
    while (!window_close_requested("Metroidvania Adventure"))
    {
        process_events();
        update_game();
        draw_game();
    }
    ```

## Ready to Start Your Adventure
Conclusion
With a structured project and solid initialization, you are now ready to delve deeper into the development of your Metroidvania game. Remember, the way you structure and initialize your game can significantly impact the development process and the final quality of your game.

Refer to the [Basic Drawing and Graphics Tutorial](https://github.com/thoth-tech/SplashKit-Tutorial/blob/main/Tutorials/Creating%20a%202D%20Metroidvania%20Game%20Using%20Splashkit/2.%20Basic%20Drawing%20and%20Graphics.md) for foundational knowledge. The next steps include detailed character design, level creation, and implementing unique game mechanics.
