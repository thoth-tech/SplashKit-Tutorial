---
title: "SplashKit Library Features Tutorial"
description: "Explore the features of the SplashKit library for game development, including sprite creation, drawing, animation, bitmap loading, manipulation, sound effect loading, and playback."
author: "Khushi Laddi"
date: "2024-04-21"
tags: SplashKit, game development, programming, basics
---

## Introduction

Welcome to the SplashKit Library Features tutorial. In this tutorial, we'll dive into the features offered by the SplashKit library, a powerful toolkit for game development in C++. We'll cover sprite creation, drawing, animation, bitmap loading, manipulation, sound effect loading, and playback.

## Sprite Creation, Drawing, and Animation

1. **Sprite Creation**:
   - Sprites are movable and animated images used to represent game objects.
   - Here we created the sprite to change the color of car skin
   - Create a sprite from a bitmap:

     ```cpp
     void switch_car_skin(car_data &car)
     {
     bitmap other = car_bitmap(YELLOW);
     bitmap_set_cell_details(other, 75, 120, 3, 1, 3);
     sprite_add_layer(car.car_sprite, other, "YELLOW");
     sprite_hide_layer(car.car_sprite, 1);

     if (car.model == RED)
     {
        car.model = YELLOW;
        sprite_hide_layer(car.car_sprite, 0);
        sprite_show_layer(car.car_sprite, 1);
     }
     else if (car.model == YELLOW)
     {
        car.model = RED;
        sprite_hide_layer(car.car_sprite, 1);
        sprite_show_layer(car.car_sprite, 0);
     }
     }
     ```

2. **Drawing Sprites**:
   - Draw a sprite on the screen:
     ```cpp
     // Function to draw the car
     void draw_car(car_data &car)
     {
     draw_sprite(car.car_sprite);
     }
     ```

3. **Animation**:
   - Animate a sprite by changing its position, rotation, and image frame over time:
   - While creating new car we declared the animation of the car
     ```cpp
     animation_script carAnimation = load_animation_script("carAnimation", "carAnimation.txt");
     ```

## Bitmap Loading and Manipulation

1. **Bitmap Loading**:
   - Load bitmap images from files:
     ```cpp
     // Used on many occassions
     draw_bitmap("game", 0, 0, option_to_screen()); // used while drawing the game
     bitmap default_bitmap = car_bitmap(model); // getting the car image
     ```

2. **Bitmap Manipulation**:
   - Modify bitmap properties such as size, color, and transparency:
     ```cpp
       bitmap_set_cell_details(default_bitmap, 75, 120, 3, 1, 3); // setting the car position
     ```


## Conclusion

Congratulations! You've explored the key features of the SplashKit library for game development. With SplashKit, you can create dynamic and engaging games with ease. Experiment with sprite creation, bitmap loading, sound effect playback, and more to bring your game ideas to life!

Happy game development!🚗💨
