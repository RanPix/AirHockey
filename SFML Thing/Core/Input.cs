using SFML.System;
using SFML.Window;

namespace PingPong.Core;

public class Input
{
    public static Action<Vector2f> MovementInput;

    public void Update()
    {
        GetMovementInput();
    }


    private void GetMovementInput()
    {
        MovementInput.Invoke(GetKeyboardMovement());
    }

    private Vector2f GetKeyboardMovement()
    {
        if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            return new Vector2f(-1, 0);

        if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            return new Vector2f(1, 0);

        return new Vector2f(0, 0);
    }
}
