using SFML.Graphics;
using SFML.System;

namespace SFML_Thing.Core;

public class Ball : Entity
{
    private float radius = 15f;

    private float moveSpeed = 3f;
    private Vector2f velocity;

    private int bounces;

    public override void Start()
    {
        base.Start();

        shape = new CircleShape(radius, 30);
        shape.Origin = new Vector2f(radius, radius);
        velocity = new Vector2f(moveSpeed, moveSpeed);

        //Console.WriteLine("Start");
    }

    public override void Update()
    {
        base.Update();

        Bounce();
        Move();
        //Console.WriteLine(bounces);
    }

    public override void OnCollisionEnter(Entity collision)
    {
        base.OnCollisionEnter(collision);

        if (collision.tag == Tag.Platform)
        {

        }
    }

    private void Bounce()
    {
        if (position.X - radius < 0f || position.X + radius > Renderer.windowX)
        {
            velocity.X = -velocity.X;
            bounces++;
        }

        if (position.Y - radius < 0f || position.Y + radius > Renderer.windowY)
        {
            velocity.Y = -velocity.Y;
            bounces++;
        }
    }

    private void Move()
        => position += velocity;
}
