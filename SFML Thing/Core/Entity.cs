using SFML.Graphics;

namespace SFML_Thing.Core;

public abstract class Entity
{
    Shape shape = new CircleShape();


    public abstract void Start();

    public abstract void Update();
}
