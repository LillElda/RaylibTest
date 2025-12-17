using Raylib_cs;
using System.Numerics;
class Objects
{
    protected Rectangle rect;
    Animation _currentAnimation;
    public Objects(string pictureOfObject, Vector2 pos, Vector2 size)
    {
        Animation _backgroundAn = new Animation(pictureOfObject, (int)size.X);

        rect = new(pos.X, pos.Y, size.X, size.Y);
        _currentAnimation = _backgroundAn;
    }
    public void Draw()
    {
        //Raylib.DrawTextureRec(objectlook, rect, position, Color.Blank);To draw object without animation
        _currentAnimation.ShowFrame();
        _currentAnimation.Draw(rect.Position, true);
    }

}

class Quests
{
    int boxX = 50;
    int boxY = 880;
    int boxWidth = 1200 - 100;
    int boxHeight = 100;
    static string[] dialogueLines = new string[] { };
    protected int currentLine = 0;
    protected string displayedText = "";
    public virtual void Textloop()
    {
        if (Raylib.IsKeyPressed(KeyboardKey.Space))
        {displayedText = dialogueLines[currentLine];}
    }
    

    public void Draw()
    {
        Raylib.DrawRectangleLines(boxX, boxY, boxWidth, boxHeight, Color.White);
        Raylib.DrawRectangle(boxX, boxY, boxWidth, boxHeight, Color.Black);
        Raylib.DrawText(displayedText, 90, 900, 20, Color.White);
    }
}


