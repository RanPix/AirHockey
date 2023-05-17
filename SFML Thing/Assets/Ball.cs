﻿using SFML.Graphics;
using SFML.System;
using PingPong.Core;

namespace PingPong.Assets;

public class Ball : Entity
{
    private float radius = 15f;

    private float moveSpeed = 500f;
    private Vector2f velocity;

    private int bounces;

    private float collisionIgnoreTime = 0.1f;
    private float collisionIgnoreTimer;

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

        collisionIgnoreTimer += Time.deltaTime;

        Bounce();
        Move();
    }

    public override void OnCollisionEnter(Entity collision)
    {
        base.OnCollisionEnter(collision);

        if (collision.tag == Tag.Platform)
        {
            velocity.Y = -velocity.Y;
            velocity.X = Rand.Next(-moveSpeed - 5, moveSpeed + 5);

            bounces++;
            moveSpeed += 5f;
        }
    }

    private void Bounce()
    {
        if (position.X - radius < 0f && velocity.X < 0f)
        {
            velocity.X = -velocity.X;
            bounces++;
        }
        if (position.X + radius > Renderer.windowX && velocity.X > 0f)
        {
            velocity.X = -velocity.X;
            bounces++;
        }

        if (position.Y - radius < 0f)
        {
            position = new Vector2f(400f, 600f);

            velocity.X = Rand.Next(-moveSpeed - 5, moveSpeed + 5);
            velocity.Y = -velocity.Y;
        }
        if (position.Y + radius > Renderer.windowY)
        {
            position = new Vector2f(400f, 600f);

            velocity.X = Rand.Next(-moveSpeed - 5, moveSpeed + 5);
            velocity.Y = -velocity.Y;
        }
    }

    private void Move()
        => position += velocity * Time.deltaTime;
}
