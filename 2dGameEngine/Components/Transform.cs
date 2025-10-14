using Microsoft.Xna.Framework;

namespace Components
{
    public class Transform: Component
    {
        public Vector2  Position { get; set; }

        public float Rotation { get; set; }

        public Vector2 Size { get; set; }

        /// <summary>
        /// Add Transform to entity
        /// </summary>
        /// <param name="_position">Vector2 position</param>
        /// <param name="_rotation">float rotation in radians</param>
        /// <param name="_size"> Vector2 size (x,y)</param>
        public Transform(Vector2 _position = default, float _rotation = 0f, Vector2? _size = null)
        {
            Position = _position;
            Rotation = _rotation;
            Size = _size ?? Vector2.One; // par défaut scale = (1,1)
        }
    }
}