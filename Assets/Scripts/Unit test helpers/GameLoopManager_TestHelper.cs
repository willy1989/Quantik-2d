using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoopManager_TestHelper : GameLoopManager
{
    public int TurnIndex
    {
        get
        {
            return turnIndex;
        }

        set
        {
            turnIndex = value;
        }
    }

    public Player WhitePlayer
    {
        get
        {
            return whitePlayer;
        }

        set
        {
            whitePlayer = value;
        }
    }

    public Player BlackPlayer
    {
        get
        {
            return blackPlayer;
        }

        set
        {
            blackPlayer = value;
        }
    }

    public void IncrementTurnIndex_UnitTest()
    {
        IncrementTurnIndex();
    }

    public Player GetPlayerPlayingThisTurn_UnitTest()
    {
        return GetPlayerPlayingThisTurn();
    }
}
