---
title: "Enemy Sprites and Movement"
description:
Learn how to create new combat animations, handle animations and use collision detection.
author: Georgie O'Malley
date: 4/12/2023
tags: game development, programming, Splashkit, functions
---

# Tutorial 8.2: Combat Mechanics

This tutorial involves creating combat animations, handling animations and using collision detection.

This tutorial builds on the following code until previous tutorials are completed.

```cpp
#include "splashkit.h"
#include <vector>
#include <cstdlib>
using std::vector;

struct platform_data
{
    rectangle rectangle;
    color color;
};

struct enemy_data
{
    sprite enemy_sprite;
    double enemy_speed;
    bool move_right;
    int min_path;
    int max_path;
};

void handle_animations(animation player_animation)
{
    if (key_typed(LEFT_KEY)) assign_animation(player_animation, "WalkLeft");
    if (key_typed(RIGHT_KEY)) assign_animation(player_animation, "WalkRight");


    if (!key_down(LEFT_KEY) and !key_down(RIGHT_KEY))
    {
        if (key_released(LEFT_KEY)) assign_animation(player_animation, "StandLeft");
        if (key_released(RIGHT_KEY)) assign_animation(player_animation, "StandRight");
    }
}

vector<platform_data> create_platforms()
{
    vector<platform_data> result;
    platform_data platform;

    // Ground platform
    platform.rectangle = rectangle_from(0,580,800,20);
    platform.color = COLOR_BLACK;
    result.push_back(platform);

    // Air platforms
    platform.rectangle = rectangle_from(50,460,200,18);
    platform.color = COLOR_RED;
    result.push_back(platform);

    platform.rectangle = rectangle_from(550,460,200,18);
    platform.color = COLOR_RED;
    result.push_back(platform);

    platform.rectangle = rectangle_from(300,330,200,18);
    platform.color = COLOR_GREEN;
    result.push_back(platform);

    platform.rectangle = rectangle_from(50,180,200,18);
    platform.color = COLOR_BLUE;
    result.push_back(platform);

    platform.rectangle = rectangle_from(550,180,200,18);
    platform.color = COLOR_BLUE;
    result.push_back(platform);

    return result;
}

vector<enemy_data> create_enemies(bitmap enemy_bitmap, animation_script enemy_script)
{
    vector<enemy_data> result;
    enemy_data enemy;

    // Ground enemy
    enemy.enemy_sprite = create_sprite(enemy_bitmap, enemy_script);
    sprite_set_x(enemy.enemy_sprite, 0);
    sprite_set_y(enemy.enemy_sprite, 558);
    enemy.enemy_speed = 1;
    enemy.move_right = false;
    enemy.min_path = 0;
    enemy.max_path = 800;
    result.push_back(enemy);

    // // Air platform enemies
    enemy.enemy_sprite = create_sprite(enemy_bitmap, enemy_script);
    sprite_set_x(enemy.enemy_sprite, 50);
    sprite_set_y(enemy.enemy_sprite, 438);
    enemy.enemy_speed = 1;
    enemy.move_right = false;
    enemy.min_path = 50;
    enemy.max_path = 250;
    result.push_back(enemy);

    enemy.enemy_sprite = create_sprite(enemy_bitmap, enemy_script);
    sprite_set_x(enemy.enemy_sprite, 550);
    sprite_set_y(enemy.enemy_sprite, 438);
    enemy.enemy_speed = 1;
    enemy.move_right = false;
    enemy.min_path = 550;
    enemy.max_path = 750;
    result.push_back(enemy);

    enemy.enemy_sprite = create_sprite(enemy_bitmap, enemy_script);
    sprite_set_x(enemy.enemy_sprite, 300);
    sprite_set_y(enemy.enemy_sprite, 308);
    enemy.enemy_speed = 1;
    enemy.move_right = false;  
    enemy.min_path = 300;  
    enemy.max_path = 500;
    result.push_back(enemy);

    enemy.enemy_sprite = create_sprite(enemy_bitmap, enemy_script);
    sprite_set_x(enemy.enemy_sprite, 50);
    sprite_set_y(enemy.enemy_sprite, 158);
    enemy.enemy_speed = 1;
    enemy.move_right = false;    
    enemy.min_path = 50;
    enemy.max_path = 250;
    result.push_back(enemy);

    enemy.enemy_sprite = create_sprite(enemy_bitmap, enemy_script);
    sprite_set_x(enemy.enemy_sprite, 550);
    sprite_set_y(enemy.enemy_sprite, 158);
    enemy.enemy_speed = 1;
    enemy.move_right = false;  
    enemy.min_path = 550;  
    enemy.max_path = 750;
    result.push_back(enemy);

    return result;
}

void handle_enemy(enemy_data &enemies)
{
    sprite_set_x(enemies.enemy_sprite, sprite_x(enemies.enemy_sprite) + enemies.enemy_speed);


    if (enemies.enemy_speed > 0 && !enemies.move_right)
    {
        sprite_start_animation(enemies.enemy_sprite, "MoveRight");
        enemies.move_right = true;
    }

    if (sprite_x(enemies.enemy_sprite) + sprite_width(enemies.enemy_sprite) >= enemies.max_path || sprite_x(enemies.enemy_sprite) <= enemies.min_path || (rand() % 500 == 0))
    {
        enemies.enemy_speed = -enemies.enemy_speed;
        sprite_start_animation(enemies.enemy_sprite, "MoveLeft");
        enemies.move_right = false; 
    }       
    update_sprite_animation(enemies.enemy_sprite);   
}

int main()
{
    // Declare variables for window dimensions
    int width = 800;
    int height = 600;

    // Open a game window with specified title and dimensions
    open_window("Voidbound", width, height);

    // Load player spritesheet and set its cell details
    bitmap player_sprites = load_bitmap("PlayerBmp", "player_sprite_sheet.png");
    bitmap_set_cell_details(player_sprites, 64, 64, 9, 2, 18); // cell width, height, cols, rows, count

    // Load the animation script
    animation_script player_script = load_animation_script("PlayerScript", "player_animations.txt");

    // Create the animation
    animation player_animation = create_animation(player_script, "StandRight");

    // Create a drawing option
    drawing_options opt = option_with_animation(player_animation);

    // Declare variables for player bitmap dimensions
    double w = bitmap_cell_width(player_sprites);
    double h = bitmap_cell_height(player_sprites);

    // Calculate the player's starting position
    point_2d player_position;
    player_position.x = width / 2 - w / 2;
    player_position.y = height - 100;

    //initialise player movement vector
    vector_2d player_vector;
    player_vector.x = 0;
    player_vector.y	= 0;

    // Declare speed of player movement
    int walk_speed = 6;
    int jump_speed = 18; // Determines jump height
    int max_jump_frames = 15; // Determines time to complete jump
    int jump_frames = 0; // Current jump frames
    int fall_speed = 6;

    bool on_ground = false; //whether the player is on a surface or in the air

    vector<platform_data> platforms = create_platforms();

    // Load enemy bitmap and set cell details
    bitmap enemy_bitmap = load_bitmap("enemy", "enemy_sprite_sheet.png");
    bitmap_set_cell_details(enemy_bitmap, 28, 28, 6, 2, 12);

    // Load enemy animation script and create animation
    animation_script enemy_script = load_animation_script ("enemy_script", "enemy_animations.txt");
    animation enemy_animation = create_animation(enemy_script, "MoveRight");

    vector<enemy_data> enemies = create_enemies(enemy_bitmap, enemy_script);

    while (!key_down(ESCAPE_KEY)) // Game closes when escape key is pressed
    {
        // Check keyboard state
        process_events();
        // Clear the screen
        clear_screen();

        // Reset player vector
        player_vector.x = 0;
        player_vector.y	= 0;

        // Check collisions
        for (int i=0; i < platforms.size(); i++)
        {
            if (bitmap_rectangle_collision(player_sprites,player_position,platforms[i].rectangle) // If the player is touching the platform
                and player_position.y + h - platforms[i].rectangle.y <= 10) // But only if the player's feet are touching the platform
            {
                on_ground = true;
                break;
            }
            else
            {
                on_ground = false;
            }
        }

        // Player controls
        if (key_down(LEFT_KEY) and player_position.x > 0)
        {
            player_vector.x -= walk_speed;
        }
        if (key_down(RIGHT_KEY) and player_position.x < width - w)
        {
            player_vector.x += walk_speed;
        }
        if (key_typed(UP_KEY) and on_ground)
        {
            jump_frames = max_jump_frames;
        }
        // Apply jump movement
        if(jump_frames > 0)
        {
            player_vector.y -= jump_speed;
            jump_frames--;
        }
        // Apply gravity
        if(!on_ground)
        {
            player_vector.y += fall_speed;
        }

        // Move player
        player_position = point_offset_by(player_position,player_vector);

        // Draw platforms
        for (int i=0; i < platforms.size(); i++)
        {
            fill_rectangle(platforms[i].color, platforms[i].rectangle);
        }

        // Draw player bitmap
        draw_bitmap(player_sprites, player_position.x, player_position.y, opt);
        update_animation(player_animation);
        handle_animations(player_animation);

        for (int i=0; i < enemies.size(); i++)
        {
            draw_sprite(enemies[i].enemy_sprite);
            update_animation(enemy_animation);
            handle_enemy(enemies[i]);
        }

        // Refresh the screen
        refresh_screen(60);
    }

    // Close the game window
    close_all_windows();

    // Indicate successful program completion and return 0
    return 0;
}
```

