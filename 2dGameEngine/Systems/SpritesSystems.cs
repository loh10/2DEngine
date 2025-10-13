using Components;
using Entities;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Systems
{
    public static class SpritesSystems
    {

        public static Sprite LoadSprite(ContentManager _content, string _spriteName)
        {
            return new Sprite(_content.Load<Texture2D>(_spriteName));
        }

        public static void Draw(SpriteBatch _spriteBatch, List<Entity> _entities)
        {
            _spriteBatch.Begin();
            foreach (Entity entity in _entities)
            {

                Transform? t = entity.GetComponent<Transform>();
                Sprite? s = entity.GetComponent<Sprite>();
                if(t ==null || s == null)
                    continue;
                _spriteBatch.Draw(
                    s.Texture,
                    t.Position,
                    s.SourceRectangle,
                    s.Color,
                    t.Rotation,
                    s.Origin,
                    t.Scale,
                    SpriteEffects.None,
                    s.LayerDepth
                );
            }
            _spriteBatch.End();
        }
    }
}
