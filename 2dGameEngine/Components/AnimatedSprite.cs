using System.Security;
using Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class AnimatedSprite : Sprite
{
    public int frameCount;
    public int currentFrame;
    public float timeFrame;
    private float _currentTime;
    private int _frameWidth;
    private int _frameHeight;
    public int FrameWidth { get; private set; }

    public AnimatedSprite(Texture2D _texture,int _frameCount,float _timeFrame,int _frameWidth,int _frameHeight = 0, Color? _color = null, Rectangle? _sourceRectangle = null, float _layerDepth = 0,SpriteEffects _effects = SpriteEffects.None) :
        base(_texture, _color, _sourceRectangle, _layerDepth,_effects)
    {
        frameCount = _frameCount;
        currentFrame = 0;
        timeFrame = _timeFrame;
        this._frameWidth = _frameWidth;
        this._frameHeight = (_frameHeight == 0) ? _frameWidth : _frameHeight;
        FrameWidth = _frameWidth;
    }

    public override void Update(float _deltaTime)
    {
        _currentTime += _deltaTime;
        if (_currentTime >= timeFrame)
        {
            if (currentFrame < frameCount-1)
                currentFrame++;
            else
                currentFrame = 0;
            _currentTime = 0;
        }
        sourceRectangle = new Rectangle(currentFrame * _frameWidth, 0, _frameWidth, _frameHeight);
        base.Update(_deltaTime);
    }

}