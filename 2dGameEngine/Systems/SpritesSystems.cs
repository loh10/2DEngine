using Components;
using Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Systems
{
    public static class SpritesSystem
    {
        // Charge un sprite depuis le ContentManager
        public static Sprite LoadSprite(ContentManager _content, string _spriteName)
        {
            return new Sprite(_content.Load<Texture2D>(_spriteName));
        }

        // Dessine toutes les entités avec un composant Sprite + Transform
        public static void Draw(SpriteBatch _spriteBatch, List<Entity> _entities)
        {
            _spriteBatch.Begin();

            foreach (var entity in _entities)
            {
                Transform? t = entity.GetComponent<Transform>();
                Sprite? s = entity.GetComponent<Sprite>();

                if (t == null || s == null)
                    continue;

                Vector2 size = new Vector2(t.Size.X / s.Texture.Width, t.Size.Y / s.Texture.Height);


                _spriteBatch.Draw(
                    s.Texture,
                    t.Position,
                    s.SourceRectangle,
                    s.Color,
                    t.Rotation,
                    s.Origin,
                    size,
                    SpriteEffects.None,
                    s.LayerDepth
                );
            }

            _spriteBatch.End();
        }
    }
}