## Creating New Combat Animations

In order to enable attacks for our player character, a new animation script that includes attack animations will be needed.

![Player sprite sheet.](Resources/images/player_sprite_sheet.png)

Save this image to the images folder in your project's resources and make sure it is named `player_sprite_sheet.png`. Replace the existing `player_sprite_sheet.png` if necessary. 

The following code is the complete animation script needed for the player character, including new animations for attacks. For more information on sprite animation, see Tutorial 5: Advanced Player Character. Replace your existing animation script in the Resources folder with this code. 

```
SplashKit Animation

//moving left
f:[0-8],[0-8],5,0
i:WalkLeft,0

//moving right
f:[9-17],[9-17],5,9
i:WalkRight,9

//standing still
f:18,0,1,
f:19,9,1,
i:StandLeft,18
i:StandRight,19

//attack left
f:[20-28],[18-26],1,
i:AttackLeft,20

//attack right
f:[29-37],[27-35],1,
i:AttackRight,29
```

Create a new text file (.txt) in the animations folder of your project's resources. Name the file `enemy_animations.txt`, then copy the above code into the file.

## Handle Attack Animations

The `handle_animations` function will need to be updated to handle the new attack animations. A `facing_right` boolean variable will be necessary to determine the direction the character is facing, so that the correct attack animation is played. Here is the complete code for the `handle_animations` function.

