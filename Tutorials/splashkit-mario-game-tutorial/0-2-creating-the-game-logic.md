---
title: Game logic
---

## character movement 

### character movement - left & right

Now that we have all the sprites drawn, we can work on user input and character input. The splashkit library handles user input very well, making it easy for game developers like yourself  
to make games more easily. The key down() function takes one parameter which is the key name. We will use this function to make our charcter move.

```cpp
        if (key_down(RIGHT_KEY))
        {
            if (sprite_animation_name(playerRunR) != "runr")
            {
                sprite_start_animation(playerRunR, "runr");
            }

            sprite_set_x(playerRunR, sprite_position(playerRunR).x + 1.5);
            sprite_set_x(playerIdle, sprite_position(playerIdle).x + 1.5);
            isMoving = true;
        }
```

In this code snippet above you can see that we have use an if block, in which the condition is if right key is down then we want to move our character's location by 1.5 and simultaneously we want to start the run right animation to simulate the effect that the player is running. Here the nested if block uses the function called sprite animation name(), this function checks what animation is currently running for player sprite and if its not `runr` it calls another splashkit function sprite start animatuon() which starts the `runr` animation. More about these animations are covered in this game's animation [tutorial](link). 

After setting the animation, we call another splashkit function which is sprite set x(), this function updates the sprites location on the x axis (horizontly). There are two calls as we have an idle sprite as well which also needs to be updated. Finally isMoving is a bool variable which we set True. This will be used ahead as if the charcted is not moving, we want to set the idle sprite animation otherwise the movement sprite animation. Following is the code for left movement which has the same functionality. 

```cpp
        else if (key_down(LEFT_KEY))
        {
            if (sprite_animation_name(playerRunR) != "runl")
            {
                sprite_start_animation(playerRunR, "runl");
            }

            sprite_set_x(playerRunR, sprite_position(playerRunR).x - 1.5);
            sprite_set_x(playerIdle, sprite_position(playerIdle).x - 1.5);
            isMoving = true;
        }
```

### character movement - jumping 

When it comes to jumping, we want a smooth curve for our jump. Instead of having the sprite move by pixel units, we are going to use velocity and gravity. Splashkit has great resources for making game development easy. One of the functions in splashkit, sprite set velocity() lets you set the velocity of the sprite. Now lets see you we will use this in conjuction with gravity to create a smooth jump sequence. 

```cpp
        else if (key_typed(UP_KEY))
        {
            sprite_set_velocity(playerRunR, vec);
            isJumping = true;
        }
```

In the above snippet you can see, we used the key type function as a condition to trigger the sprite set velocity function. The sprite set velocity function takes two arguments here, the sprite to apply the velocity to and the velocity value which is in the form of a data type called vector_2d. We have to initialise these vector 2d variables outside the game loop. here is the code snippet for gravity and vec velocity.

```cpp
    // jumping velocity
    vector_2d vec = vector_to(1, -1.25);
    // gravity velocity
    vector_2d gravity = vector_to(0, 0.02);
    // normal velocity
    vector_2d groundVel = vector_to(0, 0);

    bool isJumping = false;
```
In the above snippet, we have created three vector_2d variables. We have also used the vector_to() function to convert these double values to vector 2d. These values can be changed to your use case. While coding I felt they were most suitable. We have also set up a boolean variable isJumping which is set to false. This is essential to create the jumping logic. Now lets put it all together. 

Before the jumping key is typed, there is no velocity set for the player sprite. Once, the up key if statement gets executed, the velocity is set to `vec` which is set to 1 on the x axis and -1.25 at y axis. Another thing that gets executed is isJumping is now set to true. We will use this bool variable to add gravity to our player sprite. Here is the code snippet for the logic.

```cpp 
        if (isJumping)
        {

            // add the gravity to the player's velocity
            sprite_set_velocity(playerRunR, vector_add(sprite_velocity(playerRunR), gravity));

            if (sprite_position(playerRunR).y > charGround)
            {
                sprite_set_velocity(playerRunR, groundVel);
                sprite_set_y(playerRunR, charGround);
                isJumping = false;
            }
        }
```
In the snippet above, the if statement which is inside the game loop somewhere after the up key if statement. We check if isJumping is true. If that's true the sprite velocity is set again, here instead of giving a vector 2d value we pass in another function called vector_add(). This function adds the two vectors and returns a new one after the addition. 

