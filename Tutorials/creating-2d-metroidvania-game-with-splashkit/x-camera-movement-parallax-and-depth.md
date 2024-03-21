# Creating a 2D "Metroidvania" Game - Camera Movement, Parallax, and Depth
## Introduction
In this tutorial, we will delve into implementing camera movement and parallax scrolling in a 2D "Metroidvania" style game using the SplashKit library. These features are crucial for creating a dynamic and immersive game environment.

## Prerequisites
- Basic knowledge of C++ and game programming concepts.
- SplashKit SDK installed and set up in your development environment.

## Camera Movement: Lazy Character Movement
In many platformer games, the camera follows the character in a way that allows some freedom of movement within the center of the screen, but starts scrolling when the character approaches the edge. This is often referred to as "lazy" character movement.

### Implementing Lazy Camera Movement
1. Character Positioning:
    - Keep track of the character's position using a **sprite** structure.
    - Implement character movement logic allowing them to move freely within a defined central area of the screen.

2. Using **center_camera_on**:
    - Use the **center_camera_on** function to make the camera follow the character. You can specify offsets to adjust the camera's central focus area on the screen.

Here is a Lazy Camera Movement example.
- The camera gradually follows after player starts moving. This kind of lazy camera movement allows players to better predict and plan their moves, while also enhancing the visual appeal of the game. 

![Lazy Camera Movement Example](images/Lazy%20Character%20Movement.gif)

- The following code demonstrates basic methods to implement lazy camera movement in SplashKit.
```cpp
#include "splashkit.h"

// Define the character structure
struct character {
    sprite character_sprite;
    point_2d position;
};

// Initialize the character
character create_character() {
    character result;
    result.character_sprite = load_sprite("Character", "images/character.png");
    result.position = point_at(400, 300); // Initial position
    return result;
}

// Update the character's position and camera
void update_character(character &player, camera &game_camera) {
    // Character movement logic
    if (key_down(LEFT_KEY)) {
        player.position.x -= 2;
    }
    if (key_down(RIGHT_KEY)) {
        player.position.x += 2;
    }
    // Additional movement logic...

    // Update character sprite position
    sprite_set_x(player.character_sprite, player.position.x);
    sprite_set_y(player.character_sprite, player.position.y);
}

int main() {
    open_window("Metroidvania Game", 800, 600);
    character player = create_character();
    camera game_camera = create_camera();

    while (not quit_requested()) {
        process_events();
        update_character(player);
        center_camera_on(player.character_sprite, 0, 0); 
        clear_screen(COLOR_WHITE);
        draw_sprite(player.character_sprite);
        refresh_screen();
    }
    return 0;
}
```
[Example of Lazy Character Movement Video](https://www.youtube.com/watch?app=desktop&v=ZYZkLe0r0aY)

## Parallax Scrolling for Depth
Parallax scrolling is a technique where background images move by the camera slower than foreground images, creating an illusion of depth in a 2D scene.

### Implementing Parallax Scrolling
1. Layered Backgrounds:
    - Create multiple layers of background images, with each layer moving at a different speed relative to the camera movement.
    - The farthest layers (e.g., distant mountains) should move slower than the closer layers (e.g., nearby trees).

2. Background Movement:
    - As the camera moves, adjust the position of each background layer at a different rate.
    - The rate of movement for each layer should be proportional to its perceived distance from the camera.

3. Rendering Backgrounds:
    - Render each background layer in order, from the farthest to the nearest, before rendering the game's main content.

Here is a Parallax Scrolling example.
- This technique creates an illusion of depth and motion by moving multiple layers of the background at different speeds. This effect gives the scene more dimension and a dynamic feel, often used to enhance visual appeal and create a more immersive user experience.

![Parallax Scrolling Example](images/Parallax%20Scrolling.gif)

- The following code demonstrates basic methods to implement parallax scrolling in SplashKit.
```cpp
#include "splashkit.h"

// Define the background layer structure
struct background_layer {
    bitmap image;
    float parallax_speed;
};

// Render backgrounds with parallax scrolling effect
void render_backgrounds(camera &game_camera, vector<background_layer> &layers) {
    for (background_layer &layer : layers) {
        float parallax_offset = game_camera.x * layer.parallax_speed;
        draw_bitmap(layer.image, -parallax_offset, 0);
    }
}

int main() {
    open_window("Metroidvania Game", 800, 600);
    camera game_camera = create_camera();

    // Set up background layers
    vector<background_layer> layers = {
        { load_bitmap("background_far", "images/background_far.png"), 0.5 },
        { load_bitmap("background_near", "images/background_near.png"), 1.0 }
    };

    while (not quit_requested()) {
        process_events();
        clear_screen(COLOR_WHITE);
        render_backgrounds(game_camera, layers);
        // Update and draw characters, etc...
        refresh_screen();
    }
    return 0;
}
```
[Example of Parallax Scrolling Video](https://www.youtube.com/watch?v=z9tBce8eFqE&t=94s)

## Conclusion
By implementing lazy camera movement and parallax scrolling, you add a significant degree of polish and depth to your 2D "Metroidvania" game. These techniques create a more dynamic and engaging player experience and are staples in modern 2D game design. Experiment with different movement speeds and layering to achieve the desired visual effect for your game.