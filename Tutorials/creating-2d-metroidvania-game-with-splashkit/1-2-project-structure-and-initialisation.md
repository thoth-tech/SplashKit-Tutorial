---
title: "Creating a 2D Metroidvania in Splashkit: Project Structure and Initialisation"
sidebar: 
   label: " - 1.2: Project Structure and Initialisation"
---

<!-- TODO: Edit this to remove overlap with part 2, and be more of a getting the files ready. Should also use the updated Splashkit format (see Part 2 in programmers.guide for C++ and Part 1 for C# if needed late) -->

## Introduction

This tutorial builds upon the foundational concepts presented in the "Basic Drawing and Graphics Tutorial" by Coskun Kilinc. Here, we dive deeper into setting up a structured and efficient project for a 2D "Metroidvania" game using SplashKit, focusing on both project organization and initial game setup.

## Extending the Basic Drawing and Graphics Tutorial

Before proceeding, ensure you are familiar with the basics covered in the [Basic Drawing and Graphics Tutorial](https://github.com/thoth-tech/SplashKit-Tutorial/blob/main/Tutorials/Creating%20a%202D%20Metroidvania%20Game%20Using%20Splashkit/2.%20Basic%20Drawing%20and%20Graphics.md). It provides essential knowledge on setting up a game window and basic drawing functions in SplashKit.

## Project Structure: Organizing Your Game's Framework

A well-organized project structure is crucial for efficient game development. It helps in maintaining the code, assets, and other resources in an orderly manner. Here’s a basic structure you can follow:

### Code and Assets Directories

- **Source Code(e.g., .cpp/.h files)**: Contains the game’s main codebase, including scripts for gameplay, UI, and game mechanics.
- **Resources (e.g. fonts, images, sounds)**: A broad directory that includes all game assets such as sprites, audio files, textures, and scripts. It's often organized into subdirectories for better management.

### Library and External Dependencies

- **Libraries (e.g., SplashKit)**: Here, you'll store external libraries or frameworks your game uses, such as SplashKit. It's in a folder named 'lib', standard in SplashKit projects.

### Configuration and Build Scripts

- **Build Configurations (e.g., 'bin')**: This section holds compiled game builds or scripts for various platforms. SplashKit usually creates a 'bin' folder for this purpose.
- **Configuration Files**: The .vscode hidden folder contains the common configuration files for IDE settings and project-specific configurations.

### Documentation

- Holds files related to game design documentation, mechanics explanations, and development notes.

## Utilizing SplashKit's New Project Structure

When you start a new project with SplashKit, the generated structure serves as a solid foundation for your game development. It's essential to understand and utilize this structure effectively.

### Setting Up Your Project

1. **Create a New SplashKit Project**: Navigate to the desired location and create a new directory for your project (`mkdir my_metroidvania_game`). Then, enter your project directory (`cd my_metroidvania_game`) and initialize a SplashKit C++ project (`skm new c++`). You'll see include/SplashKit and **program.cpp** in your project directory.

    ![Example of Create a New SplashKit Project1](./images/new-project-1.jpg)

2. **Adding Necessary Folders**: In the **my_metroidvania_game** directory, create the following folders:

    - **src**: To store your source code files.
    - **Resources**: Use `skm resources` command in the terminal in the base folder to set up this directory.
    - **lib**: To store third-party library files (if you plan to use any).

3. **Organizing Initial Files**: Move the **program.cpp** file to **src** directory. Create and edit your source code files (.cpp and .h) in the src folder. You can start writing the logic of the game, such as character control, game interface, and the game loop.

    ![Example of Create a New SplashKit Project2](./images/new-project-2-with-resources.jpg)

## Game Initialisation: Laying the Foundation

Initializing your Metroidvania game involves setting up the game window, loading assets, and preparing the game loop. Here's how to start:

### 1.Creating the Game Window

- The first step in initializing your game is to open a window where your game will be rendered. Determine the size and title of your window based on your game's requirements.

    ```cpp
    open_window("Metroidvania Adventure", 800, 600);
    ```

### 2.Loading Assets

- Set up important game variables such as player health, score counters, or game state flags.

    ```cpp
    bitmap hero_sprite = load_bitmap("hero", "resources/images/hero.png");
    music background_music = load_music("adventure_theme", "resources/sounds/theme.mp3");
    ```

### 3.Initializing Game Variables

- Set up important game variables such as player health, score counters, or game state flags.

    ```cpp
    int player_health = 100;
    int score = 0;
    bool game_over = false; 
    ```

### 4.Game Loop

- The `update_game` function might include code for player movement, collision detection, enemy updates, and other game mechanics.
- The `draw_game` function is responsible for drawing everything on the screen. This includes the player, enemies, backgrounds, UI elements like health bars, etc.
- Then put it all together in the game loop. Make sure to define all necessary variables and load your assets before the game loop starts. Here is an example.

```cpp
    void update_game()
    {
    // Update player position, handle input, etc.
    // For example, if the player is moving right
    // player.x += player_speed;

    // Collision detection
    // if (collision between player and enemy)
    // {
    //     player_health -= damage;
    // }

    // Update enemies, power-ups, etc.

    // Check game over conditions
    // if (player_health <= 0)
    // {
    //     game_over = true;
    // }
    }

    void draw_game()
    {
    clear_screen(COLOR_WHITE); // Clear the screen to a background color

    // Draw the player
    // draw_bitmap(hero_sprite, player.x, player.y);

    // Draw enemies, items, etc.

    // Draw UI elements
    // draw_text("Health: " + std::to_string(player_health), COLOR_BLACK, 10, 10);

    refresh_screen(); // Refresh the screen to show the updated drawings
    }

    while (!window_close_requested("Metroidvania Adventure"))
    {
        process_events(); // Process user input and other events
        update_game(); // Update game state
        draw_game(); // Draw the game to the screen
    }
```

## Ready to Start Your Adventure

Conclusion
With a structured project and solid Initialisation, you are now ready to delve deeper into the development of your Metroidvania game. Remember, the way you structure and initialize your game can significantly impact the development process and the final quality of your game.

Refer to the [Basic Drawing and Graphics Tutorial](https://github.com/thoth-tech/SplashKit-Tutorial/blob/main/Tutorials/Creating%20a%202D%20Metroidvania%20Game%20Using%20Splashkit/2.%20Basic%20Drawing%20and%20Graphics.md) for foundational knowledge. The next steps include detailed character design, level creation, and implementing unique game mechanics.
