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
    
    public World_events events;
    public Game()
    {
        events = new World_events(rat, cat); //change so that when rat imported we need rats pos and move collition to world events.
    }



    public void Update()
    {
        events.currentbackground.Draw();
        rat.Draw();
        if (events.currentbackground == events.background1) cat.Draw();

        events.Rat_move_screen();
        events.Check_collition();



        //background.Draw();
    }

}