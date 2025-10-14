using Entities;

public static class EntitySystem
{
    public static List<Entity> Entities { get; private set; } = new List<Entity>();

    public static void Add(Entity _entity)
    {
        Entities.Add(_entity);
    }

    public static void Remove(Entity _entity)
    {
        Entities.Remove(_entity);
    }
}