using Components;
using Entities;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Systems
{
    public static class CollisionsSystem
    {
        public static void CheckCollision(List<Entity> _entities)
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
                    bool collided = false;
                    collided = BoxBoxIntersect(colliderA, colliderB);

                    if (collided)
                    {
                        ResolveCollision(entityA, entityB, colliderA, colliderB);
                        entityA.OnCollision(entityB);
                        entityB.OnCollision(entityA);
                    }
                }
            }
        }

        private static bool BoxBoxIntersect(BoxCollider a, BoxCollider b)
        {
            var transformA = a.entity!.GetComponent<Transform>();
            var transformB = b.entity!.GetComponent<Transform>();
            if (transformA == null || transformB == null) return false;

            Vector2 minA = transformA.Position + a.offset;
            Vector2 maxA = minA + a.size;
            Vector2 minB = transformB.Position + b.offset;
            Vector2 maxB = minB + b.size;

            bool overlapX = maxA.X > minB.X && minA.X < maxB.X;
            bool overlapY = maxA.Y > minB.Y && minA.Y < maxB.Y;

            return overlapX && overlapY;
        }


        private static void ResolveCollision(Entity a, Entity b, Collider aCol, Collider bCol)
        {
            var aTrans = a.GetComponent<Transform>();
            var aPhys = a.GetComponent<Physics>();
            var bTrans = b.GetComponent<Transform>();

            if (aTrans == null || aPhys == null || bTrans == null) return;

            // Box vs Box simple
            if (aCol is BoxCollider boxA && bCol is BoxCollider boxB)
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