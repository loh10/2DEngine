using Microsoft.Xna.Framework;

namespace Components
{
    public class Physics : Component
    {
        public Vector2 Velocity { get; set; }

        public Vector2 Acceleration { get; set; }

        public float Mass { get; set; }

        public bool IsAffectedByGravity { get; set; }

        public float Friction { get; set; }

        public Physics(Vector2 velocity = default, Vector2 acceleration = default,
            float mass = 1f, bool isAffectedByGravity = true, float friction = 0f)
        {
            Velocity = velocity;
            Acceleration = acceleration;
            Mass = mass;
            IsAffectedByGravity = isAffectedByGravity;
            Friction = friction;
        }

    }
}
