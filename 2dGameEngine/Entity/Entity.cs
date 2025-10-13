using Components;

namespace Entities
{
    public class Entity
    {
        private List<Component> _entityComponents = new List<Component>();

        public void AddBehavior(Component _component)
        {
            _component.entity = this;
            _entityComponents.Add(_component);
            _component.Start();
        }

        public void UpdateBehaviors(float _deltaTime)
        {
            foreach (Component component in _entityComponents)
                component.Update(_deltaTime);
        }

        public Entity(params Component[] _components)
        {
            _entityComponents.AddRange(_components);

            foreach (var component in _components)
            {
                component.entity = this;
                component.Start();
            }
        }

        public T? GetComponent<T>() where T : Component
        {
            foreach (var c in _entityComponents)
                if (c is T matched)
                    return matched;
            return null;
        }

        public void OnCollision(Entity _other)
        {
            foreach (var component in _entityComponents)
            {
                component.OnCollision(_other);
            }
        }
    }
}