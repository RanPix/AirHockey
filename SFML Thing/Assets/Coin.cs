using PingPong.Core;
using SFML.Graphics;
using SFML.System;

namespace PingPong.Assets;

public class Coin : Entity
{
    private float radius = 40f;

    public override void Start()
    {
        base.Start();

        CircleShape circle = new CircleShape(radius, 30);
        circle.FillColor = Color.Yellow;
        graphic = circle;

        graphic.Origin = new Vector2f(radius, radius);
        collider = new Vector2f(radius, radius);

        Respawn();
    }

    public override void OnCollisionEnter(Entity collision)
    {
        base.OnCollisionEnter(collision);

        if (collision.tag == Tag.Ball)
            Respawn();
    }

    private void Respawn()
    {
        position = new Vector2f(Rand.Next(100, 500), Rand.Next(300, 900));
    }
}
