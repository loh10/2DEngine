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

        public Physics(Vector2 _velocity = default, Vector2 _acceleration = default,
            float _mass = 1f, bool _isAffectedByGravity = true, float _friction = 0f)
        {
            Velocity = _velocity;
            Acceleration = _acceleration;
            Mass = _mass;
            IsAffectedByGravity = _isAffectedByGravity;
            Friction = _friction;
        }

    }
}
