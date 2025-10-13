using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Components
{
    public class Sprite: Component
    {
            public Texture2D Texture { get; set; }

            public Color Color { get; set; }

            public Rectangle? SourceRectangle { get; set; }

            public float LayerDepth { get; set; }

            public Vector2 Origin { get; set; }

            // Constructeur simple
            // C#
            public Sprite(Texture2D texture, Color? color = null, Rectangle? sourceRectangle = null,
                float layerDepth = 0f, Vector2? origin = null)
            {
                Texture = texture;
                Color = color ?? Color.White;
                SourceRectangle = sourceRectangle;
                LayerDepth = layerDepth;
                Origin = origin ?? new Vector2(texture.Width / 2, texture.Height / 2);
            }
    }
}