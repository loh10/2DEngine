using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Components;
using Entities;

namespace Systems
{
    public abstract class PhysicsSystem
    {
        private static Vector2 _gravity = new Vector2(0, 500);

        public static void Update(List<Entity>? _entities, float _deltaTime)
        {
            foreach (var entity in _entities)
            {
                var physics = entity.GetComponent<Physics>();
                var transform = entity.GetComponent<Transform>();

                if (physics == null || transform == null)
                    continue;


                if (physics.IsAffectedByGravity)
                    physics.Velocity += _gravity * _deltaTime;

                physics.Velocity *= 1f - physics.Friction * _deltaTime;

                transform.Position += physics.Velocity * _deltaTime;
            }
            CollisionsSystem.CheckCollision(_entities);

        }

    }
}