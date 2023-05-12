using SFML.Graphics;

namespace SFML_Thing;

public class Game
{
    Renderer renderer = new Renderer();

    public void Run()
    {
        Start();

        while (true)
        {
            renderer.Render();
            Update();
        }
    }

    private void Start()
    {

    }

    private void Update()
    {

    }
}
