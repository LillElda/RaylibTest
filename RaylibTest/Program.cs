// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography;
using Raylib_cs;
using System.Numerics;
using System.Security;
using System.Runtime.InteropServices;
using System.IO.Pipes;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;


Raylib.InitWindow(1200, 1000, "Grafiiiiiiiiiiiiiik");
Raylib.SetTargetFPS(60);

Game game = new Game();
//list gameobjects // use for 
//((Enemy)u).funktion() //typkonvertering
//abstract doesnt have a body. 
//interface == kravlista




while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.RayWhite);
    game.Update();
    Raylib.EndDrawing();
}



class Game
{

    public Rat rat = new Rat("", new(0, 0));
    public Cat cat = new Cat("", new(800, 600));
    public Objects background1 = new Objects("backgroundStart -spritesheet.png", new(0, 0), new(1200, 1000));
    public Objects background2 = new Objects("background2.png", new(0, 0), new(1200, 1000));
    public Cat_quest1 quest1 = new();
    public Objects currentbackground;
    public Game(){
        currentbackground = background1;
    }


    public void Update()
    {
        currentbackground.Draw();
        rat.Draw();
        if(currentbackground == background1)cat.Draw();
        if (Raylib.CheckCollisionRecs(rat.rect, cat.rect)&&currentbackground == background1)
        {
            quest1.Textloop();
            quest1.Draw();
            //System.Console.WriteLine("KOLLISION"); //If this happends, make press space avalible, to start quest.
        }
        string answer = rat.Check_moving_screen();
        if (answer == "right" && currentbackground == background1)currentbackground = background2; 
        else if(answer == "left" && currentbackground == background2)currentbackground = background1;
        //background.Draw();
    }

}