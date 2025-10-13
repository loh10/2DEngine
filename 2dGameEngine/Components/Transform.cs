using Microsoft.Xna.Framework;

namespace Components
{
    public class Transform: Component
    {
        public Vector2 Position { get; set; }

        public float Rotation { get; set; }

        public Vector2 Scale { get; set; }

        /// <summary>
        /// Add Transform to entity
        /// </summary>
        /// <param name="position">Vector2 position</param>
        /// <param name="rotation">float rotation in radians</param>
        /// <param name="scale"> Vector2 scale (x,y)</param>
        public Transform(Vector2 position = default, float rotation = 0f, Vector2? scale = null)
        {
            Position = position;
            Rotation = rotation;
            Scale = scale ?? Vector2.One; // par défaut scale = (1,1)
        }
    }
}