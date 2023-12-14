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
```
## Organizing Your Resources

With the development environment set up, the next step is to gather and organize the resources for your Mario-like game. These resources include sprite sheets for characters and environments, sound effects, and background music.

### Prepare Resource Folders

Inside your project directory (e.g., `MarioGame`), create folders to keep your resources organized:

- `images/` for all your graphics like sprite sheets and backgrounds.
- `sounds/` for your audio files such as sound effects and music.

```bash
MarioGame/
├── images/
└── sounds/
```
## Character Movement: Controlling with Keyboard Input

In this section, we'll learn how to control a character's movement using keyboard inputs. This is a crucial aspect of many games, especially platformers like our Mario-like game.

### Understanding the Basics

To control character movement, we need to understand how SplashKit handles keyboard input. SplashKit offers functions to check if certain keys are pressed, which we can use to move our character.

### Implementing Basic Movement

1. **Setting Up Movement Variables**: 
   Start by defining variables to control the position and speed of your character.

    ```cpp
    float x = 0;
    float y = 0;
    float speed = 5; // Adjust speed as needed
    ```

2. **Handling Keyboard Input**:
   In the game loop, check for keyboard inputs and adjust the character's position accordingly.

    ```cpp
    void update_player(float &x, float &y, float speed)
    {
        if (key_down(LEFT_KEY))
        {
            x -= speed;
        }
        if (key_down(RIGHT_KEY))
        {
            x += speed;
        }
        if (key_down(UP_KEY))
        {
            y -= speed;
        }
        if (key_down(DOWN_KEY))
        {
            y += speed;
        }
    }
    ```

3. **Updating the Game Loop**:
   Call `update_player` inside your game loop to continuously update the character's position based on keyboard input.

    ```cpp
    int main()
    {
        // Initialization code...

        while (!window_close_requested())
        {
            process_events();
            clear_screen(COLOR_WHITE);
            
            update_player(x, y, speed);
            
            // Drawing code...

            refresh_screen();
        }
        return 0;
    }
    ```

4. **Drawing the Character**:
   Use SplashKit's drawing functions to render the character at its current position.

    ```cpp
    draw_bitmap("character", x, y);
    ```

    Ensure you have a bitmap named "character" loaded in your resources.

### Testing Movement

Run your program and test the character movement using the arrow keys. The character should move in the direction of the pressed key.

### Next Steps

- **Improving Movement**: Further enhancements can include adding animation, limiting movement within the game window, and implementing gravity for a platformer feel.
- **Advanced Techniques**: Explore more complex movement patterns or add functionalities like jumping and crouching.

In the next section, we'll look into adding collision detection to our game.

## Collision Detection: Implementing Character and Object Interactions

Collision detection is a fundamental aspect of game development. It determines how characters interact with other objects in the game world, such as platforms, enemies, and collectibles. In this section, we’ll cover how to implement basic collision detection for your Mario-like game using SplashKit.

### Understanding Collision Detection

Collision detection in games involves determining when two objects in the game space, such as the player character and a platform, occupy the same space. This is crucial for creating realistic and responsive gameplay.

### Implementing Basic Collision Detection

1. **Defining Collision Boundaries**:
   For simple collision detection, we define rectangular boundaries around objects.

    ```cpp
    // Example of a simple rectangle structure for collision detection
    struct rectangle
    {
        float x;
        float y;
        float width;
        float height;
    };
    ```

2. **Collision Function**:
   Create a function to check if two rectangles (representing game objects) overlap.

    ```cpp
    bool rectangles_intersect(rectangle rect1, rectangle rect2)
    {
        // Check if there is no overlap
        if (rect1.x + rect1.width < rect2.x || rect2.x + rect2.width < rect1.x ||
            rect1.y + rect1.height < rect2.y || rect2.y + rect2.height < rect1.y)
        {
            return false;
        }
        return true;
    }
    ```

3. **Applying Collision Detection**:
   In your game loop, use this function to check for collisions.

    ```cpp
    // Example of using the collision function
    if (rectangles_intersect(player_rect, enemy_rect))
    {
        // Handle collision (e.g., reduce player health)
    }
    ```

### Testing Collision Detection

To test, create a simple scenario where your character collides with another object. Adjust the positions of the rectangles to simulate movement and observe if the collision is detected as expected.

### Advanced Collision Detection

- **Complex Shapes**: For more complex shapes, consider using polygons or pixel-perfect collision detection.
- **Efficiency**: Implement spatial partitioning or quad-trees for more efficient collision detection in larger game worlds.

## Sprite Animation: Creating Character and Enemy Animations

Animating sprites is an essential part of game development, adding life and dynamism to your characters and enemies. In this section, we'll go through how to create animations for the characters in your Mario-like game using SplashKit.

### Basics of Sprite Animation

Sprite animation involves changing the image (or frame) displayed for a character or object over time to create the illusion of movement.

### Implementing Sprite Animation

1. **Setting Up Animation Frames**:
   Prepare your sprite sheet with different frames for each animation (e.g., walking, jumping).

    ```cpp
    // Load your sprite sheet into the program
    bitmap sprite_sheet = load_bitmap("character_sprite_sheet", "character_sprites.png");
    ```

2. **Creating an Animation**:
   Define an animation using the frames from your sprite sheet.

    ```cpp
    // Define a new animation
    animation_script character_animation = new_animation_script();
    animation character_walk = create_animation(sprite_sheet, "walk");

    // Add frames to your animation
    add_frame(character_walk, bitmap_cell(0, 0), 0.1); // Adjust frame duration as needed
    add_frame(character_walk, bitmap_cell(1, 0), 0.1);
    // Continue adding frames...

    // Add the animation to the script
    add_animation(character_animation, character_walk);
    ```

3. **Updating Animation**:
   In your game loop, update and draw the animation.

    ```cpp
    int main()
    {
        // Initialization code...

        while (!window_close_requested())
        {
            process_events();
            clear_screen(COLOR_WHITE);

            // Update animation
            update_animation(character_animation);

            // Draw the current frame of the animation
            draw_bitmap_part(sprite_sheet, current_animation_frame(character_animation), x, y);
            
            refresh_screen();
        }
        return 0;
    }
    ```

### Testing Your Animations

Run your program to see the character animation in action. Adjust the frame durations and sequence to achieve the desired effect.

### Next Steps

- **Multiple Animations**: Implement different animations for various actions like jumping, running, or idle.
- **Smooth Transitions**: Work on transitioning smoothly between different animations based on player actions.

## Interactive Gameplay Elements: Adding Collectibles, Power-Ups, and Enemies

Interactive elements like collectibles, power-ups, and enemies are crucial for making games more engaging and fun. In this part of the tutorial, we will learn how to add these elements to your Mario-like game using SplashKit.

### Adding Collectible Items

Collectibles can be anything from coins to special items that players can collect throughout the game.

1. **Creating a Collectible**:
   Define a structure or class for your collectibles, including their properties like position and sprite.

    ```cpp
    struct collectible
    {
        float x, y;
        bitmap sprite;
        bool collected;
    };

    // Initialize a collectible
    collectible coin = {100, 100, load_bitmap("coin", "coin.png"), false};
    ```

2. **Displaying Collectibles**:
   Draw the collectibles on the screen if they are not collected.

    ```cpp
    void draw_collectible(const collectible &item)
    {
        if (!item.collected)
        {
            draw_bitmap(item.sprite, item.x, item.y);
        }
    }
    ```

### Adding Power-Ups

Power-ups can enhance the player's abilities temporarily.

1. **Power-Up Mechanics**:
   Implement the effects of the power-up (e.g., increased speed or invincibility).

    ```cpp
    void apply_power_up(player &hero, const power_up &boost)
    {
        // Implement the effect of the power-up on the player
        // For example, increase speed, jump height, etc.
    }
    ```

### Adding Enemies

Enemies challenge the player and add excitement to the game.

1. **Creating an Enemy**:
   Define an enemy with properties like position, movement pattern, and sprite.

    ```cpp
    struct enemy
    {
        float x, y;
        bitmap sprite;
        // Other properties such as movement pattern
    };

    // Initialize an enemy
    enemy goomba = {200, 200, load_bitmap("goomba", "goomba.png")};
    ```

2. **Enemy Behavior**:
   Implement the logic for enemy movement and interaction with the player.

    ```cpp
    void update_enemy(enemy &foe)
    {
        // Logic for enemy movement and player interaction
        // For example, moving left and right, detecting player collision, etc.
    }
    ```

### Testing the Gameplay Elements

Test your game by adding various collectibles, power-ups, and enemies. Ensure that interactions like collecting items and encountering enemies work as expected.

### Next Steps

- **Expand the Variety**: Add different types of collectibles, power-ups, and enemies.
- **Level Design**: Strategically place these elements in your levels to balance challenge and fun.

In the next section, we will focus on implementing a scoring system to track the player's progress.
## Scoring System: Implementing a Mechanism to Track and Display Player Progress

A scoring system is crucial in many games, providing feedback on player performance and progress. Let's implement a basic scoring system for our game.

### Setting Up the Score

First, define a variable to track the player's score:

```cpp
int score = 0;

