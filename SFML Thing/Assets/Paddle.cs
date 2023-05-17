using SFML.Graphics;
using SFML.System;
using SFML.Window;
using PingPong.Core;

namespace PingPong.Assets;

public class Paddle : Entity
{
    private Vector2f rectSize = new Vector2f(100f, 20f);
    private Vector2f origin;

    private float moveSpeed = 600f;

    public override void Start()
    {
        base.Start();

        collider = rectSize * 0.5f;
        shape = new RectangleShape(rectSize);

        origin = rectSize * 0.5f;
        shape.Origin = origin;

        shape.FillColor = Color.Cyan;
    }

    public override void Update()
    {
        base.Update();

        Move();
    }

    private void Move()
    {
        Vector2f newPosition = position + ProcessMovementInput() * moveSpeed * Time.deltaTime;

        // ЧОГО Я ТАК ТУПЛЮЮЮ
        position = newPosition.X - origin.X < 0f ?
                   new Vector2f(origin.X, position.Y) :

                   newPosition.X + origin.X > Renderer.windowX ?
                   new Vector2f(Renderer.windowX - origin.X, position.Y) :

                   newPosition;
    }

    private Vector2f ProcessMovementInput()
    {
        Keyboard.Key key = Input.GetMovementInput();

        return key switch
        {
            Keyboard.Key.A => new Vector2f(-1, 0),
            Keyboard.Key.D => new Vector2f(1, 0),
            _ => new Vector2f(0, 0),
        };
    }
}
