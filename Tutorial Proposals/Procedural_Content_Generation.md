# Procedural Content Generation

## Introduction

**Purpose of the Guide**: This guide aims to provide a detailed understanding of procedural content generation in SplashKit. Procedural generation allows developers to create vast, dynamic game environments.

**Overview of Procedural Generation in SplashKit**: SplashKit provides various functions to generate random and procedural content, such as terrains, maps, and dungeons.

## Generating Random Terrains

### What is Random Terrain Generation?

Random terrain generation involves creating landscapes with varying heights and features. This method can be used to create unique game worlds without manually designing each one.

**Syntax in C++:**

```cpp
bitmap generate_random_terrain(int width, int height);
```

**Example: Random Terrain Generation**

```cpp
#include "splashkit.h"

bitmap generate_random_terrain(int width, int height)
{
    bitmap terrain = create_bitmap("terrain", width, height);
    for (int x = 0; x < width; x++)
    {
        for (int y = 0; y < height; y++)
        {
            float value = rnd();
            color pixel_color = (value > 0.5) ? COLOR_GREEN : COLOR_BLUE;
            set_pixel_color(pixel_color, terrain, x, y);
        }
    }
    return terrain;
}

void draw_random_terrain()
{
    bitmap terrain = generate_random_terrain(800, 600);
    draw_bitmap(terrain, 0, 0);
}

int main()
{
    open_window("Random Terrain", 800, 600);

    while (!key_down(ESCAPE_KEY))
    {
        process_events();
        clear_screen(COLOR_WHITE);
        draw_random_terrain();
        refresh_screen(60);
    }

    return 0;
}
```

## Generating Procedural Dungeons

### What is Procedural Dungeon Generation?

Procedural dungeon generation involves creating maze-like structures with rooms and corridors. This method can be used to create varied and interesting game levels.

**Syntax in C++:**

```cpp
bitmap generate_procedural_dungeon(int width, int height);
```

**Example: Procedural Dungeon Generation**

```cpp
#include "splashkit.h"

bitmap generate_procedural_dungeon(int width, int height)
{
    bitmap dungeon = create_bitmap("dungeon", width, height);
    for (int x = 0; x < width; x++)
    {
        for (int y = 0; y < height; y++)
        {
            if (rnd() > 0.7)
            {
                set_pixel_color(COLOR_BLACK, dungeon, x, y);
            }
            else
            {
                set_pixel_color(COLOR_WHITE, dungeon, x, y);
            }
        }
    }
    return dungeon;
}

void draw_procedural_dungeon()
{
    bitmap dungeon = generate_procedural_dungeon(800, 600);
    draw_bitmap(dungeon, 0, 0);
}

int main()
{
    open_window("Procedural Dungeon", 800, 600);

    while (!key_down(ESCAPE_KEY))
    {
        process_events();
        clear_screen(COLOR_WHITE);
        draw_procedural_dungeon();
        refresh_screen(60);
    }

    return 0;
}
```

## Using Noise Functions

### What are Noise Functions?

Noise functions generate pseudo-random values that can be used to create natural-looking environments. Perlin noise is a popular type of noise function used in procedural generation.

**Syntax in C++:**

```cpp
float perlin_noise(float x, float y);
```

**Example: Using Perlin Noise for Terrain Generation**

```cpp
#include "splashkit.h"

bitmap generate_perlin_terrain(int width, int height)
{
    bitmap terrain = create_bitmap("terrain", width, height);
    for (int x = 0; x < width; x++)
    {
        for (int y = 0; y < height; y++)
        {
            float value = perlin_noise(x * 0.1, y * 0.1);
            color pixel_color = (value > 0.5) ? COLOR_GREEN : COLOR_BLUE;
            set_pixel_color(pixel_color, terrain, x, y);
        }
    }
    return terrain;
}

void draw_perlin_terrain()
{
    bitmap terrain = generate_perlin_terrain(800, 600);
    draw_bitmap(terrain, 0, 0);
}

int main()
{
    open_window("Perlin Terrain", 800, 600);

    while (!key_down(ESCAPE_KEY))
    {
        process_events();
        clear_screen(COLOR_WHITE);
        draw_perlin_terrain();
        refresh_screen(60);
    }

    return 0;
}
```

## Example: Generating a Procedurally Generated World

This example demonstrates how to generate a procedurally generated world using noise functions and random terrain generation.

```cpp
#include "splashkit.h"

bitmap generate_procedural_world(int width, int height)
{
    bitmap world = create_bitmap("world", width, height);
    for (int x = 0; x < width; x++)
    {
        for (int y = 0; y < height; y++)
        {
            float value = perlin_noise(x * 0.1, y * 0.1);
            color pixel_color = (value > 0.5) ? COLOR_GREEN : COLOR_BLUE;
            set_pixel_color(pixel_color, world, x, y);
        }
    }
    return world;
}

void draw_procedural_world()
{
    bitmap world = generate_procedural_world(800, 600);
    draw_bitmap(world, 0, 0);
}

int main()
{
    open_window("Procedural World", 800, 600);

    while (!key_down(ESCAPE_KEY))
    {
        process_events();
        clear_screen(COLOR_WHITE);
        draw_procedural_world();
        refresh_screen(60);
    }

    return 0;
}
```

## Conclusion

This guide has covered procedural content generation in SplashKit, from generating random terrains and procedural dungeons to using noise functions. Understanding these techniques will help you create dynamic and expansive game environments.