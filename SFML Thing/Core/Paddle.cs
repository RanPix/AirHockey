using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace SFML_Thing.Core;

public class Paddle : Entity
{
    private Vector2f rectSize = new Vector2f(100f, 20f);
    private Vector2f origin;

    private float moveSpeed = 6f;

    

    public override void Start()
    {
        base.Start();

        shape = new RectangleShape(rectSize);
        origin = rectSize * 0.5f;
        shape.Origin = origin;
        shape.FillColor = Color.Cyan;

        //Console.WriteLine("Start");
    }

    public override void Update()
    {
        base.Update();

        Move();

        //Console.WriteLine("Update");
    }

    private void Move()
    {
        Vector2f newPosition = position + ProcessMovementInput() * moveSpeed;

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
