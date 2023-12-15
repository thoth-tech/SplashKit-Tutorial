# Proposal for SplashKit JSON Functionality Tutorial Series
## Overview
This proposal outlines a series of tutorials focused on the JSON functionality in SplashKit. While an existing tutorial introduces the basic concepts, there's a significant opportunity to expand this into a more comprehensive learning experience. This series will cater to both beginners and intermediate users, aiming to provide a thorough understanding of handling JSON in SplashKit.

## Part 1: Introduction to JSON in SplashKit
### Introduction to JSON
JSON (JavaScript Object Notation) is a lightweight data-interchange format. It is easy for humans to read and write, and for machines to parse and generate. JSON is often used in various programming environments, including game development, for data storage and configuration.
In SplashKit, JSON functionality allows developers to efficiently manage game settings, level data, and more. This part of the tutorial introduces JSON and its basic structure, followed by an overview of its application in SplashKit.

### What is JSON?
- **Format**: 
  JSON is a text format that is completely language-independent but uses conventions familiar to programmers of the C-family of languages, including C++, C#, Java, JavaScript, and many others.
- **Structure**: 
  JSON is built on two structures:
  - A collection of name/value pairs. In various languages, this is realized as an object, record, struct, dictionary, hash table, keyed list, or associative array.
  - An ordered list of values. In most languages, this is realized as an array, vector, list, or sequence.

### Basic Structure of a JSON File
A simple JSON file might look like this:
```
{
  "gameTitle": "Metroidvania Adventures",
  "screenSize": {
    "width": 800,
    "height": 600
  },
  "levels": ["level1", "level2", "level3"]
}
```
In this example, **gameTitle** is a string, **screenSize** is an object with two numeric values (width and height), and levels is an array of strings.

### Overview of JSON in SplashKit
SplashKit simplifies the process of working with JSON files in your games. Whether you need to load game configurations, save player progress, or manage game assets, SplashKit's JSON functionality makes these tasks straightforward.

### Key Features:
- **Reading JSON**: SplashKit allows you to easily read values from a JSON file, helping you load configurations or game data.
- **Writing JSON**: You can also create and modify JSON data, then save it back to a file, which is useful for saving game states or player preferences.

### Getting Started with JSON in SplashKit
To begin using JSON in SplashKit, you need to understand how to include the necessary SplashKit libraries in your project. Here's a simple way to start:
- 1. Include SplashKit Library:
`#include "splashkit.h"`
- 2. Load a JSON File:
`json game_data = load_json("game_data.json");`
- 3. Accessing Data:
```
string title = json_read_string(game_data, "gameTitle");
int width = json_read_int(game_data, "screenSize.width");
```
In the next part of this tutorial, we will delve deeper into reading JSON data, demonstrating how to navigate through JSON objects and arrays to extract various types of data. Stay tuned!

## Part 2: Reading JSON Data in SplashKit
### Introduction to Reading JSON Data
After understanding the basics of JSON in SplashKit, this part of the tutorial focuses on how to read and parse JSON data. Reading JSON data is essential for game development tasks such as loading game settings, level configurations, or player data.

### Loading a JSON File in SplashKit
To work with JSON in SplashKit, the first step is to load the JSON file. SplashKit provides functions to easily handle this.

Example: Loading a JSON File
```
#include "splashkit.h"

int main() {
    json game_data;

    // Load the JSON file
    game_data = load_json("game_data.json");

    // Ensure the JSON file is loaded
    if (json_is_invalid(game_data)) {
        write_line("Failed to load game data.");
        return -1;
    }

    // Proceed with reading data...
}
```

In this example, **load_json** is used to load the JSON file named **"game_data.json"**. After loading, it's good practice to check if the JSON data is valid using **json_is_invalid**.

### Navigating Through JSON Objects and Arrays
JSON data is often structured as a combination of objects and arrays. Understanding how to navigate through this structure is key to effectively using JSON in your games.