So, the logic here is, once the player is in the air due to up key being typed we repeatedly add the value of the gravity to create an inverted u effect. Now to make the player stop at ground, first we will have to create a ground value suppose it can be 300. So, the next part is the nested if statement which triggers when the player's position goes above the set ground limit. Once the nested loop is triggered, it sets the velocity of the sprite to 0, and sets the y position of the sprite to ground. Finally it makes the isJumping variable to false so that the if block stops executing. Here is a glance at how the smooth jumping sequence looks.

![player jump gif](/Tutorials/splashkit-mario-game-tutorial/images%20and%20gifs/player%20jumping%20gif.gif)

## Enemy logic 

A good game requires some level of difficulty, that's what make them fun to play. In the first part of this tutorial we added the data for the enemy in the game which is a zombie which keeps coming towards the player and in classic mario fashion we have to jump over it in order to not die in the game. You can find the data for the zombie [here](/0-0-setting-up.md). 

we don't want the zombie to move in any direction other than towards the player, that is from left to right. While setting up the data for the zombie, we have set the x and y for the zombie sprite. But to make the zombie keep coming at the player we will add some logic to the game loop. Here is the code snippet for zombie movement

```cpp
        if (sprite_offscreen(zombRun))
        {
            //move_sprite_to(zombRun, screen_width() - 10 ,charGround);
            sprite_set_x(zombRun, screen_width() - 10);
            sprite_set_y(zombRun, charGround);
        }
        else
        {
            draw_sprite(zombRun);
        }
```
In the above snippet you can see that we have used the splashkit function called sprite_offscreen(). This function returns a bool value and takes in one parameter which is the sprite for which you want to check the condition. So, if the zombie goes out of the screen, we will reset it's x and y positions. The x position is set 10 pixels less than the screen width and y remains the same. 

if its not out of the screen, we simply draw the zombie sprite. Here is a look at how this actually looks in the game.

![zombie movement gif](/Tutorials/splashkit-mario-game-tutorial/images%20and%20gifs/zombie%20movement%20gif.gif)

### enemy collission logic

Now, we have the zombie moving towards the player but it does nothing as we haven't added that logic. We want the player to die the momment it hits the zombie. Here is the code snippet for that.

```cpp
        if (bitmap_collision(player, sprite_position(playerRunR), zomb, sprite_position(zombRun)))
        {
            clear_screen(COLOR_BLACK);

            draw_text("GAME OVER", COLOR_WHITE, 300, 300);
            refresh_screen();

            delay(5000);
            close_window(start);
        }
```
In the above code snippet we have used the function bitmap collision to detect collsion between two game objects. There is another function for that, which we will discuss later in this tutorial. This function takes the bitmap of the game object, it's position which is another data type point 2d, the second bitmap in which the first bitmap is colliding with and its position. 
So, we pass in the player's bitmap and then for the position we are using sprite_position() function which gives real-time position of the sprite which you pass as parameter. Then we pass the zombie's bitmap and again using the sprite_position function we get the real-time position of the sprite when the game is running. 

Once, this condition is true. We clear the screen with color black and we draw text game over in the center of the screen. We delay this game over screen for 5 seconds and we finally close the window. Here is a look at how this logic works in the actual game.

![zombie collision](/Tutorials/splashkit-mario-game-tutorial/images%20and%20gifs/zombie%20collision%20gif.gif)

## scoring logic 

A game is not fun unless you get rewarded for your efforts. That's why most games have a currency or points system. In this game we have coins. We want when the player hits the coin, the coin disappears and the score to be added by 1. Lets see the code for doing it. Before going into the game loop, we want to declare a few variables outside it. 

