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

        public static Sprite LoadSprite(ContentManager _content, string _spriteName)
        {
            return new Sprite(_content.Load<Texture2D>(_spriteName));
        }

        public static AnimatedSprite LoadAnimatedSprite(ContentManager _content, string _spriteName,int _nbFrames, float _timeFrame, int _frameWidth, int _frameHeight = 0)
        {
            return new AnimatedSprite(_content.Load<Texture2D>(_spriteName),_nbFrames,_timeFrame,_frameWidth,_frameHeight);
        }

        // Dessine toutes les entités avec un composant Sprite + Transform
        public static void Draw(SpriteBatch _spriteBatch,Camera _camera, List<Entity> _entities)
        {
            _spriteBatch.Begin(transformMatrix: _camera.GetViewMatrix());

            foreach (var entity in _entities)
            {
                Transform? t = entity.GetComponent<Transform>();
                Sprite? s = entity.GetComponent<Sprite>();

                if (t == null || s == null)
                    continue;

                int frameWidth = s.Texture.Width;
                if (s is AnimatedSprite animated)
                    frameWidth = animated.FrameWidth;

                Vector2 size = new Vector2(t.Size.X / frameWidth, t.Size.Y / s.Texture.Height);

                _spriteBatch.Draw(
                    s.Texture,
                    t.Position,
                    s.SourceRectangle,
                    s.Color,
                    t.Rotation,
                    default,
                    size,
                    SpriteEffects.None,
                    s.LayerDepth
                );
            }


            _spriteBatch.End();
        }
    }
}