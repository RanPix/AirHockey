global using Time = PingPong.Core.Time;

using SFML.System;
using PingPong.Assets;

namespace PingPong.Core;

public class Game
{
    private Renderer renderer = new Renderer();
    private Physics physics = new Physics();

    private List<Entity> hierarchy = new List<Entity>()
    {
        new Ball() { position = new Vector2f(400f, 600f), tag = Tag.Ball },
        new Paddle() { position = new Vector2f(400f, 50f), tag = Tag.Platform },
        new Paddle() { position = new Vector2f(400f, 1170f), tag = Tag.Platform },

        new Score(),
    };

    public void Run()
    {
        Time.Start();
        renderer.Start();
        Start();

        while (true)
        {
            Time.Update();
            renderer.Render(hierarchy.ToArray());
            physics.Update(hierarchy.ToArray());
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
