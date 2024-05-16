---
title: "Car Handling Tutorial with SplashKit"
description: "Learn how to handle cars in your game using the SplashKit library, including creation of different car models, drawing and updating car position, and switching car skin during gameplay."
author: "Khushi Laddi"
date: "2024-04-21"
tags: SplashKit, game development, programming, cars
---

## Introduction

Welcome to the Car Handling tutorial with SplashKit. In this tutorial, we'll explore how to handle cars in your game using the features provided by the SplashKit library. We'll cover the creation of different car models, drawing and updating car positions, switching car skins and collision detection during gameplay.

## Conditional Statements

1. **If-Else Statements**:
   - If-else statements are used to make decisions based on conditions.
   - In the function we use if-else statements to keep the use under the control
   - Example usage:

     ```cpp
     // Function to check and limit the car's position within the screen
     void input_check_positions(game_data &game)
     {
     if (sprite_x(game.car.car_sprite) <= 50)
     {
        sprite_set_x(game.car.car_sprite, 50);
     }
     else if (sprite_x(game.car.car_sprite) >= 650)
     {
        sprite_set_x(game.car.car_sprite, 650);
     }
     };
     ```

## Loops

1. **For Loop**:
   - For loops are used to iterate over a range of values or execute a block of code a specified number of times.
   - Here in my code I used as in fucntion to showcase the game
   - Example usage:

     ```cpp
     // Function to draw the game
     void draw_game(game_data &game)
     {
     clear_screen(COLOR_GRAY);
     for (int i = 0; i < 6; i++)
     {
        draw_sprite(game.whitemarks[i]);
     }
     for (int j = 0; j < game.cars.size(); j++)
     {
        draw_car(game.cars[j]);
     }

     draw_bitmap("game", 0, 0, option_to_screen());

     draw_text(to_string((int)game.score), COLOR_WHITE, "digi", 50, 650, 10, option_to_screen());
     draw_car(game.car);
     };
     ```

2. **While Loop**:

   Add the code to program.cpp in main file

   - While loops repeatedly execute a block of code as long as a specified condition is true.
   - I used the while loop in my main file so that game could keep on running till the time user doesn't want to quit
   - Example usage:

     ```cpp
     int main()
     {
     open_window("Car Racing", 800, 600);
     load_resources();
     bool game_started = false;
     game_data game = new_game();
     while (not quit_requested())
     {
     process_events();
     clear_screen(COLOR_GRAY);
     if (!game_started)
     {
        // Draw buttons and home image
        draw_bitmap("home", 0, 0, option_to_screen());
        refresh_screen(60);
        // Set game_started to true when 'S' key is pressed
        if (key_typed(S_KEY))
        {
            game_started = true;
        }
        // quit game
        if (key_typed(Q_KEY))
        {
            exit(0);
        }
     }
     else if (!game.game_over)
     {
        // Draw and update game
        draw_game(game);
        check_collisions(game);
        out_range(game);
        update_game(game);
     }
     else
     {
        // Game over screen
        stop_sound_effect("carmotor");
        draw_bitmap("ending", 0, 0, option_to_screen());
        draw_text("Score: " + to_string((int)game.score), COLOR_WHITE, "digi", 70, 100, 400, option_to_screen());
        if (key_typed(RETURN_KEY))
        {
            game = new_game();
            stop_sound_effect("endmusic");
        }
        if (!musicplayed)
        {
            play_sound_effect("endmusic", 1);
            musicplayed = true;
        }
     }

     refresh_screen(60);
     }
     }
     ```

## Collision Detection

Add the code to the game.cpp after function to remove cars that have gone out of range

Collision detection is crucial for handling interactions between game objects:

1. **Basic Collision Detection**:
   - Detect collisions between sprites based on their bounding boxes or custom shapes.
   - Example code snippet:

     ```cpp
     void check_collisions(game_data &game)
     {
     for (int i = 0; i < game.cars.size(); i++)
     {
        if (sprite_collision(game.car.car_sprite, game.cars[i].car_sprite))
        {
            play_sound_effect("carcrash", 1);
            delay(400);
            game.game_over = true;
        }
     }
     }
     ```

