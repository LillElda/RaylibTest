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
        { displayedText = dialogueLines[currentLine]; }
    }


    public void Draw()
    {
        Raylib.DrawRectangleLines(boxX, boxY, boxWidth, boxHeight, Color.White);
        Raylib.DrawRectangle(boxX, boxY, boxWidth, boxHeight, Color.Black);
        Raylib.DrawText(displayedText, 90, 900, 20, Color.White);
    }
}
class World_events
{
    public Objects background1 = new Objects("backgroundStart -spritesheet.png", new(0, 0), new(1200, 1000));
    public Objects background2 = new Objects("background2.png", new(0, 0), new(1200, 1000));
    public Objects background3 = new Objects("BackgroundRacoon.png", new(0, 0), new(1200, 1000));
    public Objects background4 = new Objects("BackgroundStup.png", new(0, 0), new(1200, 1000));
    public Objects currentbackground;
    public Cat_quest1 quest1 = new();
    Rat _rat;
    Cat _cat;


    public World_events(Rat rat, Cat cat)
    {

        _rat = rat;
        _cat = cat;
        currentbackground = background1; /// IF TESTING CHANGE BG TO JUMP IN STORY
    }
    public void Rat_move_screen()
    {//////////// Extreme mess. If rat moves to right out of screen:
        if (_rat.rect.X > 1200)
        {
            _rat.rect.X = 0;
            if (currentbackground == background1) { currentbackground = background2; }
            else if (currentbackground == background2) { currentbackground = background4; }
            //else if (currentbackground == background2) { currentbackground = background3; }

        }
        // If rat moves left out of screen
        else if (_rat.rect.X < 0)
        {
            _rat.rect.X = 1190;
            if (currentbackground == background2) { currentbackground = background1; }
        }
        ////////////////For scene 3 only:
        if (currentbackground == background2 && _rat.rect.X > 680 && _rat.rect.X < 850)
        {
            if (Raylib.IsKeyPressed(KeyboardKey.Space))
            {
                currentbackground = background3;
            }
        }

        else if (currentbackground == background3)
        {
            if (_rat.rect.X < 300) { _rat.rect.X = 300; }
            else if (_rat.rect.X > 700) { _rat.rect.X = 700; }
            if (Raylib.IsKeyPressed(KeyboardKey.Space)) { currentbackground = background2; }
        }
        /// /////////For scene 4 only:
        if (currentbackground == background4 && _rat.rect.X > 780)
        {
            Console.WriteLine("Noo my guy he is falling");
        }
    }
    /// <summary>
    
    
    /// </summary>
    ////////////////////////////////////End of weird loop check.
    public void Check_collition()
    {
        if (currentbackground == background1)
        {
            if (Raylib.CheckCollisionRecs(_rat.rect, _cat.rect))
            {
                quest1.Textloop();
                quest1.Draw();
            }
        }
    }
}



