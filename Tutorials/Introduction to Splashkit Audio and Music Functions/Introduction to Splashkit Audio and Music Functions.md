---
title: Introduction to Music Functions in SplashKit
---

## Introduction

This tutorial aims to equip you with the skills necessary to enhance your games or applications with immersive audio experiences. We'll explore a variety of functions for loading, playing, and manipulating music tracks in SplashKit.

## Prerequisites

- Basic understanding of programming concepts.
- Proficiency in C++.
- A configured IDE for C++ development, like Visual Studio Code.
- SplashKit framework installed. Refer to the [SplashKit installation guide](https://splashkit.io/installation/).

## Example: Playing and Controlling Music

Let's start with a complete example that demonstrates how to load, play, pause, resume, and control the volume of music in SplashKit.

```cpp
#include "splashkit.h"

// Function to manage music playback
void manage_music()
{
    // Load background music
    music background_music = load_music("background", "path/to/background.mp3");

    // Play the background music continuously
    play_music(background_music, -1, 0.5); // -1 for looping indefinitely, volume set to 50%

    // Main loop
    while (!window_close_requested("Music Example"))
    {
        process_events();

        if (key_typed(SPACE_KEY))
        {
            // Pause or resume the music when space is pressed
            if (music_paused())
            {
                resume_music();
            }
            else
            {
                pause_music();
            }
        }

        if (key_typed(UP_KEY))
        {
            // Increase volume
            set_music_volume(min(get_music_volume() + 0.1, 1.0));
        }

        if (key_typed(DOWN_KEY))
        {
            // Decrease volume
            set_music_volume(max(get_music_volume() - 0.1, 0.0));
        }

        delay(100);  // Brief delay to avoid spamming input
    }

    // Stop and free the music resource before exiting
    stop_music();
    free_music(background_music);
}

// Main function
int main()
{
    open_window("Music Example", 800, 600);

    // Ensure the audio system is ready
    if (!audio_ready())
    {
        open_audio();
    }

    // Call the function to manage music
    manage_music();

    // Close the audio system
    close_audio();

    return 0;
}
```

## Breaking Down

### Ensuring Audio System Readiness

Before attempting to play audio, check the system's readiness with the `audio_ready` function. If the audio system is not ready, you should open it using `open_audio`.

```cpp
if (!audio_ready())
{
    open_audio();
}
```

### Loading and Playing Music

First, we load the background music using the load_music function. This ensures that the audio resource is available when needed.

```cpp
music background_music = load_music("background", "path/to/background.mp3");
```

Next, we play the background music continuously using the `play_music` function.

```cpp
play_music(background_music, -1, 0.5); // -1 for looping indefinitely, volume set to 50%
```

### Main Loop

The main loop runs until the window is closed. Inside this loop, we process events and check if specific keys are pressed to control the music playback and volume.

```cpp
while (!window_close_requested("Music Example"))
{
    process_events();

    if (key_typed(SPACE_KEY))
    {
        // Pause or resume the music when space is pressed
        if (music_paused())
        {
            resume_music();
        }
        else
        {
            pause_music();
        }
    }

    if (key_typed(UP_KEY))
    {
        // Increase volume
        set_music_volume(min(get_music_volume() + 0.1, 1.0));
    }

    if (key_typed(DOWN_KEY))
    {
        // Decrease volume
        set_music_volume(max(get_music_volume() - 0.1, 0.0));
    }

    delay(100);  // Brief delay to avoid spamming input
}
```

- `process_events()` handles any pending events (e.g., keyboard input, window close requests).
- `key_typed(KEY)` checks if a specific key was pressed.
- `music_paused()` checks if the music is currently paused.
- `pause_music()` pauses the currently playing music.
- `resume_music()` resumes the paused music.
- `set_music_volume(volume)` sets the volume of the currently playing music.
- `get_music_volume()` gets the current volume of the playing music.
- `delay(milliseconds)` adds a brief delay to avoid spamming input.

### Stopping and Freeing Music

After exiting the main loop (when the window is closed), we stop the music and free the music resource to clean up.

```cpp
stop_music();
free_music(background_music);
```

### Main Function

The `main` function sets up the window, ensures the audio system is ready, calls the `manage_music` function to execute the music management logic, and finally closes the audio system.

```cpp
int main()
{
    open_window("Music Example", 800, 600);

    // Ensure the audio system is ready
    if (!audio_ready())
    {
        open_audio();
    }

    // Call the function to manage music
    manage_music();

    // Close the audio system
    close_audio();

    return 0;
}
```

## Conclusion

Through this tutorial, you have learned how to effectively utilize audio and music functions within the SplashKit framework. From loading and playing music to adjusting volume and creating smooth audio transitions, these skills are crucial for crafting engaging experiences in games and applications.

You have acquired the know-how to control music playback, including pausing, resuming, and stopping tracks, as well as implementing volume adjustments and fade-in/fade-out effects in your projects. These capabilities not only enhance the user experience but also add dynamic audio feedback to games and applications.

The focus of this tutorial was to provide practical examples and clear guidance to help you apply these concepts to your real-world projects. Whether you are a novice in game development or an experienced application developer, these skills can be leveraged to elevate your creations.

As you advance your skills in SplashKit's audio functionalities, we encourage you to continue exploring and experimenting to discover more creative applications. Remember, audio is a key element in enhancing the immersion of games and applications, and its effective use can make a significant impact.
