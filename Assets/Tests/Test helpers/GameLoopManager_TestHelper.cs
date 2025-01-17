using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoopManager_TestHelper : GameLoopManager
{
    public int TurnIndex => turnIndex;

    public void IncrementTurnIndex_UnitTest()
    {
        IncrementTurnIndex();
    }
}
