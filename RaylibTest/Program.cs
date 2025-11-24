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
Rat rat = new Rat();

Vector2 _posrat = new(0, 0);

while (!Raylib.WindowShouldClose())
{ 
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.RayWhite);
    rat.Draw();
    Raylib.EndDrawing();
}

class Rat
{
    public Texture2D _bildavratta = Raylib.LoadTexture("pixil-frame-0.png");
    
    private int _health;
    private Vector2 _pos = new(0, 0);
    private Vector2 _move = new(0, 0);
    private Vector2 _rotation = new(0, 0);
    private float _velY = 0f;
    private bool _onGround = false;
    private int _currentframe = 0;
    private int _slowframe = 0;
    private bool _rat_is_right = true;

    const float _gravity = 0.4f;
    const float _jump_force = -10f;
    const float _floor_Y = 600f;
    public Rat()
    {
    }
    private void Gravity()
    {
        if (_pos.Y >= _floor_Y)
        {
            _pos.Y = _floor_Y;
            _velY = 0;
            _onGround = true;
        }
        else
        {
            _velY += _gravity;
            _onGround = false;
        }
    }
    private void Jump()
    {
        if (Raylib.IsKeyPressed(KeyboardKey.Up) && _onGround)
        {
            _velY = _jump_force;
            _onGround = false;
        }
    }
    public Vector2 Move()
    {
        
        _move = Vector2.Zero;
        if (Raylib.IsKeyDown(KeyboardKey.Right))
        {
            _move.X += 5;
            if (_onGround) { ShowFrame(); }
            _rat_is_right = true;
        }
        if (Raylib.IsKeyDown(KeyboardKey.Left))
        {
            _move.X -= 5;
            if (_onGround) { ShowFrame(); }
            _rat_is_right = false;  
        }
        Gravity();
        Jump();
        
        _pos += _move;
        _pos.Y += _velY;

        if (_move.Length() != 0)
            _move = Vector2.Normalize(_move);
        return _pos;
    }
    public void Draw()
    {
        // if (!_rat_is_right)
        // { Raylib.DrawTextureEx(_bildavratta, Move(), 180f, 1f, Color.White); }
        // else { Raylib.DrawTextureEx(_bildavratta, Move(), 0f, 1f, Color.White); }
        Rectangle src = new(0, 0, -_bildavratta.Width, _bildavratta.Height);
        Raylib.DrawTextureRec(_bildavratta, src, Move(), Color.White);
        
    }
    private void ShowFrame()
    {
        _slowframe++;
        if (_slowframe % 7 == 0){
            _currentframe++;
            if (_currentframe >= 5) { _currentframe = 0; }
            _bildavratta = Raylib.LoadTexture("pixil-frame-" + _currentframe + ".png");
            Console.WriteLine(_currentframe);
            if (_slowframe >= 500){ _slowframe = 0; }
        } 
    }
}
