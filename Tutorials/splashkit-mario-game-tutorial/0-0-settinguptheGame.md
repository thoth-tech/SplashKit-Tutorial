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
![creating a new project](https://github.com/kay-kaushik/SplashKit-Tutorial/blob/main/Tutorials/splashkit-mario-game-tutorial/new%20project%20gif.gif)

### adding splashkit to the project 

Now, that we have all the necessary files to run the project, we can start coding the game. we start coding in the program.cpp file which is created when you run the skm new command. 
First we will add the splashkit header file to add all the splashkit functionality to our game and iostream header file to print to terminal for debugging in the development process.  

```cpp
#include "splashkit.h"
#include <iostream>
```
As we have the whole development process sorted, we can now start loading the game data 

## Laoding game data

Game data includes all the charcters in the game, objects, background and animation scripts. Link to the updated working with animation guide for this tutorial [here](link)