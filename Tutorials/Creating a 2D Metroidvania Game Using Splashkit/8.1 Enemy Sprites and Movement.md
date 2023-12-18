---
title: "Enemy Sprites and Movement"
description:
  Learn how to create enemy sprites, animation and movement.
author: Georgie O'Malley
date: 4/12/2023
tags: game development, programming, Splashkit, functions
---

# Tutorial 8: Enemy Sprites and Movement

This tutorial involves creating enemy sprites, and implementing animation and movement.

This tutorial builds on the following code until previous tutorials are completed.

```cpp
#include "splashkit.h"
#include <vector>
using std::vector;

struct platform_data
{
	rectangle rectangle;
	color color;
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

	// Load the background image from the specified path
    //bitmap background = load_bitmap("sky", "Resources/images/sky.png");

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

	while (!key_down(ESCAPE_KEY)) // Game closes when escape key is pressed
	{

		// Check keyboard state
		process_events();
		// Clear the screen with the loaded background image
		clear_screen();
		//draw_bitmap(background, 0, 0);

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

		// Refresh the screen
		refresh_screen(60);
	}

    // Close the game window
    close_all_windows();

    // Indicate successful program completion and return 0
    return 0;
}
```

## Enemy Sprite Creation, Animation and Movement

To create an enemy sprite, we first need to load the enemy sprite sheet and animation script.

![Enemy sprite sheet.](enemy_sprite_sheet.png)

Save this image to the images folder in your project's resources and make sure it is named `enemy_sprite_sheet.png`

The following code is the complete animation script needed for the enemy character. For more information on sprite animation, see Tutorial 5: Advanced Player Character.

```
SplashKit Animation

//moving left
f:[0-5],[0-5],5,0
i:MoveRight,0

//moving right
f:[6-11],[6-11],5,6
i:MoveLeft,6
```

Create a new text file (.txt) in the animations folder of your project's resources. Name the file `enemy_animations.txt`, then copy the above code into the file.

The following code loads the enemy character's spritesheet and sets the cell details for use with animation. Next, load the enemy character's animation script and create the animation. Make sure this code is in the main section of your program, before the game loop.

```cpp
// Load enemy bitmap and set cell details
bitmap enemy_bitmap = load_bitmap("enemy", "enemy_sprite_sheet.png");
bitmap_set_cell_details(enemy_bitmap, 28, 28, 6, 2, 12);

// Load enemy animation script and create animation
animation_script enemy_script = load_animation_script ("enemy_script", "enemy_animations.txt");
animation enemy_animation = create_animation(enemy_script, "MoveRight");
```

Next we need to create the enemy sprite itself, set its inital position, and create some variables that will be used in the next function. Place this code just after the previous code in the main section of your program.

```cpp
// Create enemy sprite and set its bitmap and animation script
sprite enemy_sprite = create_sprite(enemy_bitmap, enemy_script);

// Set the initial position of the sprite
sprite_set_x(enemy_sprite, 0);
sprite_set_y(enemy_sprite, height - sprite_height(enemy_sprite) - 14);

// Create enemy variables
double enemy_speed = 0.5;
bool move_right;
int min_path = 0;
int max_pax = 800;
```

A new function is needed to handle movement and animation for the enemy character. This function will be called `handle_enemy` and will take the following parameters.

```cpp
void handle_enemy(sprite enemy_sprite, double &enemy_speed, bool &move_right, int min_path, int max_path)
{

}
```

The function first needs to set the enemy's x coordinate and speed. The bool `move_right` is used in this function to determine the direction the enemy is moving and to start the correct animation. The `min_path` and `max_path` values are set to either edge of the screen and are used to make sure the enemy does not go past these points. 

The two `if` statements in this function determine which way the sprite is moving, set the appropriate speed, play the correct animation, and ensure the enemy does not go past the edge of the screen. 

