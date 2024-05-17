---
title: Setting up & Loading game data
---

## Setting up and loading game data

### Prerequisites

+ splashkit and its dependencies installed on your system
+ knowledge of c++ programming language
+ knowledge of VScode

### Introduction

In this tutorial we are going to create a simple mario style game using the splashkit library. We are going to cover topics like: -

+ loading resources into the game.
+ movement logic.
+ animation
+ game physics
+ camera logic

Now, let's start making the game. 

### creating a splashkit project

First we will open a new folder in VScode, where we will store all our code and its files. Now, we will click on terminal on the top of the screen, then new terminal.
Now we will write the splashkit command in the terminal to create a new project. This project is created in c plus plus. 

```bash
skm new c++
```
![creating a new project](/Tutorials/splashkit-mario-game-tutorial/images%20and%20gifs/new%20project%20gif.gif)

Next, we want to run skm  resources command to create resource files. This is where we will add the image, sprite, audio etc. files. Here is the code snippet.

```bash
skm resources
```

### adding splashkit to the project 

Now, that we have all the necessary files to run the project, we can start coding the game. we start coding in the program.cpp file which is created when you run the skm new command. 
First we will add the splashkit header file to add all the splashkit functionality to our game.

```cpp
#include "splashkit.h"
```
### creating a game window 

First thing our game needs is a game window. To create one we will create a window object and call the function open window(). This function takes in 3 parameters, a string which is the name of the window. The second is a double which is the width of the window. The third one is a double which is the height of the window. We will include it in the main code block. 

```cpp
window start = open_window("test", 1000, 600);
```
Now that we have the game environment setup, we can start loading the game data. 

## Loading game data

Game data includes all the characters in the game, objects, background and animation scripts. Here is a link to the working with sprites and animation guide for this tutorial [here](link).   

In the mario game we have the following game objects which we need to add to our game.

+ the background - this is the background image or a backdrop. It is great way to set the scene and tone of the game. 
+ the ground - base of the game.
+ floating ground - to add dimensionality to the game.
+ player - the proganist of the game. 
+ zombie - enemy in the game.
+ coins - currency/scoring.
+ portals - gateways to move to the floating ground in the game.
+ end game gate - level end gate. 

### Loading procedure and setting sprite details

Whenever we want to add a sprite to a game in splashkit and set it's details, we have to follow these steps. 

1. Load the bitmap, which is a sprite sheet containing all the sprite movement actions. 
2. Add cell details of the bitmap 
3. Load the animation script
4. Create a sprite using the bitmap 
5. set the sprite's x position 
6. set the sprite's y position
7. start the sprite animation
 
Here is the code for adding all the game objects into our game. 

```cpp
    // screen data
    window start = open_window("Mario", 1000, 600);
    bitmap bg = load_bitmap("bG", "background.jpg");
    sprite bgSpr = create_sprite(bg);
```

In the above snippet, we have created a window variable, then we use the splashkit function open_window() which takes the parameters, string (name of the window), the width and height of the window. Then we create a bitmap variable, we use the load_bitmap() function which takes the name of the bitmap and the file name. Its important to note that you want to store all the resources such as iimages, animation script, sound etc in the resources folder. Lastly we use the cerate sprite function which creates a sprite using a bitmap in this case we have created the sprite bgSpr using the bitmap bg and create sprite function. 

Using these functions and process, we can load all the game data into the game. Remeber to put all the code in the main block of the file. Here is the code for rest of the game objects. 

```cpp
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

Now let's go to the next section [here](0-1creating-the-game-loop.md).



