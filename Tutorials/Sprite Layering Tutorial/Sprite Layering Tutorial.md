# Tutorial: Sprite Layering
In this tutorial, we are going to cover the concept of sprite layering. Before we get dive into it let's look at what does layering mean. Before we dive into it, let's first understand what layering means. Think of layers like sheets of paper stacked on top of each other. In short, layering involves stacking 'layers' on top of each other to achieve the desired result.
Here's an example of layering looks like:
[I Made the PERFECT 3D Pokémon Cards!!! by Jazza](https://www.youtube.com/watch?app=desktop&v=JCfpVvy5Rhs)
## Apply the method to Splashkit sprite
To demonstrate this, we are going to create a simple move around program which uses 4 custom made sprite images. Those 4 images represent 4 sided face:
```
LEFT
RIGHT
TOP
BOTTOM
```
Firstly we load those 4 images as bitmap:
```cpp
bitmap front_image = load_bitmap("face_front", "face_front.png");
bitmap back_image = load_bitmap("face_back", "face_back.png");
bitmap left_image = load_bitmap("face_left", "face_left.png");
bitmap right_image = load_bitmap("face_right", "face_right.png");
```

Then we create a sprite call Y_face which is basically just yellow face and add the 4 layers for the sprite:
```cpp
sprite Yellow_face = create_sprite("Y_face",front_image);
sprite_add_layer(Yellow_face, back_image ,"back");
sprite_add_layer(Yellow_face, front_image ,"front");
sprite_add_layer(Yellow_face, left_image ,"left");
sprite_add_layer(Yellow_face, right_image ,"right");
```
Now we create a enumeration and a function call `face_swap()` which is a function to swap layers when we press the arrow key to move around(Note: you can do it in other ways if you feel like to, this is just a way to make the explaination easier):
```cpp
enum  face{
	FRONT,
	BACK,
	LEFT,
	RIGHT
};

void  face_swap(sprite  Yellow_face, int  face){
	switch(face){

	case FRONT:
		sprite_show_layer(Yellow_face, "front");
		sprite_hide_layer(Yellow_face, "back");
		sprite_hide_layer(Yellow_face, "left");
		sprite_hide_layer(Yellow_face, "right");
		break;

	case BACK:
		sprite_hide_layer(Yellow_face, "front");
		sprite_show_layer(Yellow_face, "back");
		sprite_hide_layer(Yellow_face, "left");
		sprite_hide_layer(Yellow_face, "right");
		break;

	case LEFT:
		sprite_hide_layer(Yellow_face, "right");
		sprite_show_layer(Yellow_face, "left");
		sprite_hide_layer(Yellow_face, "front");
		sprite_hide_layer(Yellow_face, "back");
		break;

	case RIGHT:
		sprite_hide_layer(Yellow_face, "left");
		sprite_show_layer(Yellow_face, "right");
		sprite_hide_layer(Yellow_face, "front");
		sprite_hide_layer(Yellow_face, "back");
		break;
	}

}
```
`sprite_hide_layer`: Hides the layer
`sprite_show_layer`: Shows the layer

Now we declare the enumeration:
```cpp
face  face;

// those code below are optional
// because my image files are too small I have to do this 
double  x = 100;
double  y = 100;

sprite_set_scale(Yellow_face, 5);
```
Next in our loop function, we character movement through the arrow key:
```cpp
while (!quit_requested()){

	process_events();

	if (key_down(UP_KEY)){
		face = BACK;
		y -= 0.1; // Move up by decreasing the y-coordinate
	
	}else  if (key_down(DOWN_KEY)){
		face = FRONT;
		y += 0.1; // Move down by increasing the y-coordinate

	}else  if (key_down(LEFT_KEY)){
		face = LEFT;
		x -= 0.1; // Move left by decreasing the x-coordinate

	}else  if (key_down(RIGHT_KEY)){
		face = RIGHT;
		x += 0.1; // Move right by increasing the x-coordinate
	}
	
	face_swap(Yellow_face, face);
	clear_screen(COLOR_WHITE);
	draw_sprite(Yellow_face, x, y);
	refresh_screen();
}
```
That's all the code implementation, here's the result:

https://github.com/MangoS9/SplashKit-Tutorial/assets/128771372/1ff549f6-2207-41f9-bb06-d47bf9b2f1d5


