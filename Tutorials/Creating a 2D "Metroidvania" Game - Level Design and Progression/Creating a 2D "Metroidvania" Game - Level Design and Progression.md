# Creating a 2D "Metroidvania" Game - Level Design and Progression
## Introduction
In this tutorial, we will explore implementing level design and progression in a 2D "Metroidvania" style game using the SplashKit library. These features are essential for creating a game environment that is both challenging and exploratory.

## Level Structure: Level Design Principles for a "Metroidvania" Game
### Implementing Level Design Principles
1. Level Layout:
- Track the player character's position using a sprite structure.
- Implement logic for the character to move freely within a defined central area of the screen.

2. Level Elements and Challenges:
- Design levels that contain puzzles and challenges, requiring players to use newly acquired skills or tools to unlock new areas.

Here is an example from the game **Castlevania: Symphony of the Night**. The protagonist needs to acquire the ability to turn into mist to pass through certain areas.
![Example of Level Design](images/level.gif)

The following code shows basic methods for implementing level design principles in SplashKit.

```cpp
#include "splashkit.h"

// Define the level structure
struct level {
    vector<sprite> obstacles;
    // More level elements...
};

// Initialize the level
level create_level() {
    level new_level;
    // Load obstacles, enemies, etc...
    return new_level;
}

// Update level state
void update_level(level &current_level) {
    // Handle level logic...
}

int main() {
    open_window("Metroidvania Game", 800, 600);
    level game_level = create_level();

    while (not quit_requested()) {
        process_events();
        update_level(game_level);
        // Render level...
        refresh_screen();
    }
    return 0;
}
```

## Using JSON Resources to Define Levels and Layouts
### Implementing JSON Resources
Levels and Layouts:
- Use JSON files to define the layout, enemy placements, and item locations of levels.
- Load and parse JSON files in the game to create dynamic levels.

Here is an example.
If the JSON file has data like:
```cpp
{
    "platforms": [
        {"x": 100, "y": 150, "width": 200, "height": 20},
        {"x": 350, "y": 200, "width": 150, "height": 20}
    ],
    "enemies": [
        {"type": "flying", "x": 400, "y": 100},
        {"type": "ground", "x": 200, "y": 140}
    ],
    ...
}
```
The corresponding in-game screenshot should show a level where platforms are placed at the specified x and y coordinates with the given dimensions, and enemies are located where the JSON file places them.

And the following code shows basic methods for implementing the use of JSON resources in SplashKit.
```cpp
#include "splashkit.h"
#include "json.h"

// Load level from JSON
level load_level_from_json(string filename) {
    json level_data = load_json(filename);
    level new_level;
    // Parse JSON data to set up the level...
    return new_level;
}

int main() {
    open_window("Metroidvania Game", 800, 600);
    level game_level = load_level_from_json("levels/level1.json");

    while (not quit_requested()) {
        process_events();
        // Game logic...
        refresh_screen();
    }
    return 0;
}
```

## Area Transitions: Implementing Smooth Transitions Between Areas
### Implementing Area Transitions
Transition Logic:
- Design logic for smooth transitions between different areas in the game.
- Use SplashKit functionalities to handle the logic of moving the character from one area to another.

Here is an example from the game **Hollow Knight**. 
![Example of Area Transitions](images/Transitions.gif)

The following code shows basic methods for implementing area transitions in SplashKit.
```cpp
#include "splashkit.h"

// Define the area transition function
void transition_to_area(character &player, string new_area) {
    // Handle area transition logic...
}

int main() {
    open_window("Metroidvania Game", 800, 600);
    character player = create_character();

    while (not quit_requested()) {
        process_events();
        // Detect and handle area transitions...
        refresh_screen();
    }
    return 0;
}
```

## Conclusion
By implementing effective level design, using JSON resources, and smooth area transitions, you add significant layers and depth to your 2D "Metroidvania" game. These techniques create a more dynamic and engaging player experience and are key elements in modern 2D game design. Experiment with different movement speeds and layering to achieve the desired visual effect for your game.