### Accessing Simple Values
To access simple values like strings, numbers, or booleans, you can use functions like **json_read_string**, **json_read_int**, or **json_read_bool**.
```
string title = json_read_string(game_data, "gameTitle");
int width = json_read_int(game_data, "screenSize.width");
bool isFullScreen = json_read_bool(game_data, "fullScreenMode");
```

### Working with JSON Arrays
If the data is an array, you can loop through the array using **json_read_array_length** and **json_read_string** (or other similar functions).
```
int level_count = json_read_array_length(game_data, "levels");
for (int i = 0; i < level_count; i++) {
    string level_name = json_read_string(game_data, "levels[" + to_string(i) + "]");
    // Process each level name...
}
```

### Extracting Different Data Types
SplashKit's JSON functionality allows you to extract various types of data, including strings, integers, floats, booleans, and even nested JSON objects.

Example: Extracting Nested Data
```
json settings = json_read_object(game_data, "settings");
int volume = json_read_int(settings, "volume");
```

In this example, **json_read_object** is used to extract a nested JSON object, and then values are read from this nested object.

### Conclusion
Reading JSON data with SplashKit is a straightforward process that can greatly enhance the flexibility and functionality of your game. It enables dynamic loading of game content and configurations, making your game more adaptable and easier to manage.

In the next part of this tutorial, we will explore how to write and modify JSON data, allowing you to save game states, configurations, and player preferences.

## Part 3: Writing JSON Data in SplashKit
### Introduction to Writing JSON Data
Having covered how to read JSON data in SplashKit, this part of the tutorial will focus on creating and writing data to JSON files. This functionality is crucial for features like saving game settings, player progress, or dynamically modifying game content.

### Creating JSON Objects and Arrays
In SplashKit, you can programmatically create JSON objects and arrays, which then can be populated with data.

Example: Creating a New JSON Object
```
#include "splashkit.h"

int main() {
    // Create a new JSON object
    json new_game_data = create_json();

    // Add data to the JSON object
    json_add_string(new_game_data, "gameTitle", "Metroidvania Adventure");
    json_add_number(new_game_data, "playerHealth", 100);
    
    // Create a JSON array
    json levels_array = create_json_array();

    // Add items to the JSON array
    json_add_to_array(levels_array, create_json_string("level1"));
    json_add_to_array(levels_array, create_json_string("level2"));

    // Add the array to the JSON object
    json_add_array(new_game_data, "levels", levels_array);

    // Proceed with saving the JSON object...
}
```
In this example, **create_json** is used to create a new JSON object, and **create_json_array** to create a new JSON array. Data is then added to these structures using functions like **json_add_string**, **json_add_number**, and **json_add_to_array**.

### Writing JSON Data to a File
After creating and populating a JSON object or array, you can write the data to a file. This is useful for saving configurations or game states.

Example: Saving JSON to a File
```
// Save the JSON object to a file
save_json(new_game_data, "new_game_data.json");

// Free the JSON object
free_json(new_game_data);
```
In this example, **save_json** is used to write the JSON data to a file named **"new_game_data.json"**. After saving, it's a good practice to free the JSON object from memory using **free_json**.

### Modifying Existing JSON Data
You can also load an existing JSON file, modify its contents, and save the changes back to the file.

Example: Modifying and Saving Existing JSON Data
```
// Load existing JSON data
json existing_data = load_json("existing_game_data.json");

// Modify the data
json_add_number(existing_data, "playerScore", 500); // Add or update player score

// Save the changes
save_json(existing_data, "existing_game_data.json");

// Free the JSON object
free_json(existing_data);
```
In this example, an existing JSON file is loaded, modified, and then the changes are saved back to the same file.

### Conclusion
Writing and modifying JSON data in SplashKit enables developers to manage dynamic game content efficiently. This powerful feature enhances the game's interactivity and provides a mechanism for storing player data and game settings.

In the next part of this tutorial, we'll provide practical examples of using JSON in game development, such as managing game settings and player preferences.

## Part 4: Practical Example - Game Settings Using JSON in SplashKit
### Introduction
This section of the tutorial will demonstrate a practical application of JSON in SplashKit for managing game settings. We'll create a simple system to load, modify, and save game settings, such as screen resolution, sound volume, and more.

