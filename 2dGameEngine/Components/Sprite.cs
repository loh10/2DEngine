using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Components
{
    public class Sprite : Component
    {
        public Texture2D texture;
        public Color color;
        public Rectangle? sourceRectangle;
        public float layerDepth;
        public SpriteEffects effects;

        public Vector2 Scale { get; private set; } = Vector2.One;

        public Sprite(Texture2D _texture, Color? _color = null, Rectangle? _sourceRectangle = null,
            float _layerDepth = 0f, SpriteEffects _effects = SpriteEffects.None)
        {
            texture = _texture;
            color = _color ?? Color.White;
            sourceRectangle = _sourceRectangle;
            layerDepth = _layerDepth;
        }
    }
}