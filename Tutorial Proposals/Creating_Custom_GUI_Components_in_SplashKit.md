# Creating Custom GUI Components in SplashKit

## Introduction

**Purpose of the Guide**: This guide aims to provide an in-depth understanding of designing and implementing custom graphical user interface (GUI) components such as buttons, sliders, and text fields using SplashKit.

**Overview of SplashKit's GUI Functions**: SplashKit provides basic functions for drawing shapes and handling input, which can be combined to create custom GUI components.

## Designing Custom Buttons

### What is a Custom Button?

A custom button is a GUI component that reacts to user input, such as mouse clicks, by performing an action or changing its appearance.

**Syntax in C++:**

```cpp
void draw_button(const rectangle& rect, const string& text, const color& fill_color, const color& text_color);
bool is_button_clicked(const rectangle& rect);
```

**Example: Creating and Using a Custom Button**

```cpp
#include "splashkit.h"

void draw_button(const rectangle& rect, const string& text, const color& fill_color, const color& text_color)
{
    fill_rectangle(fill_color, rect);
    draw_text(text, text_color, rect.x + 10, rect.y + 10);
}

bool is_button_clicked(const rectangle& rect)
{
    return mouse_clicked(LEFT_BUTTON) && point_in_rectangle(mouse_position(), rect);
}

int main()
{
    open_window("Custom Button", 800, 600);
    rectangle button_rect = {350, 275, 100, 50};

    while (!key_down(ESCAPE_KEY))
    {
        process_events();
        clear_screen(COLOR_WHITE);

        draw_button(button_rect, "Click Me", COLOR_BLUE, COLOR_WHITE);

        if (is_button_clicked(button_rect))
        {
            write_line("Button Clicked!");
        }

        refresh_screen(60);
    }

    return 0;
}
```

## Implementing Sliders

### What is a Slider?

A slider is a GUI component that allows the user to select a value from a range by dragging a handle along a track.

**Syntax in C++:**

```cpp
void draw_slider(const rectangle& track, double value, const color& track_color, const color& handle_color);
double get_slider_value(const rectangle& track);
```

**Example: Creating and Using a Slider**

```cpp
#include "splashkit.h"

void draw_slider(const rectangle& track, double value, const color& track_color, const color& handle_color)
{
    fill_rectangle(track_color, track);
    double handle_x = track.x + value * track.width;
    fill_rectangle(handle_color, {handle_x - 5, track.y - 5, 10, track.height + 10});
}

double get_slider_value(const rectangle& track)
{
    double mouse_x = mouse_position().x;
    return (mouse_x - track.x) / track.width;
}

int main()
{
    open_window("Custom Slider", 800, 600);
    rectangle slider_track = {100, 200, 600, 20};
    double slider_value = 0.5;

    while (!key_down(ESCAPE_KEY))
    {
        process_events();
        clear_screen(COLOR_WHITE);

        draw_slider(slider_track, slider_value, COLOR_GRAY, COLOR_RED);

        if (mouse_down(LEFT_BUTTON) && point_in_rectangle(mouse_position(), slider_track))
        {
            slider_value = get_slider_value(slider_track);
            write_line("Slider Value: " + to_string(slider_value));
        }

        refresh_screen(60);
    }

    return 0;
}
```

## Creating Interactive Text Fields

### What is a Text Field?

A text field is a GUI component that allows the user to input and edit text.

**Syntax in C++:**

```cpp
void draw_text_field(const rectangle& rect, const string& text, const color& border_color, const color& text_color);
bool is_text_field_active(const rectangle& rect);
string handle_text_input(const string& current_text);
```

**Example: Creating and Using a Text Field**

```cpp
#include "splashkit.h"

void draw_text_field(const rectangle& rect, const string& text, const color& border_color, const color& text_color)
{
    draw_rectangle(border_color, rect);
    draw_text(text, text_color, rect.x + 5, rect.y + 5);
}

bool is_text_field_active(const rectangle& rect)
{
    return mouse_clicked(LEFT_BUTTON) && point_in_rectangle(mouse_position(), rect);
}

string handle_text_input(const string& current_text)
{
    string result = current_text;
    for (int i = 0; i < key_typed_count(); i++)
    {
        char c = key_typed(i);
        if (c == BACKSPACE_KEY)
        {
            if (!result.empty()) result.pop_back();
        }
        else
        {
            result += c;
        }
    }
    return result;
}

int main()
{
    open_window("Custom Text Field", 800, 600);
    rectangle text_field_rect = {300, 250, 200, 30};
    string text = "";
    bool active = false;

    while (!key_down(ESCAPE_KEY))
    {
        process_events();
        clear_screen(COLOR_WHITE);

        draw_text_field(text_field_rect, text, COLOR_BLACK, COLOR_BLACK);

        if (is_text_field_active(text_field_rect))
        {
            active = true;
        }
        else if (mouse_clicked(LEFT_BUTTON))
        {
            active = false;
        }

        if (active)
        {
            text = handle_text_input(text);
        }

        refresh_screen(60);
    }

    return 0;
}
```

## Conclusion

This guide has covered the creation of custom GUI components in SplashKit, including buttons, sliders, and text fields. By understanding these techniques, you can create interactive and user-friendly interfaces for your applications.