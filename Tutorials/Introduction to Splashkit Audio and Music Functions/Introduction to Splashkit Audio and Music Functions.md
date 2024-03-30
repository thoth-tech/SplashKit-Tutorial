<<<<<<< Updated upstream
---
title: Introduction to Music Functions in SplashKit
---
=======
# Introduction to Splashkit Audio and Music Functions
>>>>>>> Stashed changes

## Introduction

This tutorial aims to equip you with the skills necessary to enhance your games or applications with immersive audio experiences. We'll explore a variety of functions for loading, playing, and manipulating music tracks in Splashkit.

## Prerequisites

- Basic understanding of programming concepts.
- Proficiency in C++ or C#.
- A configured IDE for C++ or C# development, like Visual Studio Code.
- SplashKit framework installed. Refer to the [SplashKit installation guide](https://splashkit.io/installation/).

<<<<<<< Updated upstream
## Part I: Understanding Splashkit’s Music Management

### Overview

SplashKit's music management system offers a dedicated framework designed specifically for handling music in game and application development. It simplifies the process of integrating immersive musical experiences into your projects, providing robust support for loading, playing, pausing, and controlling music tracks.

### Key Features

=======
## Part I: Understanding Splashkit’s Audio System

### Overview

Splashkit's audio system offers a comprehensive framework for audio processing in game and application development. It enables developers to easily incorporate rich audio experiences into their projects, supporting the loading, playing, and controlling of music and sound effects.

### Key Features

>>>>>>> Stashed changes
The primary audio functionalities of the system include:

- Playback Control: Play, pause, resume, and stop music.
- Volume Adjustment: Adjust the volume level of audio files.

<<<<<<< Updated upstream
### Format Considerations

=======
### Supported Formats

Splashkit supports various common audio file formats, including but not limited to MP3 and WAV.

### Format Considerations

>>>>>>> Stashed changes
- MP3: Suitable for longer music files with smaller file sizes but may compromise some sound quality.
- WAV: Provides higher sound quality, ideal for sound effects and short music clips, but with larger file sizes.

## Part II: Loading and Playing Music

### Loading and Playing Music

- Load and play music with the option to loop and specify volume:

```cpp
music background_music = load_music("background", "path/to/background.mp3");
play_music(background_music, -1, 0.5); // -1 for looping indefinitely, 1 for looping only once
```

- Pause, resume, and stop music, ensuring resources are freed when no longer needed:

```cpp
// To pause the music
pause_music();
// To resume music
resume_music();
// Stop and free music resource
stop_music(background_music);
free_music(background_music); // Always remember to free resources
```

### Advanced Playback Control

Control playback based on game events, like playing victory or defeat music:

```cpp
if (player_wins) {
    play_music(victory_music, 1, 0.5); // Play once at 50% volume
} else if (player_loses) {
    play_music(defeat_music, 1, 0.5); // Play once at 50% volume
}
```

## Part III: Controlling Music Volume

### Dynamic Volume Adjustment

Adjusting music volume in real-time, perhaps in response to an in-game event or user settings:

```cpp
// Adjust the volume to 50%
set_music_volume(0.5);
```

### Fading Music In and Out

Smooth transitions using fading effects for scene changes:

```cpp
// Fade out current music over 2 seconds
fade_music_out(current_music, 2000);

// Wait for the fade to complete
delay(2000);

// Load the next track
music next_track = load_music("next_scene_music", "next_scene.mp3");

// Fade in next music over 3 seconds
fade_music_in(next_track, 3000);
```

## Code Examples

### A simple example demonstrates loading and playing a music file

```cpp
#include "splashkit.h"

int main() {
    // Initialize SplashKit
    open_window("Audio Example", 800, 600);
    
    // Load and play background music
    music track = load_music("my_music", "background.mp3");
    play_music(track);
    
    // The loop and other functionalities code
    
    // Stop and free the music resource before exiting code

    return 0;
}
```

### Here is an example for the pause feature

```cpp
#include "splashkit.h"

// Assume this is your game loop or similar function
void game_loop()
{
    bool game_paused = false; // A variable to track whether the game is paused

    // Load background music code

    // Start playing the background music code

    while (not quit_requested())
    {
        // Process game events code

        // Check if the game is paused
        if (key_typed(SPACE_KEY)) // Assuming the space key is used to pause and resume the game
        {
            game_paused = !game_paused; // Toggle the game pause state

            if (game_paused)
            {
                // Pause the music
                pause_music();
            }
            else
            {
                // Resume the music
                resume_music();
            }
        }

        // Game update and render code...
    }
}
```

## Conclusion

Through this tutorial, you have learned how to effectively utilize audio and music functions within the SplashKit framework. From loading and playing music to adjusting volume and creating smooth audio transitions, these skills are crucial for crafting engaging experiences in games and applications.

You have acquired the know-how to control music playback, including pausing, resuming, and stopping tracks, as well as implementing volume adjustments and fade-in/fade-out effects in your projects. These capabilities not only enhance the user experience but also add dynamic audio feedback to games and applications.

The focus of this tutorial was to provide practical examples and clear guidance to help you apply these concepts to your real-world projects. Whether you are a novice in game development or an experienced application developer, these skills can be leveraged to elevate your creations.

As you advance your skills in SplashKit's audio functionalities, we encourage you to continue exploring and experimenting to discover more creative applications. Remember, audio is a key element in enhancing the immersion of games and applications, and its effective use can make a significant impact.
