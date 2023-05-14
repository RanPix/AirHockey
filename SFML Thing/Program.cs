using SFML.Window;
using SFML.Graphics;
using SFML.System;
using SFML_Thing.Core;

namespace SFML_Thing;

static class Program
{
    static void Main()
    {
        RenderWindow window = new RenderWindow(new VideoMode(800, 600), "SFML Works!");
        window.Closed += new EventHandler(OnClose);
        window.SetFramerateLimit(165);

        Color windowColor = new Color(0, 255, 0);

        Game game = new Game();
        game.Run();

        while (window.IsOpen)
        {
            window.DispatchEvents();

            window.Clear(windowColor);

            window.Display();
            
        }
    }

    static void OnClose(object sender, EventArgs e)
    {
        // Close the window when OnClose event is received
        RenderWindow window = (RenderWindow)sender;
        window.Close();
    }
}