using Components;
using Entities;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Systems
{
    public static class CollisionsSystem
    {
        public static void CheckCollision(List<Entity>? _entities)
        {
            for (int i = 0; i < _entities.Count; i++)
            {
                for (int j = i + 1; j < _entities.Count; j++)
                {
                    var entityA = _entities[i];
                    var entityB = _entities[j];

                    var colliderA = entityA.GetComponent<BoxCollider>();
                    var colliderB = entityB.GetComponent<BoxCollider>();

                    if (colliderA == null || colliderB == null)
                        continue;

                    if (BoxIntersect(colliderA, colliderB))
                    {
                        ResolveCollision(entityA, entityB, colliderA, colliderB);
                        entityA.OnCollision();
                        entityB.OnCollision();
                    }
                }
            }
        }

        private static bool BoxIntersect(BoxCollider _a, BoxCollider _b)
        {
            Transform? transformA = _a.entity!.GetComponent<Transform>();
            Transform? transformB = _b.entity!.GetComponent<Transform>();
            if (transformA == null || transformB == null) return false;

            Vector2 minA = transformA.Position + _a.offset;
            Vector2 maxA = minA + _a.size;
            Vector2 minB = transformB.Position + _b.offset;
            Vector2 maxB = minB + _b.size;

            bool overlapX = maxA.X > minB.X && minA.X < maxB.X;
            bool overlapY = maxA.Y > minB.Y && minA.Y < maxB.Y;
            return overlapX && overlapY;
        }


        private static void ResolveCollision(Entity _a, Entity _b, Collider _aCol, Collider _bCol)
        {
            if (_aCol.isTrigger || _bCol.isTrigger)
                return;
            var aTrans = _a.GetComponent<Transform>();
            var aPhys = _a.GetComponent<Physics>();
            var bTrans = _b.GetComponent<Transform>();

            if (aTrans == null || aPhys == null || bTrans == null) return;

            if (_aCol is BoxCollider boxA && _bCol is BoxCollider boxB)
            {

                Vector2 aPos = aTrans.Position + boxA.offset;
                Vector2 bPos = bTrans.Position + boxB.offset;

                float overlapX = MathF.Min(aPos.X + boxA.size.X, bPos.X + boxB.size.X) - MathF.Max(aPos.X, bPos.X);
                float overlapY = MathF.Min(aPos.Y + boxA.size.Y, bPos.Y + boxB.size.Y) - MathF.Max(aPos.Y, bPos.Y);

                var pos = aTrans.Position;
                if (overlapX < overlapY)
                {
                    if (aPos.X < bPos.X)
                        pos.X -= overlapX;
                    else
                        pos.X += overlapX;

                    aTrans.Position = pos;
                    aPhys.Velocity = new Vector2(0, aPhys.Velocity.Y);
                }
                else
                {
                    if (aPos.Y < bPos.Y)
                        pos.Y -= overlapY;
                    else
                        pos.Y += overlapY;

                    aTrans.Position = pos;
                    aPhys.Velocity = new Vector2(aPhys.Velocity.X, 0);
                }
            }
        }
    }
}