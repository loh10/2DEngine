using Microsoft.Xna.Framework;

namespace Components
{
    public class CircleCollider : Collider
    {
        public float radius;
        public CircleCollider(float _radius, Vector2 _offset = default, bool _isTrigger = false)
        {
            radius = _radius;
            offset = _offset;
            isTrigger = _isTrigger;
        }
    }
}