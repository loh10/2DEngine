using Microsoft.Xna.Framework;

namespace Components
{
    public class BoxCollider : Collider
    {
        public Vector2 size;

        public BoxCollider(Vector2 _size = default, Vector2 _offset = default, bool _isTrigger = false)
        {
            offset = _offset;
            isTrigger = _isTrigger;
            size = (_size != Vector2.Zero) ? _size : GetSize();
        }


        public Vector2 GetSize()
        {
            Transform? transform = entity?.GetComponent<Transform>();
            if (transform != null && transform.Size != Vector2.Zero)
                return transform.Size;
            return Vector2.One;
        }
    }
}