```cpp
void handle_animations(animation player_animation, bool &facing_right)
{
    if (key_typed(LEFT_KEY)) 
    {
        assign_animation(player_animation, "WalkLeft");
        facing_right = false;
    }
        
    if (key_typed(RIGHT_KEY))
    {
        assign_animation(player_animation, "WalkRight");
        facing_right = true;
    }

    if (key_typed(SPACE_KEY) and facing_right) 
    {
        assign_animation(player_animation, "AttackRight");
    }

    if (key_typed(SPACE_KEY) and !facing_right) 
    {
        assign_animation(player_animation, "AttackLeft");
    }

    if (!key_down(LEFT_KEY) and !key_down(RIGHT_KEY) and !key_down(SPACE_KEY))
    {
        if (key_released(LEFT_KEY)) 
        {
            assign_animation(player_animation, "StandLeft");
        }
        if (key_released(RIGHT_KEY)) 
        {
            assign_animation(player_animation, "StandRight");
        }
    }
}
```

`Facing_right` has been added as a parameter and is updated as the character moves. Two additional if statements are added to handle the `AttackLeft` and `AttackRight` animations. 

Create a `bool facing_right` variable in the main section of your program.

```cpp
bool facing_right;
```

Add this parameter to the `handle_animations` function call in the main loop.

```cpp
handle_animations(player_animation, facing_right);
```

## Handle Enemy Collision

Splashkit collision detection functions will help to determine if there has been a collision between the player character and an enemy. As the player character is a bitmap and the enemies are sprites, the `sprite_bitmap_collision(sprite s, bitmap bmp, double x, double y)` function will be used. 