### Step 1: Creating the Game Settings JSON File
First, we'll create a JSON file named **game_settings.json** that contains some basic settings for the game.
```
{
    "screen": {
        "width": 800,
        "height": 600,
        "fullscreen": false
    },
    "audio": {
        "musicVolume": 70,
        "sfxVolume": 80
    }
}
```
This file includes settings for screen dimensions, fullscreen mode, and audio volumes.

### Step 2: Reading Game Settings
Next, we'll write code to load these settings when the game starts.

Example: Loading Game Settings
```
#include "splashkit.h"

json load_game_settings(const string &filename) {
    json settings = load_json(filename);
    if (json_is_invalid(settings)) {
        write_line("Failed to load settings.");
        exit(-1);
    }
    return settings;
}

void apply_settings(const json &settings) {
    // Apply screen settings
    int width = json_read_int(settings, "screen.width");
    int height = json_read_int(settings, "screen.height");
    bool fullscreen = json_read_bool(settings, "screen.fullscreen");
    set_window_size(width, height);
    set_window_fullscreen(fullscreen);

    // Apply audio settings
    int musicVolume = json_read_int(settings, "audio.musicVolume");
    int sfxVolume = json_read_int(settings, "audio.sfxVolume");
    // Code to set audio levels...
}

int main() {
    open_window("Metroidvania Adventure", 800, 600);
    json settings = load_game_settings("game_settings.json");
    apply_settings(settings);
    // Rest of the game loop...
}
```
In this example, the settings are loaded from **game_settings.json**, and then applied using **apply_settings**.

### Step 3: Modifying and Saving Settings
Let's add the functionality to modify and save these settings, perhaps from an in-game settings menu.

Example: Modifying and Saving Settings
```
void update_and_save_settings(json &settings, const string &filename) {
    // Update settings based on user input (e.g., from a settings menu)
    json_write_number(settings, "audio.musicVolume", newMusicVolume);
    json_write_number(settings, "audio.sfxVolume", newSfxVolume);

    // Save the updated settings
    save_json(settings, filename);
}
```
In this example, the **update_and_save_settings** function is used to update and save the settings, which can be triggered from an in-game settings menu.

### Conclusion
Using JSON for game settings in SplashKit allows for a flexible and dynamic configuration system. By storing settings in a JSON file, they can be easily modified and persisted across game sessions, enhancing the user experience.

In the final part of this tutorial, we will explore advanced JSON manipulation and use cases in game development.

## Part 5: Part 5: Advanced Techniques with JSON in SplashKit
### Introduction
After exploring the basics of reading and writing JSON data, and a practical example of using JSON for game settings, this final part of the tutorial series delves into advanced techniques of JSON manipulation in SplashKit. These techniques can be invaluable for managing complex data structures in your game development process.

### Working with Nested JSON Objects
Often, JSON data structures can be deeply nested. Understanding how to navigate and manipulate these nested structures is crucial for complex game development scenarios.

Example: Accessing Nested Data
Consider a JSON structure representing a character with nested attributes:
```
{
    "character": {
        "name": "Hero",
        "stats": {
            "health": 100,
            "mana": 50,
            "strength": 75
        }
    }
}
```
Accessing nested attributes like the character's health can be done as follows:
```
json game_data = load_json("game_data.json");
int health = json_read_int(game_data, "character.stats.health");
```

### Error Handling and Debugging JSON
Proper error handling is essential when working with JSON to ensure your game behaves as expected even when encountering malformed or unexpected data.

Example: Robust JSON Reading
```
if (json_has_key(game_data, "character.stats.health")) {
    int health = json_read_int(game_data, "character.stats.health");
} else {
    write_line("Health data is missing");
}
```
Here, **json_has_key** is used to check if the health data is present before attempting to read it, preventing potential errors.

### Conclusion
Mastering advanced JSON techniques in SplashKit opens up a myriad of possibilities for game development, enabling more dynamic, flexible, and complex game designs. This tutorial series has equipped you with the knowledge to effectively utilize JSON in your game projects, from basic operations to advanced applications.

