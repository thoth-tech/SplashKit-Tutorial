# Advanced Collision Detection Techniques

## Introduction

**Purpose of the Guide**: This guide aims to provide an in-depth understanding of advanced collision detection techniques in SplashKit. Accurate collision detection is crucial for creating realistic and engaging games.

**Overview of SplashKit's Collision Functions**: SplashKit provides several functions to manage collision detection, including bounding box, bounding circle, and pixel-perfect collision methods.

## Bounding Box Collision

### What is Bounding Box Collision?

Bounding box collision detection involves checking if the rectangular bounds of two objects overlap. This method is simple and efficient, making it suitable for many applications.

**Syntax in C++:**

```cpp

bool bounding_box_collision(const rectangle& rect1, const rectangle& rect2);

```

**Example: Bounding Box Collision Detection**

```cpp

#include "splashkit.h"

bool bounding_box_collision(const rectangle& rect1, const rectangle& rect2)

{

    return rect1.x < rect2.x + rect2.width &&

           rect1.x + rect1.width > rect2.x &&

           rect1.y < rect2.y + rect2.height &&

           rect1.y + rect1.height > rect2.y;

}

void check_bounding_box_collision()

{

    rectangle player = {mouse_x(), mouse_y(), 50, 50};

    rectangle enemy = {400, 300, 50, 50};

    if (bounding_box_collision(player, enemy))

    {

        write_line("Bounding Box Collision Detected");

    }

}

```

## Bounding Circle Collision

### What is Bounding Circle Collision?

Bounding circle collision detection involves checking if the circular bounds of two objects overlap. This method is useful for circular objects and provides a smoother collision boundary than bounding boxes.

**Syntax in C++:**

```cpp

bool bounding_circle_collision(const circle& circ1, const circle& circ2);

```

**Example: Bounding Circle Collision Detection**

```cpp

#include "splashkit.h"

bool bounding_circle_collision(const circle& circ1, const circle& circ2)

{

    float dx = circ1.center.x - circ2.center.x;

    float dy = circ1.center.y - circ2.center.y;

    float distance = sqrt(dx * dx + dy * dy);

    return distance < (circ1.radius + circ2.radius);

}

void check_bounding_circle_collision()

{

    circle player = {point_at(mouse_x(), mouse_y()), 25};

    circle enemy = {point_at(400, 300), 25};

    if (bounding_circle_collision(player, enemy))

    {

        write_line("Bounding Circle Collision Detected");

    }

}

```

## Pixel-Perfect Collision

### What is Pixel-Perfect Collision?

Pixel-perfect collision detection involves checking if the actual pixels of two objects overlap. This method is the most accurate but also the most computationally expensive.

**Syntax in C++:**

```cpp

bool pixel_perfect_collision(const bitmap& bmp1, const bitmap& bmp2, int x1, int y1, int x2, int y2);

```

**Example: Pixel-Perfect Collision Detection**

```cpp

#include "splashkit.h"

bool pixel_perfect_collision(const bitmap& bmp1, const bitmap& bmp2, int x1, int y1, int x2, int y2)

{

    for (int x = 0; x < bmp1.width(); x++)

    {

        for (int y = 0; y < bmp1.height(); y++)

        {

            if (bitmap_cell_bitmap(bmp1, x, y) == COLOR_WHITE && bitmap_cell_bitmap(bmp2, x + x2 - x1, y + y2 - y1) == COLOR_WHITE)

            {

                return true;

            }

        }

    }

    return false;

}

void check_pixel_perfect_collision()

{

    bitmap player_bitmap = load_bitmap("player", "player.png");

    bitmap enemy_bitmap = load_bitmap("enemy", "enemy.png");

    int player_x = mouse_x();

    int player_y = mouse_y();

    int enemy_x = 400;

    int enemy_y = 300;

    if (pixel_perfect_collision(player_bitmap, enemy_bitmap, player_x, player_y, enemy_x, enemy_y))

    {

        write_line("Pixel-Perfect Collision Detected");

    }

}

```

## Example: Implementing Collision Detection in a Platformer

This example demonstrates how to implement bounding box, bounding circle, and pixel-perfect collision detection in a platformer game.

```cpp

#include "splashkit.h"

void check_collisions()

{

    rectangle player = {mouse_x(), mouse_y(), 50, 50};

    circle enemy = {point_at(400, 300), 25};

    bitmap player_bitmap = load_bitmap("player", "player.png");

    bitmap enemy_bitmap = load_bitmap("enemy", "enemy.png");

    if (bounding_box_collision(player, player))

    {

        write_line("Bounding Box Collision Detected");

    }

    if (bounding_circle_collision(enemy, enemy))

    {

        write_line("Bounding Circle Collision Detected");

    }

    if (pixel_perfect_collision(player_bitmap, enemy_bitmap, player.x, player.y, enemy.center.x, enemy.center.y))

    {

        write_line("Pixel-Perfect Collision Detected");

    }

}

int main()

{

    open_window("Collision Detection", 800, 600);

    while (!key_down(ESCAPE_KEY))

    {

        process_events();

        clear_screen(COLOR_WHITE);

        check_collisions();

        refresh_screen(60);

    }

    return 0;

}

```

## Conclusion

This guide has covered advanced collision detection techniques in SplashKit, including bounding box, bounding circle, and pixel-perfect methods. Understanding these techniques will help you create more accurate and engaging game interactions.