using Raylib_cs;
using System.Numerics;

class Cat : Character
{
    string _sprite_idle = "pixilart-sprite-cat (1).png";

    public Cat(string sprite, Vector2 pos) : base("pixilart-sprite-cat (1).png", pos)
    {

        _idle = new Animation(_sprite_idle, 32);
        offset = new(-80, -100);
        rect.Height = 320 - 100; //How much size it should be
        rect.Width = 320 - 100;

    }
    public override void Draw()
    {
        _currentAnimation.Draw(rect.Position + offset, _is_right);
        _currentAnimation.ShowFrame();
        Raylib.DrawRectangleLinesEx(rect, 2, Color.Red);
    }
}
class Cat_quest1 : Quests
{
    static string[] dialogueLines = new string[]
    {
        "* Meow... I have a quest for you..",
        "* You need to deliver this to our customer",
        "* You know what happends if you dont...",
        "* Go down at the alley, you will find them there.",
        "*..."
    };
    public override void Textloop()
    {

        if (Raylib.IsKeyPressed(KeyboardKey.Space))
        {
            if (currentLine > 4) { currentLine = 4; }
            displayedText = dialogueLines[currentLine];
            currentLine++;
        } 
    }
}


