using Raylib_cs;
using System.Numerics;
class Rat : CanMove
{
    string _sprite_idle = "RatIdle.png";
    string _sprite_walk = "pixilart-sprite (1).png";
    string _sprite_jump = "RATJump.png";
    Vector2 _move = new(0, 0);
    private Animation _walk;
    private Animation _jump;
    const float _jump_force = -15f;
    private float _speed = 5f;

     // Size pic vs real life, when in wrong pos
    public Rat(string sprite, Vector2 _pos) : base("RatIdle.png", _pos)
    {
        _idle = new Animation(_sprite_idle, 32);
        _walk = new Animation(_sprite_walk, 32);
        _jump = new Animation(_sprite_jump, 32);
        rect.Height = 90; //How much size it should be
        rect.Width = 320 - 30;
        offset = new(-10, -210); //How much should be moved
    }
    public void Sidemovement()
    {
        _move = Vector2.Zero;

        if (Raylib.IsKeyDown(KeyboardKey.Right))
        {
            _move.X += _speed;
            _is_right = true;
        }
        if (Raylib.IsKeyDown(KeyboardKey.Left))
        {
            _move.X -= _speed;
            _is_right = false;
        }
    }
    private void Jump()
    {
        if (Raylib.IsKeyPressed(KeyboardKey.Up) && _onGround)
        {
            _velY = _jump_force;
            _onGround = false;
            _currentAnimation = _jump;

        }
    }
    public string Check_moving_screen()
    {
        if (rect.X > 1200)
        {
            rect.X = 0;
            return "right";
        }
        else if (rect.X < 0)
        {
            rect.X = 1190;
            return "left";
        }  
        else{ return "none"; }
        
    }
    public void Move()
    {
        Sidemovement();
        Gravity();
        Jump();

        rect.Position += _move;
        rect.Y += _velY;


        if (_move.X != 0 && _onGround)
            _currentAnimation = _walk;
        //_walk.currentframe = 0; //plss work
        else if (_move.X == 0 && _onGround) _currentAnimation = _idle;
    }

    public override void Draw()
    {
        Move();
        _currentAnimation.Draw(rect.Position + offset, _is_right);
        _currentAnimation.ShowFrame();
        Raylib.DrawRectangleLinesEx(rect, 2, Color.Red);
    }
}

