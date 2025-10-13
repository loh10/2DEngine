using Microsoft.Xna.Framework;

namespace Components
{
    public class BoxCollider : Collider
    {
        public Vector2 size;

        public BoxCollider(Vector2 _size, Vector2 _offset = default, bool _isTrigger = false)
        {
            size = _size;
            offset = _offset;
            isTrigger = _isTrigger;
        }
    }
}
