using static SplashKitSDK.SplashKit;
using static SplashKitSDK.KeyCode;
using SplashKitSDK;


int windowX = 960;
int windowY = 480;

int startingX = windowX / 2;
int startingY = windowY / 2;

int score = 0;
int highscore = 0;

double gravity = 0.1;

uint frameRate = 60;

//seconds multiplied by framerate
double frames = 0.5 * frameRate;
double rectX = startingX;
double rectY = startingY;
double velocityX = 0;
double velocityY = 0;
bool moving = false;

OpenWindow("Volley", windowX, windowY);

//main game loop
while (!KeyTyped(EscapeKey) && !QuitRequested()){

ProcessEvents();

//sets velocity when mouse is clicked
if (MouseClicked(MouseButton.LeftButton))
{
    SetVelocity();
    score++;
}

ClearScreen(ColorWhite());

//draws rectangles
FillRectangle(ColorBlue(), 0, windowY - 120, windowX, 120);
FillRectangle(ColorGreen(), rectX, rectY, 20, 20);
DrawText("Score: " + score.ToString(), ColorBlack(), 5, 5);
DrawText("High Score: " + highscore.ToString(), ColorBlack(), 5, 20);

UpdateRectangle();
CheckCollision();
CheckWindow();

RefreshScreen(frameRate);
}

//checks if rectangles collide
void CheckCollision()
{
    Rectangle rectangle = RectangleFrom(0, windowY - 120, windowX, 120);
    Rectangle rectangle2 = RectangleFrom(rectX, rectY, 20, 20);
    if (RectanglesIntersect(rectangle, rectangle2))
    {
        resetGame();
    }
}

//checks that rectangle is still inside window, if not, resets game
void CheckWindow()
{
Window window = WindowNamed("Volley");
Rectangle rectangle = RectangleFrom(rectX, rectY, 20, 20);
if (!RectInWindow(window, rectangle))
{
    resetGame();
}
}

//resets rectangle to starting position and resets score
void resetGame()
{
    rectX = startingX;
    rectY = startingY;
    velocityX = 0;
    velocityY = 0;
    moving = false;
    if (score > highscore)
    {
            highscore = score;
    }
    score = 0;  
}



//Updates coordinates of rectangle based on velocity. Only applies gravity if the rectangle is moving.
//Velocity and gravity are subtracted so that rectangle moves away from mouse instead of towards
void UpdateRectangle()
{
    if (moving)
    {
    velocityY = velocityY - gravity;
    }

    rectX = rectX - velocityX;
    rectY = rectY - velocityY;

}

//if rectangle is not already moving, sets the velocity based on the mouse position
void SetVelocity(){
        moving = true;
        double distanceX = MouseX() - rectX;
        double distanceY = MouseY() - rectY;

        //pixels per frame
        velocityX = distanceX / frames;
        velocityY = distanceY / frames;
}




