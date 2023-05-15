using SFML.System;

namespace SFML_Thing.Core;

public class Game
{
    private Renderer renderer = new Renderer();

    private List<Entity> hierarchy = new List<Entity>()
    {
        new Ball() { position = new Vector2f(400f, 300f), tag = Tag.Ball },
        new Paddle() { position = new Vector2f(400f, 50f), tag = Tag.Platform },
        new Paddle() { position = new Vector2f(400f, 1170f), tag = Tag.Platform },
    };

    public void Run()
    {
        renderer.Init();

        Start();

        while (true)
        {
            renderer.Render(hierarchy.ToArray());
            Update();
        }
    }

    private void Start()
    {
        foreach (Entity entity in hierarchy)
        {
            entity.Start();
        }
    }

    private void Update()
    {
        foreach (Entity entity in hierarchy)
        {
            entity.Update();
        }
    }
}
