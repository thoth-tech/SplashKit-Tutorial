# Mario-Like Game Tutorial Using SplashKit

## Introduction

Welcome to the Mario-Like Game Tutorial using SplashKit! This guide is designed to help you create your own platformer game inspired by the classic Mario series. Throughout this tutorial, we'll dive into the fundamentals of game design and development using the SplashKit toolkit, covering everything from movement mechanics to level design.

By the end of this tutorial, you'll have a solid foundation in game development with SplashKit, as well as a playable Mario-like game that you've built from scratch. Get ready to jump into the world of game development and bring your creative ideas to life!

Next, we'll set up our development environment to start crafting our game.
## Setting Up Your Development Environment

Before diving into the coding, it's essential to set up a development environment that will allow you to write, test, and run your SplashKit game efficiently. Here's how you can get everything up and running on your machine.

### Step 1: Install SplashKit

SplashKit SDK provides all the tools you need to create your game. Depending on your operating system (Windows, macOS, Linux), the installation steps may differ. Here's how you can install SplashKit:

#### For Windows:

1. Download and install MSYS2 from [here](https://www.msys2.org/).
2. Use the MSYS2 terminal to install SplashKit by running:

    ```bash
    bash <(curl -s https://raw.githubusercontent.com/splashkit/skm/master/install-scripts/skm-install.sh)
    ```

#### For macOS:

1. Open the Terminal application.
2. Install Xcode Command Line Tools by running:

    ```bash
    xcode-select --install
    ```

3. Once the command line tools are installed, install SplashKit with the following command:

    ```bash
    bash <(curl -s https://raw.githubusercontent.com/splashkit/skm/master/install-scripts/skm-install.sh)
    ```
## Creating the Project Framework

Now that our development environment is set up, let's start by creating the basic framework for our Mario-like game. This will involve setting up the project structure and preparing the necessary resources.

### Step 1: Create a New SplashKit Project

1. Open Visual Studio Code.
2. Create a new folder for your project, e.g., `MarioGame`.
3. Inside this folder, create a new file named `main.cpp`.

### Step 2: Initialize the Basic Game Structure

In your `main.cpp` file, write the basic code structure:

```cpp
#include "splashkit.h"

int main()
{
    // Create a new window
    open_window("Mario-Like Game", 800, 600);

    // Game loop
    while (!window_close_requested())
    {
        // Update the game
        process_events();
        clear_screen(COLOR_WHITE);
        
        // TODO: Game logic goes here

        refresh_screen();
    }
    return 0;
}




