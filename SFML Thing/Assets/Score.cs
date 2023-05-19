using PingPong.Core;
using SFML.Graphics;
using SFML_Thing.Assets.Enums;
using SFML_Thing.Core;
using SFML_Thing.Recources;
using SFML.System;
using System.Data;

namespace PingPong.Assets;

public class Score : Entity
{
    public static Score instance;

    private int player1Score;
    private int player2Score;

    private void SetupSingleton()
    {
        if (instance == null)
            instance = this;

        else
            ErrorHandler.Error(new Exception("An instance of score already exists!"));
    }

    public override void Start()
    {
        base.Start();

        SetupSingleton();

        Text text = new Text($"{player1Score} : {player2Score}", new Font(RecourcesManager.GetFont("arial.ttf")));
        graphic = text;

        FloatRect textBounds = text.GetLocalBounds();
        graphic.Origin = new Vector2f(textBounds.Width * 0.5f, textBounds.Height * 0.5f);
        position = position;
    }

    public void Scored(Players player)
    {
        if (player == Players.Player1)
            player1Score++;

        if (player == Players.Player2)
            player2Score++;

        UpdateScoreBoard();
    }

    private void UpdateScoreBoard()
    {
        Text text = (Text)graphic;
        text.DisplayedString = $"{player1Score} : {player2Score}";
        graphic = text;

        FloatRect textBounds = text.GetLocalBounds();
        graphic.Origin = new Vector2f(textBounds.Width * 0.5f, textBounds.Height * 0.5f);
        position = position;
    }
}
