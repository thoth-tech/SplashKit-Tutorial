using static SplashKitSDK.SplashKit;
using static SplashKitSDK.KeyCode;
using SplashKitSDK;


int windowX = 960;
int windowY = 480;

double gravity = 0.1;

uint frameRate = 60;

//seconds multiplied by framerate
double frames = 1 * frameRate;
double rectX = 100;
double rectY = windowY - 75;
double velocityX = 0;
double velocityY = 0;
bool moving = false;

OpenWindow("Flick", windowX, windowY);

//main game loop
while (!KeyTyped(EscapeKey) && !QuitRequested() && !CheckCollision()){

ProcessEvents();

//sets velocity when mouse is clicked
if (MouseClicked(MouseButton.LeftButton))
{
    SetVelocity();
}

ClearScreen(ColorWhite());

//draws the rectangle and triangle
FillTriangle(ColorRed(), windowX - 100, windowY - 100, windowX - 125, windowY - 50, windowX - 75, windowY - 50);
FillRectangle(ColorPurple(), rectX, rectY, 20, 20);

UpdateRectangle();
CheckCollision();
CheckWindow();

RefreshScreen(frameRate);
}



bool CheckCollision()
{
    Triangle triangle = TriangleFrom(windowX - 100, windowY - 100, windowX - 125, windowY - 50, windowX - 75, windowY - 50);
    Rectangle rectangle = RectangleFrom(rectX, rectY, 20, 20);
    if (TriangleRectangleIntersect(triangle, rectangle))
    {
        return true;
    }
    return false;
}

//check that rectangle is still in window, otherwise reset to starting values
void CheckWindow()
{
Window window = WindowNamed("Flick");
Rectangle rectangle = RectangleFrom(rectX, rectY, 20, 20);
if (!RectInWindow(window, rectangle))
{
    rectX = 100;
    rectY = windowY - 75;
    velocityX = 0;
    velocityY = 0;
    moving = false;
}
}


//Updates coordinates of rectangle based on velocity. Only applies gravity if the rectangle is moving
void UpdateRectangle()
{
    
    if (moving == true)
    {
        velocityY = velocityY + gravity;
    }

    rectX = rectX + velocityX;
    rectY = rectY + velocityY;

}

//if rectangle is not already moving, sets the velocity based on the mouse position
void SetVelocity(){
    if (!moving){
        moving = true;
        double distanceX = MouseX() - rectX;
        double distanceY = MouseY() - rectY;

        //pixels per frame
        velocityX = distanceX / frames;
        velocityY = distanceY / frames;
}
}



