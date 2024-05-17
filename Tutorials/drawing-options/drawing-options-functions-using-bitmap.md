---
title: "Drawing Options functions using DrawBitmap"
description: Learn how to use drawing options functions in Splashkit and combine them to create dynamic and visually stunning graphics.
author: Sharvani Kandala
date: 05/05/2024
tags: programming, graphics, Splashkit, tutorials.
---

## Window Setup

To begin utilizing drawing options functions in Splashkit, set up the game window as follows:

1. Import the necessary Splashkit headers at the beginning of your code:

   ```cpp
   #include "splashkit.h"
   ```

2. In the `main` function, configure the game window:

   ```cpp
    int main()
    {
       open_window("Drawing", 800, 600);
       return 0;
    }
    ```

3. Function to Draw the Bitmap:

   ```cpp
   void draw_bitmap(bitmap bmp, double x, double y, drawing_options opts);
   ```

- `bmp`: The bitmap to draw.
- `x`: The x-coordinate for the top-left corner of the bitmap.
- `y`: The y-coordinate for the top-left corner of the bitmap.
- `opts`: Drawing options to apply.

## Drawing Options Functions

## Example 1: Applying Option Part Bmp

In this example, we'll demonstrate how to use 'Option Part Bmp' to draw a section of a bitmap, effectively cropping the image.

1. **Function Syntax:**

 ```cpp
  drawing_options option_part_bmp(int x, int y, int width, int height);
```

- `x`: The x-coordinate for the top-left corner of the part of the bitmap to draw.
- `y`: The y-coordinate for the top-left corner of the part of the bitmap to draw.
- `width`: The width of the part of the bitmap to draw.
- `height`: The height of the part of the bitmap to draw.

1. **Example Usage:**

   For instance, draw a window with dimensions of `800` pixels width and `600` pixels height. Here is the code snippet where we load a bitmap and applies 'Option Part Bmp' to draw only a 100x100 region of it at coordinates (100, 100).`bitmap bmp` loads a bitmap image named `my_bitmap` from the file `bitmap.png`. The bitmap is stored in the variable bmp for later use.

   ```cpp
   #include "spalshkit.h"
   int main()
    {
       open_window("Drawing", 800, 600);

       bitmap bmp = load_bitmap("my_bitmap", "bitmap.png");
       drawing_options opts = option_part_bmp(0, 0, 100, 100);

       draw_bitmap(bmp, 100, 100, opts);

       delay(5000); // Pause for observation

       close_all_windows();
       return 0;
    }

## Example 2: Applying Option Rotate Bmp

In this example, we'll showcase how to use 'Option Rotate Bmp' to dynamically rotate a bitmap at different angles.

1. **Function Syntax:**

 ```cpp
  drawing_options option_rotate_bmp(double degrees);
 ```

- `degrees`: The angle of rotation in degrees.

1. **Example Usage:**

   In this code snippet, a window titled `Drawing` is initialized with dimensions of `800` pixels in width and `600` pixels in height using the open_window function. Next, a bitmap named `my_bitmap` is loaded from the file path `bitmap.png` using the load_bitmap function. Drawing options are applied to rotate the bitmap by `90 degrees clockwise` using the `option_rotate_bmp` function. Finally, the rotated bitmap is drawn onto the initialized window at coordinates (100, 100) using the `draw_bitmap` function.

   ```cpp
   #include "spalshkit.h"
   int main()
    {
       open_window("Drawing", 800, 600);
       
       bitmap bmp = load_bitmap("my_bitmap", "bitmap.png");
       drawing_options opts = option_rotate_bmp(90);

       draw_bitmap(bmp, 100, 100, opts);

       delay(5000);

       close_all_windows();
       return 0;
    }

## Example 3: Applying Option Scale Bmp

In this example, we'll illustrate how to use 'Option Scale Bmp' to scale a bitmap to a desired size while maintaining its aspect ratio.

1. **Function Syntax:**

 ```cpp
  drawing_options option_scale_bmp(double scale_x, double scale_y);
 ```

- `scale_x`: Scaling factor for the x-axis.
  `scale_y`: Scaling factor for the y-axis.

1. **Example Usage:**

   In this code snippet, a window titled `Drawing` is initialized with dimensions of `800` pixels in width and `600` pixels in height using the open_window function. Next, a bitmap named `my_bitmap` is loaded from the file path `bitmap.png` using the load_bitmap function. Drawing options are applied to scale the bitmap to `150%` of its original size using the `option_scale_bmp` function. Finally, the scaled bitmap is drawn onto the initialized window at coordinates (100, 100) using the `draw_bitmap` function.

   ```cpp
   #include "spalshkit.h"
   int main()
    {
       open_window("Drawing", 800, 600);
       
       bitmap bmp = load_bitmap("my_bitmap", "bitmap.png");
       drawing_options opts = option_scale_bmp(1.5, 1.5);

       draw_bitmap(bmp, 100, 100, opts);

       delay(5000);

       close_all_windows();
       return 0;
    }

## Example 4: Combining Options

In this example, we'll combine drawing option functions to create dynamic animations with depth.

1. **Example Usage:**

   In this code snippet, a window titled `Drawing` is initialized with dimensions of `800` pixels in width and `600` pixels in height using the `open_window` function. Next, a bitmap named `my_bitmap` is loaded from the file path `bitmap.png` using the load_bitmap function. Three sets of drawing options are created: `opts_rotate` applies a rotation of 90 degrees to the bitmap using the `option_rotate_bmp` function, `opts_scale` scales the bitmap to 150% of its original size using the `option_scale_bmp` function, and `opts_part` draws a part of the bitmap using the `option_part_bmp` function. Finally, the bitmap is drawn three times onto the initialized window at coordinates (100, 100), (200, 200), and (300, 300) using the `draw_bitmap` function, with the rotation, scaling, and partial drawing effects applied accordingly.

   ```cpp
   #include "spalshkit.h"
   int main()
    {
       open_window("Drawing", 800, 600);
       
       bitmap bmp = load_bitmap("my_bitmap", "bitmap.png");
       drawing_options opts_rotate = option_rotate_bmp(45);
       drawing_options opts_scale = option_scale_bmp(1.5, 1.5);
       drawing_options opts_part = option_part_bmp(50, 50, 200, 200);
       // Combine all the three effects
       draw_bitmap(bmp, 100, 100, opts_rotate);
       draw_bitmap(bmp, 200, 200, opts_scale);
       draw_bitmap(bmp, 300, 300, opts_part);

       delay(5000);

       close_all_windows();
       return 0;
    }

## Conclusion

By mastering these drawing options in Splashkit, you can elevate your graphics programming skills and create visually stunning experiences. Experiment with these functions to unleash your creativity and bring your projects to life.