## Final Code for game.cpp

```cpp
#include "splashkit.h"
#include "game.h"
#include <cmath>
#include <vector>
// for the time functions, cars to spawn
#include <chrono>
#include <thread>
using namespace std;
using std::vector;
#define MIN_SPEED 5.0         // min speed of obstacle car
#define MAX_SPEED 10.0        // max speed of obstacle car
#define CARS_COUNT 7          // total obstacle cars to be spwaned
#define CARS_SPAWN_DURATION 3 // Time between each car collection
void map_setup(game_data &game)
{
    int laneSpacing = 100;
    int leftEdgePosition = screen_width() / 2 - laneSpacing * 7 / 2;

    bitmap roadEdge = create_bitmap("roadEdge", 10, screen_height());
    draw_line_on_bitmap(roadEdge, COLOR_WHITE, 0, 0, 0, screen_height(), option_line_width(10));
    setup_collision_mask(roadEdge);

    point_2d abc = point_at(leftEdgePosition, 0);
    game.game_over = false;
    abc = point_at(leftEdgePosition + (laneSpacing * 7) - 5, 0);
    bitmap road = create_bitmap("roadmarkings", 10, screen_height());
    for (int i = 0; i < screen_height(); i += 20)
    {
        draw_line_on_bitmap(road, COLOR_WHITE, 1, i, 1, i + 10, option_line_width(8));
    }

    bitmap roadCells = create_bitmap("roadCells", 50, screen_height());
    for (int i = 0; i < 7; i++)
    {
        draw_bitmap_on_bitmap(roadCells, road, i * 10, i * 4);
    }

    bitmap_set_cell_details(roadCells, 10, screen_height(), 5, 1, 5);
    setup_collision_mask(roadCells);
    animation_script roadLineAnimation = load_animation_script("roadAnimation", "roadAnimation.txt");
    for (int i = 0; i < 6; i++)
    {
        game.whitemarks[i] = create_sprite(roadCells, roadLineAnimation);
        sprite_start_animation(game.whitemarks[i], "moving");
        abc = point_at(leftEdgePosition + (laneSpacing * (i + 1)), 0);
        sprite_set_position(game.whitemarks[i], abc);
    }
}

double random_range(double min, double max)
{
    return min + (rand() / (RAND_MAX / (max - min)));
}
// Function to randomly spawn obstacle cars
void randomCars(game_data &game)
{
    int xLocations[] = {50, 150, 250, 350, 450, 550, 650}; // Array to store the x locations
    car_model carModels[] = {POLICE, BLACK};               // Array of car models

    // Randomly select x locations for the cars
    for (int i = 0; i < CARS_COUNT; i++)
    {
    int randomIndex = rand() % CARS_COUNT; // Generate a random index between 0 and 6
    int x = xLocations[randomIndex];
    car_model model = carModels[rand() % 2]; // Randomly select a car model
    int speed = random_range(MIN_SPEED, MAX_SPEED); // Randomly select a speed
    car_data laner_cars = new_car(model, speed, x, -300); // Create a car sprite at the selected x location
    game.cars.push_back(laner_cars); // Add the car to the game's car vector
   }
}
auto last_call_time = std::chrono::steady_clock::now(); // Track the last time the function was called
game_data new_game()
{
    game_data game;
    game.car = new_car(RED, 0, screen_width() / 2, screen_height() - 200);
    map_setup(game);
    game.score = 0;
    sprite_start_animation(game.car.car_sprite, "straight");
    play_sound_effect("carmotor", 1, 0.1);
    return game;
}
// Function to handle user input
void handleInput(game_data &game)
{
    if (key_down(A_KEY))
    {
        sprite_set_x(game.car.car_sprite, sprite_x(game.car.car_sprite) - 5);
        sprite_start_animation(game.car.car_sprite, "left");
    }
    else if (key_down(D_KEY))
    {
        sprite_set_x(game.car.car_sprite, sprite_x(game.car.car_sprite) + 5);
        sprite_start_animation(game.car.car_sprite, "right");
    }
    else if (key_typed(R_KEY))
    {
        switch_car_skin(game.car);
    }
    else
    {
        sprite_start_animation(game.car.car_sprite, "straight");
    }
}
// Function to draw the game
void draw_game(game_data &game)
{
    clear_screen(COLOR_GRAY);

    for (int i = 0; i < 6; i++)
    {
        draw_sprite(game.whitemarks[i]);
    }

    for (int j = 0; j < game.cars.size(); j++)
    {
        draw_car(game.cars[j]);
    }

    draw_bitmap("game", 0, 0, option_to_screen());

    draw_text(to_string((int)game.score), COLOR_WHITE, "digi", 50, 650, 10, option_to_screen());
    draw_car(game.car);
}
// Function to check and limit the car's position within the screen
void input_check_positions(game_data &game)
{
    if (sprite_x(game.car.car_sprite) <= 50)
    {
        sprite_set_x(game.car.car_sprite, 50);
    }
    else if (sprite_x(game.car.car_sprite) >= 650)
    {
        sprite_set_x(game.car.car_sprite, 650);
    }
}
// Function to remove cars that have gone out of range
void out_range(game_data &game)
{
    for (int j = 0; j < game.cars.size(); j++)
    {
        if (sprite_y(game.cars[j].car_sprite) > 600)
        {
            // remove the element from this vector
            game.cars.erase(game.cars.begin() + j);
            // Decrement j to account for the removed element
            j--;
        }
    }
}
// Function to check for collisions between the player's car and obstacle cars
void check_collisions(game_data &game)
{
    for (int i = 0; i < game.cars.size(); i++)
    {
        if (sprite_collision(game.car.car_sprite, game.cars[i].car_sprite))
        {
            play_sound_effect("carcrash", 1);
            delay(1500);
            game.game_over = true;
        }
    }
}
// Function to update the game state
void update_game(game_data &game)
{
    game.score += 0.3;
    update_car(game.car);
    for (int j = 0; j < game.cars.size(); j++)
    {
        update_car(game.cars[j]);
    }
    for (int i = 0; i < 6; i++)
    {
        update_sprite(game.whitemarks[i]);
    }

    input_check_positions(game);
    handleInput(game);
    // Call the randomCars function every CARS_SPAWN_DURATION seconds
    auto current_time = std::chrono::steady_clock::now();
    auto elapsed_time = std::chrono::duration_cast<std::chrono::seconds>(current_time - last_call_time).count();
    if (elapsed_time >= CARS_SPAWN_DURATION)
    {
        randomCars(game);
        last_call_time = current_time;
    }
}
```

## Final Code for Game.h

```cpp
#ifndef CAR_RACE_GAME
#define CAR_RACE_GAME

#include "splashkit.h"
#include <vector>
#include "car.h"

// Structure to store game data
struct game_data
{
    bool game_over;           // Flag indicating if the game is over
    sprite whitemarks[6];     // Array of sprites for white marks on the road
    car_data car;             // Player's car
    vector<car_data> cars;    // Vector of obstacle cars
    double score;             // Current score
};

// Function to create a new game
game_data new_game();

// Function to draw the game
void draw_game(game_data &game);

// Function to update the game state
void update_game(game_data &game);

// Function to remove cars that have gone out of range
void out_range(game_data &game);

// Function to check for collisions between the player's car and obstacle cars
void check_collisions(game_data &game);

#endif
```

## Conclusion

Congratulations! You've learned how to handle cars in your game using the SplashKit library. Experiment with different car models, customize their appearance, and enhance your gameplay experience. Keep practicing and exploring the possibilities to create amazing car-themed games!

Happy game development!🚗💨
