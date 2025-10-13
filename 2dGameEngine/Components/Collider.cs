using Entities;
using Microsoft.Xna.Framework;

namespace Components
{
    public class Collider : Component
    {
        public Vector2 offset = Vector2.Zero;
        public bool isTrigger = false;
    }
}