```cpp
void handle_enemy(sprite enemy_sprite, double &enemy_speed, bool &move_right, int min_path, int max_path)
{
    sprite_set_x(enemy_sprite, sprite_x(enemy_sprite) + enemy_speed);

    if (enemy_speed > 0 && !move_right)
    {
        sprite_start_animation(enemy_sprite, "MoveRight");
        move_right = true;
    }

    if (sprite_x(enemy_sprite) + sprite_width(enemy_sprite) >= max_path || sprite_x(enemy_sprite) <= min_path)
    {
        enemy_speed = -enemy_speed;
        sprite_start_animation(enemy_sprite, "MoveLeft");
        move_right = false;  // Reset the flag when switching to MoveLeft
    }      

    update_sprite_animation(enemy_sprite);
}
```

To test the code so far, add the following three function calls to the game loop of your program. 

```cpp
draw_sprite(enemy_sprite);
update_animation(enemy_animation);
handle_enemy(enemy_sprite, enemy_speed, move_right, min_path, max_path);
```

You should see the enemy character move from left to right along the bottom of the screen, and change animation as its direction changes.

![Enemy sprite.](enemy_sprite.png)

## Generating Multiple Enemy Sprites

To create an enemy sprite for each platform in the game a struct should be used, as each enemy has a number of properties, similar to the `platform_data` struct created in Tutorial 6. Create an `enemy_data` struct that contains the following properties.

```cpp
struct enemy_data
{
    sprite enemy_sprite;
    double enemy_speed;
    bool move_right;
    int min_path;
    int max_path;
};
```

Similar to the `create_platforms` function, we need a `create_enemies` function to create an enemy sprite on each platform and set its speed and path. This function will take the `enemy_bitmap` and `enemy_script`.

In this function, the `min_path` and `max_path` are set to either edge of the platform that the enemy is on. For example, the second platform starts at the x coordinate 50, and has a width of 200. Therefore, the `min_path` for this enemy will be 50, and the `max_path` will be 250.

```cpp
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
```

The `handle_enemy` function will now need to be altered slightly, as all of our enemy properties are now contained in the `enemy_data` struct. Now the function will only need to take one parameter.

```cpp
void handle_enemy(enemy_data &enemies)
{
    sprite_set_x(enemies.enemy_sprite, sprite_x(enemies.enemy_sprite) + enemies.enemy_speed);

    if (enemies.enemy_speed > 0 && !enemies.move_right)
    {
        sprite_start_animation(enemies.enemy_sprite, "MoveRight");
        enemies.move_right = true;
    }

    if (sprite_x(enemies.enemy_sprite) + sprite_width(enemies.enemy_sprite) >= enemies.max_path || sprite_x(enemies.enemy_sprite) <= enemies.min_path)
    {
        enemies.enemy_speed = -enemies.enemy_speed;
        sprite_start_animation(enemies.enemy_sprite, "MoveLeft");
        enemies.move_right = false; 
    }      

    update_sprite_animation(enemies.enemy_sprite);
}
```

To test the code at this point, remove the sprite and variables created in the main part of your program and replace them with this single line.

```cpp
vector<enemy_data> enemies = create_enemies(enemy_bitmap, enemy_script);
```

In the game loop, the three funtion calls should now be placed inside a `for` loop to draw each enemy sprite and handle animation and movement. 

```cpp
for (int i=0; i < enemies.size(); i++)
{
	draw_sprite(enemies[i].enemy_sprite);
	update_animation(enemy_animation);
	handle_enemy(enemies[i]);
}
```

## Adding Random Movement

To make the enemy character's movement more interesting and unpredictable, we can alter the `handle_enemy` function to use random values as conditions for changing the direction of the enemy sprite.

First, add the necessary header to use the `rand()` function at the top of your program.

```cpp
#include <cstdlib>
```

Next, modify the `handle_enemy` function to add random direction changes.

```cpp
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
```

You can alter the random value to create more or less frequent random movement. 

Test the program. The result should look something like this.

![Enemy sprites.](complete_enemy_sprites.png)

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