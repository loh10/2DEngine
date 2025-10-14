using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Components
{
    public class Sprite : Component
    {
        public Texture2D Texture { get; set; }
        public Color Color { get; set; }
        public Rectangle? SourceRectangle { get; set; }
        public float LayerDepth { get; set; }
        public Vector2 Origin { get; set; }

        // Nouveau : scale du sprite
        public Vector2 Scale { get; private set; } = Vector2.One;

        public Sprite(Texture2D _texture, Color? _color = null, Rectangle? _sourceRectangle = null,
            float _layerDepth = 0f, Vector2? _origin = null)
        {
            Texture = _texture;
            Color = _color ?? Color.White;
            SourceRectangle = _sourceRectangle;
            LayerDepth = _layerDepth;
            // Origin = _origin ?? new Vector2(_texture.Width / 2f, _texture.Height / 2f);
        }
    }
}