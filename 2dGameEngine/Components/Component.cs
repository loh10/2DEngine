using Entities;
// ReSharper disable InconsistentNaming

public abstract class Component
{
    public virtual void Start() {}
    public virtual void Update(float _deltaTime) {}
    public virtual void OnCollision() {}
    public Entity? entity { get; set; }
}
