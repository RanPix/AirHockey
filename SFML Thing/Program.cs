using PingPong.Assets;
using PingPong.Core;
using SFML.System;
using SFML_Thing.Assets.Enums;

namespace PingPong;

static class Program
{
    private static List<Entity> entities = new List<Entity>()
    {
        new Ball() { position = new Vector2f(400f, 600f), tag = Tag.Ball },
        new Paddle() { position = new Vector2f(400f, 50f), tag = Tag.Paddle, player = Players.Player1, isAI = true },
        new Paddle() { position = new Vector2f(400f, 1170f), tag = Tag.Paddle, player = Players.Player2 },

        new Coin() { tag = Tag.Coin },

        new Score() { position = new Vector2f(400f, 600f) },
    };

    static void Main()
    {
        Game game = new Game(entities);
        game.Run();
    }
}