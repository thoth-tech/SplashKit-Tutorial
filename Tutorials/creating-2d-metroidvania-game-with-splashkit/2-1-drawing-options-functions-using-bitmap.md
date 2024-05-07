---
title: "Drawing Options functions using DrawBitmap"
description: Learn how to use drawing options functions in Splashkit and combine them to create dynamic and visually stunning graphics.
author: Sharvani Kandala
date: 05/05/2024
tags: programming, graphics, Splashkit, tutorials
sidebar: 
   label: " -2-1 Drawing Options Functions using Bitmap"
---

## Window Setup

To begin utilizing drawing options functions in Splashkit, set up the game window as follows:

1. Import the necessary Splashkit headers at the beginning of your code:

   ```cpp
   #include "splashkit.h"
   ```
1. In the `main` function, configure the game window and any necessary resources:

   ```cpp
    int main()
    {
       open_window("Advanced Drawing", 800, 600);
       load_resource_bundle("game_resources", "r");
       return 0;
    }
    ```
## Drawing Options Functions

## Example 1: Applying Option Part Bmp:

In this example, we'll demonstrate how to use 'Option Part Bmp' to draw a section of a bitmap, effectively cropping the image.

# Function Syntax:

 ```cpp
 void draw_bitmap(bitmap bmp, double x, double y, drawing_options opts);
 ```

 - `bmp`: The bitmap to draw.
 - `x`: The x-coordinate for the top-left corner of the bitmap.
 - `y`: The y-coordinate for the top-left corner of the bitmap.
 - `opts`: Drawing options to apply.

1. **Example Usage:**

   For instance, draw a window with dimensions of `800` pixels width and `600` pixels height. Here is the code snippet where we load a bitmap and applies 'Option Part Bmp' to draw only a 
   100x100 region of it at coordinates (100, 100). The function `load_resource_bundle` loads a resource bundle named `game_resources` from the specified folder `resource_folder`.
   Resource bundles typically contain images, sounds, and other assets used in the game.`bitmap bmp` loads a bitmap image named `my_bitmap` from the file `Resources/images/bitmap.png`.
   The bitmap is stored in the variable bmp for later use.

   ```cpp
   int main()
    {
       open_window("Drawing", 800, 600);
       load_resource_bundle("game_resources", "resource_folder");

       bitmap bmp = load_bitmap("my_bitmap", "Resources/images/bitmap.png");
       drawing_options opts = option_part_bmp(0, 0, 100, 100);

       draw_bitmap(bmp, 100, 100, opts);

       delay(5000); // Pause for observation

       close_all_windows();
       return 0;
    }

## Example 2: Applying Option Rotate Bmp:

In this example, we'll showcase how to use 'Option Rotate Bmp' to dynamically rotate a bitmap at different angles.

# Function Syntax:

 ```cpp
  drawing_options option_rotate_bmp(double degrees);
 ```

 - `degrees`: The angle of rotation in degrees.
 

2. **Example Usage:**

   In this code snippet, a window titled `Drawing` is initialized with dimensions of `800` pixels in width and `600` pixels in height using the open_window function. Then, a resource bundle named `game_resources` is loaded from the directory specified using the `load_resource_bundle` function. Next, a bitmap named `my_bitmap` is loaded from the file path `Resources/images/bitmap.png` using the load_bitmap function. Drawing options are applied to rotate the bitmap by `45 degrees` using the option_rotate_bmp function. Finally, the rotated bitmap is drawn onto the initialized window at coordinates (100, 100) using the draw_bitmap function. 

   ```cpp
   int main()
    {
       open_window("Drawing", 800, 600);
       load_resource_bundle("game_resources", "resource_folder");

       bitmap bmp = load_bitmap("my_bitmap", "Resources/images/bitmap.png");
       drawing_options opts = option_rotate_bmp(45);

       draw_bitmap(bmp, 100, 100, opts);

       delay(5000);

       close_all_windows();
       return 0;
    }

## Example 3: Applying Option Scale Bmp:

In this example, we'll illustrate how to use 'Option Scale Bmp' to scale a bitmap to a desired size while maintaining its aspect ratio.

# Function Syntax:

 ```cpp
  drawing_options option_scale_bmp(double scale_x, double scale_y);
 ```

 - `scale_x`: Scaling factor for the x-axis.
   `scale_y`: Scaling factor for the y-axis.
 

3. **Example Usage:**

   In this code snippet, a window titled `Drawing` is initialized with dimensions of `800` pixels in width and `600` pixels in height using the open_window function. Then, a resource bundle named `game_resources` is loaded from the directory specified using the load_resource_bundle function. Next, a bitmap named `my_bitmap` is loaded from the file path `Resources/images/bitmap.png` using the load_bitmap function. Drawing options are applied to scale the bitmap to `150%` of its original size using the `option_scale_bmp` function. Finally, the scaled bitmap is drawn onto the initialized window at coordinates (100, 100) using the `draw_bitmap` function. 

   ```cpp
   int main()
    {
       open_window("Drawing", 800, 600);
       load_resource_bundle("game_resources", "resource_folder");

       bitmap bmp = load_bitmap("my_bitmap", "Resources/images/bitmap.png");
       drawing_options opts = option_scale_bmp(1.5, 1.5);

       draw_bitmap(bmp, 100, 100, opts);

       delay(5000);

       close_all_windows();
       return 0;
    }

## Example 4: Combining Options:

In this example, we'll combine drawing option functions to create dynamic animations with depth.

4. **Example Usage:**

   In this code snippet, a window titled `Drawing` is initialized with dimensions of `800` pixels in width and `600` pixels in height using the `open_window` function. Then, a resource bundle named `game_resources` is loaded from the directory specified using the load_resource_bundle function. Next, a bitmap named `my_bitmap` is loaded from the file path `Resources/images/bitmap.png` using the load_bitmap function. Two sets of drawing options are created: `opts_rotate` applies a rotation of 45 degrees to the bitmap using the `option_rotate_bmp` function, while `opts_scale` scales the bitmap to 150% of its original size using the `option_scale_bmp` function. Finally, the bitmap is drawn twice onto the initialized window at coordinates (100, 100) and (200, 200) using the draw_bitmap function, with the rotation and scaling effects applied accordingly.

   ```cpp
   int main()
    {
       open_window("Drawing", 800, 600);
       load_resource_bundle("game_resources", "resource_folder");

       bitmap bmp = load_bitmap("my_bitmap", "Resources/images/bitmap.png");
       drawing_options opts_rotate = option_rotate_bmp(45);
       drawing_options opts_scale = option_scale_bmp(1.5, 1.5);

       // Combine rotation and scaling effects
       draw_bitmap(bmp, 100, 100, opts_rotate);
       draw_bitmap(bmp, 200, 200, opts_scale);

       delay(5000);

       close_all_windows();
       return 0;
    }

**Conclusion:**

By mastering these drawing options in Splashkit, you can elevate your graphics programming skills and create visually stunning experiences. Experiment with these functions to unleash your creativity and bring your projects to life.

