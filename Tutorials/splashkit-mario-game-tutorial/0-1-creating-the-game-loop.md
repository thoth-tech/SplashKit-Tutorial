---
title: Drawing sprites
---
## Creating the game loop 

The game loop is where we code the flow of the game and its logic. The game is always contained in basically a while loop which keeps updating the positions and details of the game objects.  
So, in order for our game to work, we need to set the while loop to continue running till quit is requested. Following is the code for creating the game loop.

```cpp
while (!quit_requested())
{
    /* code */
}
```

Now, let's draw our game objects inside the loop.

## drawing sprites 

Now that we have the game data loaded into our program file, we can start drawing the sprites on the game window.  
First we have to create a loop which will not stop till quit is requested. Then in the game loop we will add the following functions: -

+ clear screen(), this function clear the screen, it takes color as the parameter. 
+ draw sprite(), this function draws the sprite on the screen, if the sprite added as the parameter already has x and y set, it will draw the sprite at that location in the game. 
+ refresh screen(), this function refreshes the screen with a target frame per second, it takes integer as a parameter. 
+ update sprite(), this function updates the position and the details of the animation of the sprite, it's an overloaded function, but here we just pass in the sprite we want to update. 
+ update sprite animation(), this updates the animation details of the sprite. 
+ process events(), this function allows splashkit to react to the user input such as key presses, mouse input. It needs to be called once in the game loop.

Here is the cpp code snippet, the snippet just shows how to write the draw functions, the variable names and some functions may be different, this is just an example based on which you can  
draw your own sprites. The code files for this project are [here](https://github.com/kay-kaushik/splashkit-karioGame).

```cpp
    while (!quit_requested())
    {
        clear_screen(COLOR_BLACK);
        draw_sprite(Aground, -camera_x(), -camera_y());
        draw_portal(portal, 600 -camera_x(), charGround);
        draw_sprite(endGate, -camera_x(), -camera_y());
        draw_sprite(playerRunR);
        draw_text(scoreString, COLOR_BLACK, 500 - 25, 10);
        refresh_screen(60);
        
        update_sprite_animation(coinSprite);
        update_sprite(coinSprite);
        update_sprite_animation(portal);
        update_sprite(portal);
        update_sprite_animation(endGate);
        update_sprite(endGate);
        sprite_set_velocity(zombRun, zombVel);
        update_sprite_animation(playerRunR);
        update_sprite(playerRunR);
        update_sprite_animation(zombRun);
        update_sprite(zombRun);
        update_sprite_animation(playerIdle);
        update_sprite(playerIdle);
        process_events();
    }
```

Now that we have created the game loop and drawn our game objects, we can start working on the game logic, go to the next section [here](link).



