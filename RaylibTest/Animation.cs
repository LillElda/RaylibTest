using Raylib_cs;
using System.Numerics;
class Animation
{
    Texture2D _spritesheet;
    int _currentframe = 0;
    int _width;
    int _totalframes;
    private int _slowframe = 0;

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
    public void ShowFrame()
    {
        _slowframe++;
        if (_slowframe % 7 == 0)
        {
            NextFrame();
            if (_slowframe >= 500) _slowframe = 0;
        }
    }
}

