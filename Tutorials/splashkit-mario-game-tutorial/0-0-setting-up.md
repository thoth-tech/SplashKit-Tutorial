---
title: Setting up & Loading game data
---

## Setting up and loading game data

### Prequistes 

+ splashkit and its dependencies installed on your system
+ knowledge of c++ programming language
+ knowledege of vsCode

### creating a splashkit project

First we will open a new folder in VScode, where we will store all our code and its files. Now, we will click on terminal on the top of the screen, then new terminal.
Now we will right the splashkit command in the terminal to create a new project. This project is created in c plus plus. 

```bash
skm new c++
```
![creating a new project](/Tutorials/splashkit-mario-game-tutorial/images%20and%20gifs/new%20project%20gif.gif)

### adding splashkit to the project 

Now, that we have all the necessary files to run the project, we can start coding the game. we start coding in the program.cpp file which is created when you run the skm new command. 
First we will add the splashkit header file to add all the splashkit functionality to our game and iostream header file to print to terminal for debugging in the development process.  

```cpp
#include "splashkit.h"
#include <iostream>
```
### creating a game window 

First thing our game needs is a game window. To create one we will create a window object and call the function open window(). This function takes in 3 parameters, a string which is the name of the window. The second is a double which is the width of the window. The third one is a double which is the height of the window.

```cpp
window start = open_window("test", 1000, 600);
```
Now that we have the game enviorment setup, we can start loading the game data. 

## Laoding game data

Game data includes all the charcters in the game, objects, background and animation scripts. Link to the updated working with sprites and animation guide for this tutorial [here](link).   
In the mario game we have the follwoing game objects which we need to add to our game.

+ the background
+ the ground
+ floating ground
+ player 
+ zombie 
+ coins
+ portals 
+ end game gate 

Whenever we want to add a charcater to a game in splashkit, we have to follow these steps. 

1. Load the bitmap, which is a sprite sheet containing all the spriet movement actions. 
2. Add cell details of the bitmap 
3. Load the animation script
4. Create a sprite using the bitmap 
5. set the sprite's x position 
6. set the sprite's y position
7. start the sprite animation

All of the above are explained in depth in this tutorial [here](link).  
Here is the code for adding all the game objects into our game. 

```cpp
    // screen data
    window start = open_window("test", 1000, 600);
    bitmap bg = load_bitmap("bG", "background.jpg");
    sprite bgSpr = create_sprite(bg);

    // gound data 
    bitmap groundBmp = load_bitmap("ground", "assets/images/ground4.png");
    sprite groundSprite = create_sprite(groundBmp);
    sprite_set_x(groundSprite, 0);
    double groundY =  window_height(start) - bitmap_height(groundBmp);
    sprite_set_y(groundSprite, groundY);

    // character data
    double charGround = groundY -32;

    // air ground data
    bitmap AgroundBmp = load_bitmap("Aground", "assets/images/groundAir.png");
    sprite Aground = create_sprite(AgroundBmp);
    sprite_set_x(Aground, 600);
    double AgroundY =  charGround - 50;
    sprite_set_y(Aground, AgroundY);

    // player data
    bitmap player = load_bitmap("playerBmp", "protSpriteSheet.png");
    bitmap_set_cell_details(player, 31, 32, 4, 3, 12);
    animation_script playAnimScript = load_animation_script("playRunR", "playerRunR.txt");
    animation_script playIdleScript = load_animation_script("playIdle", "playerIdle.txt");
    animation playRunR = create_animation(playAnimScript, "runR");
    animation playRunL = create_animation(playAnimScript, "runL");
    animation playIdle = create_animation(playIdleScript, "idle");
    sprite playerIdle = create_sprite(player, playIdleScript);
    sprite playerRunR = create_sprite(player, playAnimScript);

    // sprite_start_animation(playerRunR, animation_name(playRunR));
    sprite_set_x(playerIdle, 100);
    sprite_set_y(playerIdle, charGround);
    sprite_set_x(playerRunR, 100);
    sprite_set_y(playerRunR, charGround);

    // zombie data
    bitmap zomb = load_bitmap("zombieBmp", "zombieSpriteSheet.png");
    bitmap_set_cell_details(zomb, 31, 32, 4, 3, 12);
    animation_script zombAnimS = load_animation_script("zombRun", "playerRunR.txt");
    animation zombAnim = create_animation(zombAnimS, "runL");
    sprite zombRun = create_sprite(zomb, zombAnimS);
    sprite_set_x(zombRun, 500);
    sprite_set_y(zombRun, charGround);
    sprite_start_animation(zombRun, "runl");

    // coin data
    bitmap coin1 = load_bitmap("coins", "assets/images/coinspritesheet.png");
    bitmap_set_cell_details(coin1, 64, 63, 8, 1, 8);
    animation_script coinScript = load_animation_script("coinAnimationScript", "coinAnimationScript.txt");
    animation coinAnim = create_animation(coinScript, "coin");
    sprite coinSprite = create_sprite(coin1, coinScript);
    sprite_start_animation(coinSprite, "coin");
    sprite_set_x(coinSprite, 500);
    sprite_set_y(coinSprite, charGround - 20);
    sound_effect coinSound = load_sound_effect("coinCollected", "coinCollected.wav");

    // portal data
    bitmap port = load_bitmap("port", "assets/images/portals.png");
    bitmap_set_cell_details(port, 32,32,4,5,17);
    animation_script portScript = load_animation_script("portalAnimationScript", "portalScript.txt");
    animation portalAnim = create_animation(portScript, "portal");
    sprite portal = create_sprite(port, portScript);
    sprite_start_animation(portal,"portal");
    sprite_set_x(portal, 800);
    sprite_set_y(portal, charGround);

    // endGate Data
    bitmap end = load_bitmap("end", "assets/images/endGate.png");
    bitmap_set_cell_details(end, 32,31,5,1,5);
    animation_script endScript = load_animation_script("endGateAnimationScript", "endGateScript.txt");
    animation endAnim = create_animation(endScript, "end");
    sprite endGate = create_sprite(end, endScript);
    sprite_start_animation(endGate,"end");
    sprite_set_x(endGate, 1050);
    sprite_set_y(endGate, charGround); 
```
Now lets go to the next section [here](link).



