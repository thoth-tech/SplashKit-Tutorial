---
title: "C++ Programming Concepts Tutorial"
description: "Learn essential C++ programming concepts, including functions, structures, enums, conditional statements, loops, and standard library usage."
author: "Khushi Laddi"
date: "2024-04-20"
tags: C++, programming, basics
---

## Introduction

Welcome to the C++ Programming Concepts tutorial. In this tutorial, we'll cover fundamental C++ programming concepts and techniques, including functions, structures, enums, conditional statements, loops, and the usage of the standard library.

## Functions, Structures, and Enums

1. **Functions**:
   - Function is created and called as per the usage, here we have fucntions for every object and provide sample block of code for understanding. It performs specific task assigned. They ensure code reusability and organization
   - First the fucntions have been declared in header files and then the main files
   - Second we are using the fucntion and creating the car 
     ```cpp
     // Function to create a new car
     car_data new_car(car_model model, double speed, double x, double y);

     // Function to draw the car
     void draw_car(car_data &car);
     ```
     ```cpp
     car_data new_car(car_model model, double speed, double x, double y)
     {
     car_data result;
     bitmap default_bitmap = car_bitmap(model);

     // Set cell details and animation script for RED and YELLOW cars
     if (model == RED || model == YELLOW)
     {
        bitmap_set_cell_details(default_bitmap, 75, 120, 3, 1, 3);
        animation_script carAnimation = load_animation_script("carAnimation", "carAnimation.txt");
        result.car_sprite = create_sprite(default_bitmap, carAnimation);
     }
     else
     {
         result.car_sprite = create_sprite(default_bitmap);
     }

     result.speed = speed;
     result.model = model;

     sprite_set_x(result.car_sprite, x);
     sprite_set_y(result.car_sprite, y);
     sprite_set_dy(result.car_sprite, result.speed);

     return result;
     }
     ```

2. **Structures**:
   - Structures allow you to create custom data types that contain multiple variables.
   - Example structure definition:
   - Code for header files;
     ```cpp
     struct car_data
     {
       sprite car_sprite; // Sprite representing the car
       car_model model;   // Model of the car
       double speed;      // Speed of the car
     };

     struct game_data
     {
      bool game_over;           // Flag indicating if the game is over
      sprite whitemarks[6];     // Array of sprites for white marks on the road
      car_data car;             // Player's car
      vector<car_data> cars;    // Vector of obstacle cars
      double score;             // Current score
     };
     struct button
     {
      const char* text;
      rectangle bounds;
     };
     ```

3. **Enums**:
   - Enums (enumerations) are user-defined data types consisting of named constants.
   - Example enum declaration:
   - These are also declared in header files
     ```cpp
     enum Color {
         RED,
         GREEN,
         BLUE
     };
     ```

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

## Standard Library Usage

1. **<vector>**:
   - The `<vector>` header provides a dynamic array implementation in C++, allowing flexible storage and manipulation of elements.
   - Example usage:
     ```cpp
     #include <vector>
     std::vector
     ```


## Conclusion

Congratulations! You've learned essential C++ programming concepts, including functions, structures, enums, conditional statements, loops, and standard library usage. These concepts are foundational to writing efficient and maintainable C++ code.

Happy coding!🚗💨

