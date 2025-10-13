using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Components;
using Entities;
using Systems;

using static Systems.SpritesSystems;

namespace GameEngine
{
    public class Game : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private List<Entity> _entities = new List<Entity>();


        public Game()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Assets";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _entities = new List<Entity>();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            var transform = new Transform(new Vector2(100, 100));
            Sprite sprite = LoadSprite(Content,"player");
            sprite.LayerDepth = 1;
            Physics physics = new Physics(Vector2.Zero, Vector2.Zero);
            BoxCollider playerCollider = new BoxCollider(new Vector2(60, 60));

            Entity player = new Entity(transform, sprite, physics,new Movements(),playerCollider);
            _entities.Add(player);

            Entity ground = new Entity(
                new Transform(new Vector2(50, 400),0,new Vector2(50,1)),
                new BoxCollider(new Vector2(5000, 10)),
                LoadSprite(Content,"ground"));
            _entities.Add(ground);

        }

        protected override void Update(GameTime _gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            float delta = (float)_gameTime.ElapsedGameTime.TotalSeconds;

            PhysicsSystem.Update(_entities, delta);

            foreach (Entity entity in _entities)
            {
                entity.UpdateBehaviors(delta);
            }

            base.Update(_gameTime);
        }

        protected override void Draw(GameTime _gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            SpritesSystems.Draw(_spriteBatch,_entities);
            base.Draw(_gameTime);
        }
    }
}