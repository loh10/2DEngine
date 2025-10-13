using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Components;
using Entities;

namespace Systems
{
    public class PhysicsSystem
    {
        private static Vector2 _gravity = new Vector2(0, 500f);

        public static void Update(List<Entity> entities, float deltaTime)
        {
            foreach (var entity in entities)
            {
                var transform = entity.Transform;
                var physics = entity.Physics;

                if (physics.IsAffectedByGravity)
                    physics.Acceleration += _gravity;

                physics.Velocity += physics.Acceleration * deltaTime;

                physics.Velocity *= (1f - physics.Friction * deltaTime);

                transform.Position += physics.Velocity * deltaTime;

                physics.Acceleration = Vector2.Zero;
            }
        }
    }
}