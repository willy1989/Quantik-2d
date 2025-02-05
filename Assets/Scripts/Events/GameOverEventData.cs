using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverEventData
{
    public Player winner { get; private set; }

    public GameOverEventData(Player winner)
    {
        this.winner = winner;
    }
}
