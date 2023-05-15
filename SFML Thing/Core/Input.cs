using SFML.System;
using SFML.Window;

namespace SFML_Thing.Core;

public static class Input
{
    public static Keyboard.Key GetMovementInput()
    {
        if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            return Keyboard.Key.A;

        if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            return Keyboard.Key.D;

        return Keyboard.Key.Unknown;
    }
}
