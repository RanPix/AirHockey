using SFML.Graphics;
using SFML.System;
using SFML.Window;
using PingPong.Core;
using SFML_Thing.Assets.Enums;

namespace PingPong.Assets;

public class Paddle : Entity
{
    public Players player;

    private Vector2f rectSize = new Vector2f(100f, 20f);
    private Vector2f origin;

    private float moveSpeed = 550f;

    public Entity ball;

    public bool isAI;

    public override void Start()
    {
        base.Start();

        collider = rectSize * 0.5f;
        graphic = new RectangleShape(rectSize);

        origin = rectSize * 0.5f;
        graphic.Origin = origin;

        Input.MovementInput += Move;

        ball = Game.instance.FindByTag(Tag.Ball);
    }

    public override void Update()
    {
        base.Update();

        Move(new Vector2f(0, 0));
    }

    private void Move(Vector2f input)
    {
        if (isAI)
        {
            MoveAI();
            return;
        }

        Vector2f newPosition = position + input * moveSpeed * Time.deltaTime;

        if (newPosition.X - origin.X < 0f)
            position = new Vector2f(origin.X, position.Y);

        else if (newPosition.X + origin.X > Renderer.windowX)
            position = new Vector2f(Renderer.windowX - origin.X, position.Y);

        else
            position = newPosition;
    }

    private void MoveAI()
    {
        Vector2f newPosition = new Vector2f();

        if (ball.position.X < position.X)
            newPosition = new Vector2f(-1, 0) * moveSpeed * Time.deltaTime;

        else if (ball.position.X > position.X)
            newPosition = new Vector2f(1, 0) * moveSpeed * Time.deltaTime;

        position += newPosition * 0.5f;


        if (position.X - origin.X < 0f)
            position = new Vector2f(origin.X, position.Y);

        else if (position.X + origin.X > Renderer.windowX)
            position = new Vector2f(Renderer.windowX - origin.X, position.Y);
    }
}
