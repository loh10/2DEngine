using Components;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine
{
    public static class TextureLoader
    {
        public static Sprite LoadSprite(ContentManager content, string spriteName)
        {
            return new Sprite(content.Load<Texture2D>(spriteName));
        }
    }
}