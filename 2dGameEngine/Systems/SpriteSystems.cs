using Entities;
using Microsoft.Xna.Framework.Graphics;

namespace Systems
{
    public static class SpriteSystems
    {
        public static void Draw(SpriteBatch spriteBatch, List<Entity> entities)
        {
            spriteBatch.Begin();
            foreach (Entity entity in entities)
            {
                if(entity.Transform ==null || entity.Sprite == null)
                    continue;
                spriteBatch.Draw(
                    entity.Sprite.Texture,
                    entity.Transform.Position,
                    entity.Sprite.SourceRectangle,
                    entity.Sprite.Color,
                    entity.Transform.Rotation,
                    entity.Sprite.Origin,
                    entity.Transform.Scale,
                    SpriteEffects.None,
                    entity.Sprite.LayerDepth
                );
            }
            spriteBatch.End();
        }
    }
}
