namespace SFML_Thing.Core;

public class Game
{
    private Renderer renderer = new Renderer();

    private Dictionary<string, Entity> hierarchy = new Dictionary<string, Entity>()
    {
        ["Player1"] = new Player(),
        ["Player2"] = new Player(),
    };

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
        foreach (Entity entity in hierarchy.Values)
        {
            entity.Start();
        }
    }

    private void Update()
    {
        foreach (Entity entity in hierarchy.Values)
        {
            entity.Update();
        }
    }
}