```cpp
    bool collected = false;
    // score
    int score = 0;
    string scoreString;
```
In the above code, collected is a boolean variable which is set to false, we will use it to create the coin logic. The int score is to increase the score by 1 everytime we hit a coin. The scoreString is a string variable which will store the score converted into a string. Here's the coin logic code. 

```cpp
        if (sprite_collision(playerRunR,coinSprite))
        {
            free_sprite(coinSprite);
            play_sound_effect("coinCollected");
            score++;
            collected = true;      
        }
```
Here we have another method of collision detection, we use the sprite collision() function which takes two sprites as the parameter. Once the sprite collison function returns a true value. The if block is triggered. Now, we use another function called free sprite() which frees the resource associated with a sprite. Next we play a sound effect, you can refer to the sound guide [here](link). We increase the value of the score variable by 1. Finally we set the collected value to true. Now to remove the sprite as the coin has been collected we make the following changes. 

```cpp
        if (!collected)
        {
            draw_sprite(coinSprite);
        }

        if (!collected)
        {
            update_sprite_animation(coinSprite);
            update_sprite(coinSprite);
        }  
```
In the above code snippet, we have changed the draw statements to only run if the coin is not collected. Once its collected the statements won't execute. Here is a look at how this works in the game. 

![coin collected demo](/Tutorials/splashkit-mario-game-tutorial/images%20and%20gifs/coin%20collected%20gif.gif)



### portal logic 

Now, lets move onto the use of portals in the game. In this game, portals transport you to the ground hovering above. In portals we use sprite collision as well to trigger the movement of the sprite to the hovering ground. Here is the code snippet for it. 

```cpp
        if(sprite_collision(playerRunR, portal))
        {
            int charAirGround = AgroundY - 31;
            move_sprite_to(playerRunR, sprite_position(playerRunR).x, charAirGround);
            onAir = true;
        }
```
In the above code snippet you can see we have used sprite collision to trigger movement. Next, we set a new ground height to be parallel to the hovering ground. Next, we have used the splashkit function move_sprite_to() which takes two parameters, sprite, x and y positions. Here we pass the player sprite, and we use the sprite position's x value to keep the x same and we change the y value to the new height. We set the onAir true after that. Here is how it looks in the game. 

![working portal demo](/Tutorials/splashkit-mario-game-tutorial/images%20and%20gifs/portal%20working%20gif.gif)

### ground logic

The ground in the game is a sprite which we are drawing repeatdely. The ground has to be visible even when the player and the camera moves. In this tutorial for ground, we will be referencing the camera system of the game which we have implemented using the splashkit camera functionality. You can read about it [here](link). 

We will create a new function outisde the main block called draw ground(). Here is the code for it. 

```cpp
void drawGround(sprite spr, double startx, double starty, double cameraX, double cameraY)
{
    double x = 0; 
    while (x - cameraX < screen_width() + 2000)
    {
        sprite_set_x(spr, x - cameraX);
        sprite_set_y(spr,starty -cameraY);
        draw_sprite(spr);
        x = x + sprite_width(spr);
    }
}
```
In the above code snippet we can see that the function takes a sprite which is the ground, a starting position x, y , camera's x position, camera's y position. We first set x as 0. and we set a while loop to keep running till x doesn't surpass screen_width() + 2000. The 2000 is for level design. I wanted the tutorial to be simple so I removed the functionality of drawing the ground as camera moves. Next we set the ground's x , then the ground's y. Then we draw the sprite. Finally we add the x's value by adding the sprite's width to the x which will result in the next drawing of the ground to start from where the last ground ended. This gives the illusion of the ground being one seamless sprite. Now, we call the function inside the game loop. Here is the code for it. 

```cpp
drawGround(groundSprite,0,groundY, camera_x(), camera_y());
```
Here is how the ground looks in the game.

![ground logic demo](/Tutorials/splashkit-mario-game-tutorial/images%20and%20gifs/ground%20video%20gif.gif)


### bacground logic

The background image logic is the same as ground logic, we use the drawground function just like we did above but we pass in the background image sprite. You can see in the above gif that background image works in the same way. 

Now lets move on to using camera in the game. [next](link).
