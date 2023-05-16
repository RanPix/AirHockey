using SFML.Graphics;
using SFML.System;
using PingPong.Core;

namespace PingPong.Assets;

public class Ball : Entity
{
    private float radius = 15f;

    private float moveSpeed = 5f;
    private Vector2f velocity;

    private int bounces;

    private float collisionIgnoreTime;

    public override void Start()
    {
        base.Start();

        collider = new Vector2f(radius, radius);
        shape = new CircleShape(radius, 30);
        shape.Origin = new Vector2f(radius, radius);

        velocity = new Vector2f(moveSpeed, moveSpeed);
    }

    public override void Update()
    {
        base.Update();

        Bounce();
        Move();
    }

    public override void OnCollisionEnter(Entity collision)
    {
        base.OnCollisionEnter(collision);


        velocity.Y = -velocity.Y;
        velocity.X = Rand.Next(-moveSpeed - 5, moveSpeed + 5);
        bounces++;

        if (collision.tag == Tag.Platform)
        {
            Console.WriteLine("YES" + bounces);

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