This `if` statement is checking three conditions before setting the enemy sprite's scale to 0. The `key_down` function means that the player has more of a chance to press the space key at the exact time the collision occurs. 

```cpp
if (sprite_bitmap_collision(enemies[i].enemy_sprite, player_sprites, player_position.x, player_position.y) && key_down(SPACE_KEY) && sprite_scale(enemies[i].enemy_sprite) > 0)
{
    sprite_set_scale(enemies[i].enemy_sprite, 0);
}
```

If the player does not have the space key down at the time of collision, the player character has died and the game is over. In this code, the screen is cleared and text is drawn to the screen. After five seconds, the window is closed. 

```cpp
else if (sprite_bitmap_collision(enemies[i].enemy_sprite, player_sprites, player_position.x, player_position.y) && sprite_scale(enemies[i].enemy_sprite) > 0)
{
    clear_screen(COLOR_RED);
    draw_text("Game Over", COLOR_WHITE, "Arial", 36, 100, 200);
    refresh_screen(60);
    delay(5000);
    close_all_windows();
    return 0;
}
```

A `for` loop will also be necessary to check for collision between the player character and all enemy sprites. 

Here is the complete code for handling enemy collision. Place this code in the game loop of your program. 

```cpp
for (int i=0; i < enemies.size(); i++)
{
    if (sprite_bitmap_collision(enemies[i].enemy_sprite, player_sprites, player_position.x, player_position.y) && key_down(SPACE_KEY) && sprite_scale(enemies[i].enemy_sprite) > 0)
    {
        sprite_set_scale(enemies[i].enemy_sprite, 0);
    }

    else if (sprite_bitmap_collision(enemies[i].enemy_sprite, player_sprites, player_position.x, player_position.y) && sprite_scale(enemies[i].enemy_sprite) > 0)
    {
        clear_screen(COLOR_RED); // Change to a color that indicates "Game Over"
        draw_text("Game Over", COLOR_WHITE, "Arial", 36, 100, 200);
        refresh_screen(60);
        delay(5000);
        close_all_windows();
        return 0;
    }
}
```

## Putting it All Together

Below is the complete C++ code that combines all the previous steps to add enemy sprites, animation and movement to the game.

