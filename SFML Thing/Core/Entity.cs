using SFML.Graphics;
using SFML.System;
using System.Formats.Asn1;

namespace SFML_Thing.Core;

public abstract class Entity
{
    public Tag tag = Tag.None;
    public Shape shape = new CircleShape();

    private Vector2f _position;
    public Vector2f position
    {
        get { return _position; }
        set 
        { 
            _position = value; 
            shape.Position = value; 
        }
    }

    public virtual void Start()
    {

    }

    public virtual void Update()
    {

    }

    public virtual void OnDestroy() 
    {
    
    }

    public virtual void OnCollisionEnter(Entity collision)
    {

    }
}
