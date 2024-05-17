---
title: splashkit camera
---

## splashkit camera 

Splashkit has great camera functionality to give the illusion that we are moving through a game world. We don't have to create a camera object. It already exists when using splashkit. We just have to update it's positions and details to make it work for our needs. In this game we have centered the camera on the player, the protagonist of the game. So, we want the camera to follow the player's position. For this we have created an update camera function. Here is the code for it. 

```cpp
void update_camera(const sprite &target)
{

    center_camera_on(target, 10, -150);

    // Ensure camera stays within the bounds of the game world
    if (camera_x() < 0)
    {
        set_camera_x(0);
    }
    if (camera_y() < 0)
    {
        set_camera_y(0);
    }
}
```
In the above code snippet, you can see that we have a function called update camera(), this function takes a sprite as a parameter. Then we call the function center camera on , this function takes the sprite that we want to center the camera on, the other two parameters are x and y offsets. the "offset" refers to an additional adjustment applied to the camera position.

When you set the camera view to be centered over a sprite, the sprite's position becomes the center of the screen. However, the offset allows you to adjust this centering by moving the camera a certain distance from the sprite's position.

For example, if you set both offset_x and offset_y to 0, the camera will be centered exactly on the sprite. But if you set offset_x to a positive value, the camera will move that many units to the right of the sprite's position. Similarly, setting offset_y to a positive value will move the camera that many units down from the sprite's position.

This allows you to fine-tune the positioning of the camera relative to the sprite. Next, to ensure that the camera stays in the bounds of the game world, we write if statements, we use the function camera_x() to get the camera's position along the x axis. if it's less than 0, we set it to 0. We do the same for the y position. 

Now, we will call this function in the main game loop. Here is the code snippet for it.

```cpp
update_camera(playerRunR);
```

You can learn more about the splashkit camera [here](link). 

### camera relative positioning

Now that we have the camera up and running, we want to create such an effect that makes it feel like the player is moving inside the world. To create that effect, we are going to position all the game objects relative to the camera. Here's how. 

```cpp
draw_ground(bgSpr,0,0, camera_x(), camera_y());
draw_sprite(Aground, -camera_x(), -camera_y());
draw_portal(portal, 600 -camera_x(), charGround);
draw_sprite(endGate, -camera_x(), -camera_y());
draw_ground(groundSprite,0,groundY, camera_x(), camera_y());
```

In the above code snippet you can see we have modified the draw statements for all the game objects such that they are relative to the camera. So, wherever there is -camera_x() and -camera_y(), it simply means that we are subtracting the camera's position from the objects set position. So, if the camera's x increases the object's x decreases. Essentially moving it behind. This gives the effect of movement to the game and the player. Here is a demo of how it looks in the game. 

![camera scrolling demo](/Tutorials/splashkit-mario-game-tutorial/images%20and%20gifs/camera%20scrolling%20gif.gif)

### Game files

The game is finally complete, you can go ahead and build the entire game level. This tutorial has equipped you with all the knowledge of creating a game using the splashkit library. Here is the link to all the game [files](https://github.com/kay-kaushik/splashkit-karioGame).
