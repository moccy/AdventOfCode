﻿using System;
using System.Linq;

namespace Y2022D02;

public class Game
{
    Move[] PossibleMoves = GetPossibleMoves();
    GameStatus Status;
    Move OpponentMove;
    Move PlayerMove;

    public Game(string gameString)
    {
        Parse(gameString);
    }

    public int GetPlayerScore()
    {
        var score = Status switch
        {
            GameStatus.Win => 6,
            GameStatus.Draw => 3,
            GameStatus.Loss => 0,
            _ => throw new InvalidOperationException("No game status!")
        };

        score += PlayerMove.Value;

        return score;
    }

    private void Parse(string gameString)
    {
        if (gameString.Length != 3) return;
        var outcomes = gameString.Split(" ");
        if (outcomes.Length != 2) return;

        OpponentMove = outcomes[0] switch
        {
            "A" => PossibleMoves[0],
            "B" => PossibleMoves[1],
            "C" => PossibleMoves[2],
            _ => throw new InvalidOperationException("Opponent move not 'A', 'B', or 'C'.")
        };

        PlayerMove = outcomes[1] switch
        {
            "X" => PossibleMoves.First(m => m.Type == OpponentMove.Beats),
            "Y" => PossibleMoves.First(m => m.Type == OpponentMove.Type),
            "Z" => PossibleMoves.First(m => m.Type == OpponentMove.LosesTo),
            _ => throw new InvalidOperationException("Player outcome not 'X', 'Y', or 'Z'.")
        };

        Status = GetGameStatus();
    }

    private static Move[] GetPossibleMoves()
    {
        return new Move[3]
        {
            new Move
            {
                Type = MoveType.Rock,
                Value = 1,
                Beats = MoveType.Scissors,
                LosesTo = MoveType.Paper
            },
            new Move
            {
                Type = MoveType.Paper,
                Value = 2,
                Beats = MoveType.Rock,
                LosesTo = MoveType.Scissors
            },
            new Move
            {
                Type = MoveType.Scissors,
                Value = 3,
                Beats = MoveType.Paper,
                LosesTo = MoveType.Rock
            }
        };
    }

    private GameStatus GetGameStatus()
    {
        return OpponentMove.Type == PlayerMove.Beats ?
            GameStatus.Win : OpponentMove.Type == PlayerMove.Type ?
                GameStatus.Draw : GameStatus.Loss;
    }

}