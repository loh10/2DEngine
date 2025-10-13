using Components;

namespace Entities
{
    public class Entity
    {
        public List<Component> entityComponents = new List<Component>();

        public Transform? Transform { get; private set; }
        public Sprite? Sprite { get; private set; }
        public Physics? Physics { get; private set; }

        public void SetSprite(Sprite newSprite)
        {
            Sprite = newSprite;
        }

        public Entity(params Component[] components)
        {
            entityComponents.AddRange(components);

            foreach (var component in components)
            {
                Console.WriteLine(component.GetType());
                switch (component)
                {
                    case Transform t:
                        Transform = t;
                        break;
                    case Sprite s:
                        Sprite = s;
                        break;
                    case Physics p:
                        Physics = p;
                        break;
                }
            }
        }
    }
}