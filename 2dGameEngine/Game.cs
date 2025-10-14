using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Components;
using Entities;
using Microsoft.Xna.Framework.Content;
using Scripts;
using Systems;

using static Systems.SpritesSystem;

namespace GameEngine
{
    public class Game : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch = null!;
        public static ContentManager? content;

        public Game()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Assets";
            content = Content;
            IsMouseVisible = true;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            var transform = new Transform(new Vector2(50, 0),0,new Vector2(64,64));
            AnimatedSprite sprite = LoadAnimatedSprite(Content,"playerAnim",2,2,128);
            sprite.LayerDepth = 1;
            Physics physics = new Physics();

            Entity player = new Entity(transform, sprite,new PlayerMovement(), physics,new BoxCollider(transform.Size));
            EntitySystem.Add(player);

            var transform1 = new Transform(new Vector2(50, 400), 0, new Vector2(500, 10));
            Entity ground = new Entity(
                transform1,
                new BoxCollider(transform1.Size),
                LoadSprite(Content,"ground"),
                new Physics() { IsAffectedByGravity = false });
            EntitySystem.Add(ground);

        }

        protected override void Update(GameTime _gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            float delta = (float)_gameTime.ElapsedGameTime.TotalSeconds;

            PhysicsSystem.Update(EntitySystem.Entities, delta);

            foreach (Entity entity in EntitySystem.Entities)
            {
                entity.UpdateBehaviors(delta);
            }

            base.Update(_gameTime);
        }

        protected override void Draw(GameTime _gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            SpritesSystem.Draw(_spriteBatch,EntitySystem.Entities);
            base.Draw(_gameTime);
        }
    }
}