```cpp
#include "splashkit.h"
#include <vector>
#include <cstdlib>
using std::vector;

struct platform_data
{
    rectangle rectangle;
    color color;
};

struct enemy_data
{
    sprite enemy_sprite;
    double enemy_speed;
    bool move_right;
    int min_path;
    int max_path;
};

void handle_animations(animation player_animation, bool &facing_right)
{
    if (key_typed(LEFT_KEY)) 
    {
        assign_animation(player_animation, "WalkLeft");
        facing_right = false;
    }
        
    if (key_typed(RIGHT_KEY))
    {
        assign_animation(player_animation, "WalkRight");
        facing_right = true;
    }

    if (key_typed(SPACE_KEY) and facing_right) 
    {
        assign_animation(player_animation, "AttackRight");
    }

    if (key_typed(SPACE_KEY) and !facing_right) 
    {
        assign_animation(player_animation, "AttackLeft");
    }

    if (!key_down(LEFT_KEY) and !key_down(RIGHT_KEY) and !key_down(SPACE_KEY))
    {
        if (key_released(LEFT_KEY)) 
        {
            assign_animation(player_animation, "StandLeft");
        }
        if (key_released(RIGHT_KEY)) 
        {
            assign_animation(player_animation, "StandRight");
        }
    }
}

vector<platform_data> create_platforms()
{
    vector<platform_data> result;
    platform_data platform;

    // Ground platform
    platform.rectangle = rectangle_from(0,580,800,20);
    platform.color = COLOR_BLACK;
    result.push_back(platform);

    // Air platforms
    platform.rectangle = rectangle_from(50,460,200,18);
    platform.color = COLOR_RED;
    result.push_back(platform);

    platform.rectangle = rectangle_from(550,460,200,18);
    platform.color = COLOR_RED;
    result.push_back(platform);

    platform.rectangle = rectangle_from(300,330,200,18);
    platform.color = COLOR_GREEN;
    result.push_back(platform);

    platform.rectangle = rectangle_from(50,180,200,18);
    platform.color = COLOR_BLUE;
    result.push_back(platform);

    platform.rectangle = rectangle_from(550,180,200,18);
    platform.color = COLOR_BLUE;
    result.push_back(platform);

    return result;
}

vector<enemy_data> create_enemies(bitmap enemy_bitmap, animation_script enemy_script)
{
    vector<enemy_data> result;
    enemy_data enemy;

    // Ground enemy
    enemy.enemy_sprite = create_sprite(enemy_bitmap, enemy_script);
    sprite_set_x(enemy.enemy_sprite, 0);
    sprite_set_y(enemy.enemy_sprite, 558);
    enemy.enemy_speed = 1;
    enemy.move_right = false;
    enemy.min_path = 0;
    enemy.max_path = 800;
    result.push_back(enemy);

    // // Air platform enemies
    enemy.enemy_sprite = create_sprite(enemy_bitmap, enemy_script);
    sprite_set_x(enemy.enemy_sprite, 50);
    sprite_set_y(enemy.enemy_sprite, 438);
    enemy.enemy_speed = 1;
    enemy.move_right = false;
    enemy.min_path = 50;
    enemy.max_path = 250;
    result.push_back(enemy);

    enemy.enemy_sprite = create_sprite(enemy_bitmap, enemy_script);
    sprite_set_x(enemy.enemy_sprite, 550);
    sprite_set_y(enemy.enemy_sprite, 438);
    enemy.enemy_speed = 1;
    enemy.move_right = false;
    enemy.min_path = 550;
    enemy.max_path = 750;
    result.push_back(enemy);

    enemy.enemy_sprite = create_sprite(enemy_bitmap, enemy_script);
    sprite_set_x(enemy.enemy_sprite, 300);
    sprite_set_y(enemy.enemy_sprite, 308);
    enemy.enemy_speed = 1;
    enemy.move_right = false;  
    enemy.min_path = 300;  
    enemy.max_path = 500;
    result.push_back(enemy);

    enemy.enemy_sprite = create_sprite(enemy_bitmap, enemy_script);
    sprite_set_x(enemy.enemy_sprite, 50);
    sprite_set_y(enemy.enemy_sprite, 158);
    enemy.enemy_speed = 1;
    enemy.move_right = false;    
    enemy.min_path = 50;
    enemy.max_path = 250;
    result.push_back(enemy);

    enemy.enemy_sprite = create_sprite(enemy_bitmap, enemy_script);
    sprite_set_x(enemy.enemy_sprite, 550);
    sprite_set_y(enemy.enemy_sprite, 158);
    enemy.enemy_speed = 1;
    enemy.move_right = false;  
    enemy.min_path = 550;  
    enemy.max_path = 750;
    result.push_back(enemy);

    return result;
}

void handle_enemy(enemy_data &enemies)
{
    sprite_set_x(enemies.enemy_sprite, sprite_x(enemies.enemy_sprite) + enemies.enemy_speed);


    if (enemies.enemy_speed > 0 && !enemies.move_right)
    {
        sprite_start_animation(enemies.enemy_sprite, "MoveRight");
        enemies.move_right = true;
    }

    if (sprite_x(enemies.enemy_sprite) + sprite_width(enemies.enemy_sprite) >= enemies.max_path || sprite_x(enemies.enemy_sprite) <= enemies.min_path || (rand() % 500 == 0))
    {
        enemies.enemy_speed = -enemies.enemy_speed;
        sprite_start_animation(enemies.enemy_sprite, "MoveLeft");
        enemies.move_right = false; 
    }
    update_sprite_animation(enemies.enemy_sprite);   
}

int main()
{
    // Declare variables for window dimensions
    int width = 800;
    int height = 600;

    // Open a game window with specified title and dimensions
    open_window("Voidbound", width, height);

    // Load player spritesheet and set its cell details
    bitmap player_sprites = load_bitmap("PlayerBmp", "player_sprite_sheet.png");
    bitmap_set_cell_details(player_sprites, 64, 64, 9, 4, 36); // cell width, height, cols, rows, count

    // Load the animation script
    animation_script player_script = load_animation_script("PlayerScript", "player_animations.txt");

    // Create the animation
    animation player_animation = create_animation(player_script, "StandRight");

    // Create a drawing option
    drawing_options opt = option_with_animation(player_animation);

    // Declare variables for player bitmap dimensions
    double w = bitmap_cell_width(player_sprites);
    double h = bitmap_cell_height(player_sprites);

    // Calculate the player's starting position
    point_2d player_position;
    player_position.x = width / 2 - w / 2;
    player_position.y = height - 100;

    //initialise player movement vector
    vector_2d player_vector;
    player_vector.x = 0;
    player_vector.y	= 0;

    // Declare speed of player movement
    int walk_speed = 6;
    int jump_speed = 18; // Determines jump height
    int max_jump_frames = 15; // Determines time to complete jump
    int jump_frames = 0; // Current jump frames
    int fall_speed = 6;

    bool on_ground = false; //whether the player is on a surface or in the air
    bool facing_right;

    vector<platform_data> platforms = create_platforms();

    // Load enemy bitmap and set cell details
    bitmap enemy_bitmap = load_bitmap("enemy", "enemy_sprite_sheet.png");
    bitmap_set_cell_details(enemy_bitmap, 28, 28, 6, 2, 12);

    // Load enemy animation script and create animation
    animation_script enemy_script = load_animation_script ("enemy_script", "enemy_animations.txt");
    animation enemy_animation = create_animation(enemy_script, "MoveRight");

    vector<enemy_data> enemies = create_enemies(enemy_bitmap, enemy_script);

    while (!key_down(ESCAPE_KEY)) // Game closes when escape key is pressed
    {
        // Check keyboard state
        process_events();
        // Clear the screen
        clear_screen();

        // Reset player vector
        player_vector.x = 0;
        player_vector.y	= 0;

        // Check collisions
        for (int i=0; i < platforms.size(); i++)
        {
            if(bitmap_rectangle_collision(player_sprites,player_position,platforms[i].rectangle) // If the player is touching the platform
                and player_position.y + h - platforms[i].rectangle.y <= 10) // But only if the player's feet are touching the platform
            {
                on_ground = true;
                break;
            }
            else
            {
                on_ground = false;
            }
        }

        for (int i=0; i < enemies.size(); i++)
        {
            if (sprite_bitmap_collision(enemies[i].enemy_sprite, player_sprites, player_position.x, player_position.y) && key_down(SPACE_KEY) && sprite_scale(enemies[i].enemy_sprite) > 0)
            {
                sprite_set_scale(enemies[i].enemy_sprite, 0);
            }

            else if (sprite_bitmap_collision(enemies[i].enemy_sprite, player_sprites, player_position.x, player_position.y) && sprite_scale(enemies[i].enemy_sprite) > 0)
            {
                clear_screen(COLOR_RED);
                draw_text("Game Over", COLOR_WHITE, "Arial", 36, 100, 200);
                refresh_screen(60);
                delay(5000);
                close_all_windows();
                return 0;
            }
        }

        // Player controls
        if (key_down(LEFT_KEY) and player_position.x > 0)
        {
            player_vector.x -= walk_speed;
        }
        if (key_down(RIGHT_KEY) and player_position.x < width - w)
        {
            player_vector.x += walk_speed;
        }
        if (key_typed(UP_KEY) and on_ground)
        {
            jump_frames = max_jump_frames;
        }
        // Apply jump movement
        if(jump_frames > 0)
        {
            player_vector.y -= jump_speed;
            jump_frames--;
        }
        // Apply gravity
        if(!on_ground)
        {
            player_vector.y += fall_speed;
        }

        // Move player
        player_position = point_offset_by(player_position,player_vector);

        // Draw platforms
        for (int i=0; i < platforms.size(); i++)
        {
            fill_rectangle(platforms[i].color, platforms[i].rectangle);
        }

        // Draw player bitmap
        draw_bitmap(player_sprites, player_position.x, player_position.y, opt);
        update_animation(player_animation);
        handle_animations(player_animation, facing_right);

        for (int i=0; i < enemies.size(); i++)
        {
            draw_sprite(enemies[i].enemy_sprite);
            update_animation(enemy_animation);
            handle_enemy(enemies[i]);
        }

        // Refresh the screen
        refresh_screen(60);
    }

    // Close the game window
    close_all_windows();

    // Indicate successful program completion and return 0
    return 0;
}
```