void update_score(int &score, int points)
{
    score += points;
}

void draw_score(const int &score)
{
    draw_text("Score: " + to_string(score), COLOR_BLACK, "font", 20, 10, 10);
}
```
Integrating the Score System
Incorporate the scoring mechanism into your game's main loop:
```cpp
int main()
{
    // Initialization code...

    while (!window_close_requested())
    {
        process_events();
        clear_screen(COLOR_WHITE);
        
        // Update game elements...
        update_score(score, points); // Adjust 'points' based on game events
        draw_score(score);

        refresh_screen();
    }
    return 0;
}
```
## Audio Integration: Enhancing Gameplay with Sound

Adding audio to your game, including background music and sound effects, significantly enhances the gaming experience. In this section, we'll discuss how to integrate audio into your Mario-like game using SplashKit.

### Setting Up Audio in SplashKit

SplashKit makes it easy to add audio to your games. Here’s how to get started:

1. **Loading Audio Files**:
   First, load your sound effects and music files into the game.

    ```cpp
    sound_effect jump_sound = load_sound_effect("jump", "jump.wav");
    music background_music = load_music("background", "background.mp3");
    ```

2. **Playing Sound Effects**:
   Play sound effects in response to certain actions, like jumping or collecting items.

    ```cpp
    void play_jump_sound()
    {
        play_sound_effect(jump_sound);
    }
    ```

3. **Playing Background Music**:
   Set up background music to play throughout the game.

    ```cpp
    play_music(background_music, -1, 0.5); // -1 for looping, 0.5 for volume
    ```

### Integrating Audio into the Game Loop

Incorporate the audio controls into your game loop and event handling.

1. **Triggering Sound Effects**:
   Call your sound effect functions at appropriate times in the game logic.

    ```cpp
    if (key_typed(SPACE_KEY))
    {
        play_jump_sound();
    }
    ```

2. **Managing Music Playback**:
   Ensure that the background music is playing as long as the game is running.

    ```cpp
    if (!music_playing())
    {
        play_music(background_music, -1, 0.5);
    }
    ```

### Testing Your Game Audio

Run your game and check if the sound effects and music play correctly in response to player actions and game events.

### Next Steps

- **Audio Feedback for Actions**: Add different sounds for various game events like collecting coins, enemy encounters, and level completion.
- **Dynamic Music**: Experiment with changing the background music based on game levels or player health.

## Level Design: Creating Multiple Levels with Increasing Difficulty

Creating multiple levels with varying challenges is key to keeping your game interesting and engaging. In this section, we'll discuss how to design and implement multiple levels in your Mario-like game using SplashKit.

### Basic Level Structure

Start by defining what makes up a level in your game, such as the layout, enemies, and collectibles.

1. **Designing a Level**:
   Each level should have a unique layout and set of challenges.

    ```cpp
    struct level
    {
        vector<enemy> enemies;
        vector<collectible> collectibles;
        // Additional level-specific elements
    };
    ```

2. **Creating Different Levels**:
   Design several levels with increasing complexity and difficulty.

    ```cpp
    level level1 = create_level1();
    level level2 = create_level2();
    // Add more levels as needed
    ```

### Implementing Level Progression

Manage how the player progresses through these levels.

1. **Level Completion Criteria**:
   Set conditions for completing a level, such as reaching a specific point or collecting all items.

    ```cpp
    bool is_level_complete(const level &lvl)
    {
        // Define your criteria for level completion
        // For example, check if all collectibles are collected
    }
    ```

2. **Advancing to Next Level**:
   Once a level is completed, transition the player to the next level.

    ```cpp
    void advance_to_next_level(int &current_level)
    {
        current_level++;
        // Load the next level
    }
    ```

### Testing Multiple Levels

Test your game by playing through each level, ensuring the difficulty increases and the transitions between levels are smooth.

### Next Steps

- **Varied Level Design**: Experiment with different themes and layouts for each level.
- **Dynamic Difficulty Adjustment**: Implement mechanisms to adjust the difficulty based on the player’s performance.

## Concluding the Game: Adding a Final Boss and Ending Sequence

A memorable ending is essential for a satisfying gaming experience. This can involve a final boss battle, concluding the game's story, or an ending sequence. In this section, we'll explore how to add a concluding part to your Mario-like game using SplashKit.

### Creating a Final Boss

The final boss is typically the most challenging enemy, testing all the skills the player has learned.

1. **Designing the Boss**:
   Create a unique and challenging final boss with special abilities.

    ```cpp
    struct boss
    {
        float x, y;
        bitmap sprite;
        int health;
        // Boss-specific abilities and behavior
    };

    boss final_boss = { /* Initialize boss properties */ };
    ```

2. **Boss Battle Mechanics**:
   Implement the logic for the boss battle, including attack patterns and player interactions.

    ```cpp
    void update_final_boss(boss &final_boss)
    {
        // Logic for boss movement, attacks, and interactions with the player
    }
    ```

### Ending Sequence

After defeating the final boss, provide a satisfying conclusion to the game.

1. **Displaying the Ending**:
   Show an ending sequence or screen to wrap up the game's story.

    ```cpp
    void display_ending()
    {
        // Display the ending sequence or message
        draw_text("Congratulations! Game Completed!", COLOR_GREEN, "font", 24, 100, 100);
    }
    ```

2. **Game Completion Logic**:
   Trigger the ending sequence after the final boss is defeated.

    ```cpp
    if (final_boss_defeated)
    {
        display_ending();
    }
    ```

### Testing the Game Conclusion

Play through the final part of your game, ensuring that the boss battle is challenging and the ending sequence properly concludes the story.

### Next Steps

- **Multiple Endings**: Consider adding different endings based on player choices or achievements.
- **Replay Value**: Add elements to encourage replaying the game, such as new challenges or unlockables.

With this, we conclude our tutorial on creating a Mario-like game using SplashKit. Happy game developing!




