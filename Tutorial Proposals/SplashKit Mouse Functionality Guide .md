
# SplashKit Mouse Functionality Guide

## Introduction

**Purpose of the Guide**: This guide aims to provide a comprehensive understanding of mouse functionality within SplashKit. Mouse interaction is fundamental for creating interactive applications and games, and mastering mouse handling in SplashKit is essential for developers.

**Overview of SplashKit's Mouse Functions**: SplashKit offers a range of functions to manage mouse input effectively, allowing developers to detect clicks, track movement, and interact with graphical elements seamlessly.

## Mouse Button Enumeration

**What is Mouse Button?**

Mouse Button is an enumeration used by SplashKit to read inputs from the mouse. Understanding how to handle mouse buttons is crucial for developers who want users to control their programs using the mouse.

**List of Mouse Buttons**

| Name              | Description             |
|-------------------|-------------------------|
| `NO_BUTTON`       | No mouse button         |
| `LEFT_BUTTON`     | The left mouse button   |
| `MIDDLE_BUTTON`   | The middle mouse button |
| `RIGHT_BUTTON`    | The right mouse button  |
| `MOUSE_X1_BUTTON` | The x1 mouse button     |
| `MOUSE_X2_BUTTON` | The x2 mouse button     |

## Handling Mouse Button Inputs

### Mouse Clicked

The `mouse_clicked` function checks if the specified Mouse Button has been clicked since the last time `process_events` was called.

**Syntax in C++:**

```cpp
bool mouse_clicked(mouse_button button);
```

### Mouse Down

The `mouse_down` function checks if the specified button is being held down.

**Syntax in C++:**

```cpp
bool mouse_down(mouse_button button);
```

### Mouse Up

The `mouse_up` function checks if the specified button is released.

**Syntax in C++:**

```cpp
bool mouse_up(mouse_button button);
```

## Example: Handling Mouse Button Inputs

This example demonstrates how to change the screen color based on the state of the left mouse button.

```cpp
int main()
{
    open_window("Mouse Input Example", 800, 600);

    while(!key_down(ESCAPE_KEY))
    {
        process_events(); // check mouse state

        if (mouse_clicked(LEFT_BUTTON)) // check if left mouse button is clicked
        {
            clear_screen(COLOR_RED);
        }
        else if (mouse_down(LEFT_BUTTON)) // check if left mouse button is pressed down
        {
            clear_screen(COLOR_YELLOW);
        }
        else if (mouse_up(LEFT_BUTTON)) // check if left mouse button is released
        {
            clear_screen(COLOR_GREEN);
        }

        refresh_screen(60);
    }

    return 0;
}
```

## Mouse Movement

### Mouse Movement

The `mouse_movement` function returns the amount of accumulated mouse movement since the last time `process_events` was called. It returns a `vector_2d` showing the direction and distance in the x and y scale.

**Syntax in C++:**

```cpp
vector_2d mouse_movement();
```

### Mouse Wheel Scroll

The `mouse_wheel_scroll` function returns the distance and direction of the mouse scroll since the last time `process_events` was called. It also returns a `vector_2d`.

**Syntax in C++:**

```cpp
vector_2d mouse_wheel_scroll();
```

## Example: Reading Mouse Movement

This example shows how to track and display mouse movement and scroll.

```cpp
int main()
{
    vector_2d movement;
    vector_2d scroll;

    open_window("Mouse Movement Example", 800, 600);

    while(!key_down(ESCAPE_KEY))
    {
        clear_screen(COLOR_BLACK);

        process_events(); // check mouse state

        movement = mouse_movement(); // get mouse movement
        scroll = mouse_wheel_scroll(); // get mouse wheel scroll

        draw_text("Mouse moved: " + vector_to_string(movement), COLOR_WHITE, 100, 300);
        draw_text("Mouse wheel scrolled: " + vector_to_string(scroll), COLOR_WHITE, 100, 400);

        refresh_screen(60);
    }

    return 0;
}
```

## Mouse Position

### Mouse Position

The `mouse_position` function returns the position of the mouse in the current window as a `point_2d`.

**Syntax in C++:**

```cpp
point_2d mouse_position();
```

### Mouse Position Vector

The `mouse_position_vector` function returns the position of the mouse relative to the window origin as a `vector_2d`.

**Syntax in C++:**

```cpp
vector_2d mouse_position_vector();
```

### Mouse X

The `mouse_x` function returns a float of the distance of the mouse from the left edge of the window.

**Syntax in C++:**

```cpp
float mouse_x();
```

### Mouse Y

The `mouse_y` function returns a float of the distance of the mouse from the top edge of the window.

**Syntax in C++:**

```cpp
float mouse_y();
```

### Move Mouse

The `move_mouse` function moves the cursor to a specified location. It has two versions: one with x and y parameters, and one with a `point_2d` parameter.

**Syntax in C++:**

```cpp
void move_mouse(double x, double y);
void move_mouse(point_2d point);
```

## Example: Moving the Mouse

This example demonstrates moving the mouse cursor 10 pixels from its current position when the left mouse button is clicked.

```cpp
void move_10_points()
{
    double current_x = mouse_x(); // get current x position
    double current_y = mouse_y(); // get current y position

    move_mouse(current_x + 10, current_y + 10); // move cursor 10 points
}

int main()
{
    open_window("Mouse Move Example", 800, 600);

    while(!key_down(ESCAPE_KEY))
    {
        process_events(); // check mouse state

        if (mouse_clicked(LEFT_BUTTON))
        {
            move_10_points(); // move cursor on click
        }

        refresh_screen(60);
    }

    return 0;
}
```

## Mouse Visibility

### Hide Mouse

The `hide_mouse` function hides the mouse cursor from the screen.

**Syntax in C++:**

```cpp
void hide_mouse();
```

### Show Mouse

The `show_mouse` function has two versions: one to show the mouse cursor and another to show or hide the mouse based on a boolean parameter.

**Syntax in C++:**

```cpp
void show_mouse();
void show_mouse(bool show);
```

### Mouse Shown

The `mouse_shown` function checks if the mouse is currently visible.

**Syntax in C++:**

```cpp
bool mouse_shown();
```

## Example: Controlling Mouse Visibility

This example demonstrates how to hide and show the mouse cursor based on the right mouse button click.

```cpp
int main()
{
    open_window("Mouse Visibility Example", 800, 600);

    while(!key_down(ESCAPE_KEY))
    {
        process_events(); // check mouse state

        if (mouse_clicked(RIGHT_BUTTON))
        {
            if (mouse_shown())
            {
                hide_mouse(); // hide cursor
            }
            else
            {
                show_mouse(); // show cursor
            }
        }

        refresh_screen(60);
    }

    return 0;
}
```

## Conclusion

This guide has covered the basics of handling mouse inputs in SplashKit, from detecting mouse clicks, tracking movements, getting and setting positions, to controlling visibility. Understanding these functions will help you create more interactive and responsive applications using SplashKit.
