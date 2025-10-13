using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Components;
using Entities;
using Systems;

namespace GameEngine
{
    public class Game : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private List<Entity> _entities = new List<Entity>();


        // Gravité simple
        private Sprite _sprite2;
        private Sprite _sprite;

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

            // --- Créer le player ---
            var transform = new Transform(new Vector2(100, 100));
            _sprite = TextureLoader.LoadSprite(Content,"player");
            _sprite2 = TextureLoader.LoadSprite(Content,"player2");



            var physics = new Physics(Vector2.Zero, Vector2.Zero, 1f, false);

            Entity player = new Entity(transform, _sprite, physics);

            _entities.Add(player);
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            // --- Contrôles du player ---
            var keyboard = Keyboard.GetState();

            foreach (var entity in _entities)
            {
                float speed = 300f;

                if (keyboard.IsKeyDown(Keys.Left)|| keyboard.IsKeyDown(Keys.Q))
                    entity.Physics.Velocity = new Vector2(-speed, entity.Physics.Velocity.Y);
                else if (keyboard.IsKeyDown(Keys.Right) || keyboard.IsKeyDown(Keys.D))
                    entity.Physics.Velocity = new Vector2(speed, entity.Physics.Velocity.Y);
                else
                    entity.Physics.Velocity = new Vector2(0, entity.Physics.Velocity.Y);
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    entity.SetSprite(_sprite2);
                else
                    entity.SetSprite(_sprite);
            }


            // --- Mettre à jour la physique ---
            PhysicsSystem.Update(_entities, delta);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            SpriteSystems.Draw(_spriteBatch,_entities);
            base.Draw(gameTime);
        }
    }
}