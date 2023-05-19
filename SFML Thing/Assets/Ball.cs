using SFML.Graphics;
using SFML.System;
using PingPong.Core;
using SFML_Thing.Assets.Enums;
using SFML_Thing.Core.Extentions;

namespace PingPong.Assets;

public class Ball : Entity
{
    private float radius = 15f;

    private float moveSpeed = 1000f;
    private Vector2f velocity;

    private Players bouncedPlayer = Players.Player1;

    public override void Start()
    {
        base.Start();

        collider = new Vector2f(radius, radius);
        graphic = new CircleShape(radius, 30);
        graphic.Origin = new Vector2f(radius, radius);

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
        
        if (collision.tag == Tag.Paddle)
        {
            Paddle paddle = (Paddle)collision;

            BounceOfPaddle(paddle.player);
        }
    }

    private void Bounce()
    {
        if (position.X - radius < 0f && velocity.X < 0f)
            velocity.X = -velocity.X;

        if (position.X + radius > Renderer.windowX && velocity.X > 0f)
            velocity.X = -velocity.X;


        if (position.Y - radius < 0f || position.Y + radius > Renderer.windowY)
        {
            Respawn();
            Scored();
        }
    }

    private void BounceOfPaddle(Players player)
    {
        bouncedPlayer = player;

        moveSpeed += 5f;

        velocity.Y = bouncedPlayer == Players.Player1 ?
            1 : -1;

        velocity.X = Rand.Next(-6, 6);

        velocity = velocity.Normalize() * moveSpeed;
        
    }

    private void Move()
        => position += velocity * Time.deltaTime;

    private void Respawn()
    {
        position = new Vector2f(400f, 600f);

        velocity.X = Rand.Next(-moveSpeed - 5, moveSpeed + 5);
        velocity.Y = -velocity.Y;
    }

    private void Scored()
        => Score.instance.Scored(bouncedPlayer);
}
