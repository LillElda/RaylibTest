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



while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.RayWhite);
    game.rat.Draw();
    Raylib.EndDrawing();
}

class Game
{
    public Rat rat = new Rat();
    public class Rat
    {

        public Animation _walk = new("pixilart-sprite (1).png", 32);

        private int _health;
        private Vector2 _pos = new(0, 0);
        private Vector2 _move = new(0, 0);
        private float _velY = 0f;
        private bool _onGround = false;
        private int _slowframe = 0;
        private bool _rat_is_right = true;

        const float _gravity = 0.4f;
        const float _jump_force = -15f;
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
            _walk.Draw(Move(), _rat_is_right);
        }
        private void ShowFrame()
        {
            _slowframe++;
            if (_slowframe % 7 == 0)
            {
                _walk.NextFrame();
                if (_slowframe >= 500) { _slowframe = 0; }
            }
        }
    }
}

class Animation
{
    Texture2D _spritesheet;
    int _currentframe = 0;
    int _width;
    int _totalframes;

    float _scale = 10;

    public Animation(string spritesheet, int width)
    {
        _spritesheet = Raylib.LoadTexture(spritesheet);
        _width = width;
        _totalframes = _spritesheet.Width / _width;
    }

    public void NextFrame()
    {
        _currentframe++;
        if (_currentframe == _totalframes)
        {
            _currentframe = 0;
        }
    }

    public void Draw(Vector2 pos, bool flip)
    {
        Rectangle src = new(_width * _currentframe, 0, _width, _spritesheet.Height);
        Rectangle srcflip = new(_width * _currentframe, 0, -_width, _spritesheet.Height);
        Rectangle dst = new(pos, new Vector2(_width, _spritesheet.Height) * _scale);
        if (flip) Raylib.DrawTexturePro(_spritesheet, src, dst, Vector2.Zero, 0, Color.White);
        else Raylib.DrawTexturePro(_spritesheet, srcflip, dst, Vector2.Zero, 0, Color.White);
    }
}