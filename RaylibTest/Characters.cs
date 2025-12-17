
using System.Numerics;
using Raylib_cs;
class Character
{
    protected Animation _currentAnimation;
    protected Animation _idle;
    // public Vector2 _pos;
    // public Vector2 _size; //Was made into rectangle

    public Rectangle rect;
    protected Vector2 offset;


    protected bool _is_right = true;
    protected const float _floor_Y = 700f;

    public Character(string idleSprite, Vector2 pos)
    {
        _idle = new Animation(idleSprite, 32);
        // _pos = pos;
        rect = new(pos.X, pos.Y, 320, 320);
        _currentAnimation = _idle;
    }

    public void ChangePos(Vector2 newpos)
    {
        rect.X = newpos.X;
        rect.Y = newpos.Y;
    }

    public virtual void Draw()
    {
        _currentAnimation.ShowFrame();
        _currentAnimation.Draw(rect.Position + offset, _is_right);
        Raylib.DrawRectangleLinesEx(rect, 2, Color.Red);
    }

}

class CanMove : Character
{
    protected const float _gravity = 0.4f;
    protected float _velY = 0f;
    protected bool _onGround = false;
    public CanMove(string sprite, Vector2 _pos) : base(sprite, _pos)
    {

    }
    protected void Gravity()
    {
        if (rect.Y >= _floor_Y)
        {
            rect.Y = _floor_Y;
            _velY = 0;
            _onGround = true;
        }
        else
        {
            _velY += _gravity;
            _onGround = false;
        }
    }
}
interface DoSomeThing
{
    public void MyFunction(int do_something);
}

