---
title: Game logic
---
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

### Enemy logic 

A good game requires some level of difficulty, that's what make them fun to play. In the first part of this tutorial we added the data for the enemy in the game which is 

