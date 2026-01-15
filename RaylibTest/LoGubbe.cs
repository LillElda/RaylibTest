using Raylib_cs;
using System.Numerics;

class Kunglig : Character
{

    string _sprite_idle = "LoGubbeKunglig.png";
    public Kunglig(string idleSprite, Vector2 pos) : base("LoGubbeKunglig.png", pos)
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
class Goal_Quest : Quests
{
    static string[] dialogueLines = new string[]
    {
        "* Who are you??",
        "* OOOH, right. I ordered something",
        "* You got the stuff?",
        "*Thank you man."
    };
    public override void Textloop()
    {

        if (Raylib.IsKeyPressed(KeyboardKey.Space))
        {
            if (currentLine > 3) { currentLine = 3; }
            displayedText = dialogueLines[currentLine];
            currentLine++;
        } 
    }
}