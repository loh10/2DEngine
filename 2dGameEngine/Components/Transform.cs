using Microsoft.Xna.Framework;

namespace Components
{
    public class Transform: Component
    {
        public Vector2  Position { get; set; }

        public float Rotation { get; set; }

        public Vector2 Scale { get; set; }

        /// <summary>
        /// Add Transform to entity
        /// </summary>
        /// <param name="_position">Vector2 position</param>
        /// <param name="_rotation">float rotation in radians</param>
        /// <param name="_scale"> Vector2 scale (x,y)</param>
        public Transform(Vector2 _position = default, float _rotation = 0f, Vector2? _scale = null)
        {
            Position = _position;
            Rotation = _rotation;
            Scale = _scale ?? Vector2.One; // par défaut scale = (1,1)
        }
    }
}