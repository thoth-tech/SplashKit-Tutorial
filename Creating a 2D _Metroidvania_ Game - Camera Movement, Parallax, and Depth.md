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
    - Keep track of the character's position using a point_2d or similar structure.
    - Implement character movement logic allowing them to move freely within a defined central area of the screen.

2. Camera Logic:
    - Determine the boundaries within which the character can move without moving the camera. This can be a rectangle in the center of the screen.
    - When the character moves beyond these boundaries, adjust the camera's position to follow the character.

3. Updating Camera Position:
    - In your game loop, update the camera position based on the character's position.
    - Ensure the camera movement is smooth and follows the character's movement at the edges of the screen.
    ```cpp
    void update_camera_position(character &player, camera &game_camera) {
    // Define the central area where the camera doesn't move
    rectangle central_area = ...; // Define the central area

    // Check if the character is outside the central area
    if (!rectangle_contains(central_area, player.position)) {
        // Adjust the camera position to follow the character
        game_camera.x = ...; // Logic to update camera x-coordinate
        game_camera.y = ...; // Logic to update camera y-coordinate
        }
    }
    ```

[Example of Lazy Character Movement](https://www.youtube.com/watch?app=desktop&v=ZYZkLe0r0aY)

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
    ```cpp
    void render_backgrounds(camera &game_camera) {
    for (background_layer &layer : background_layers) {
        // Calculate the background's position based on the camera position and layer speed
        float parallax_offset = game_camera.x * layer.parallax_speed;
        draw_bitmap(layer.image, layer.x - parallax_offset, layer.y);
        }
    }
    ```
    In this example, **background_layers** is a collection of background layers, each with its own image, position, and **parallax_speed**.

[Example of Parallax Scrolling](https://www.youtube.com/watch?v=z9tBce8eFqE&t=94s)

## Conclusion
By implementing lazy camera movement and parallax scrolling, you add a significant degree of polish and depth to your 2D "Metroidvania" game. These techniques create a more dynamic and engaging player experience and are staples in modern 2D game design. Experiment with different movement speeds and layering to achieve the desired visual effect for your game.