using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoopManager : MonoBehaviour
{
    private Grid grid = new Grid(width: 4, height: 4);

    private Player whitePlayer;
    private Player blackPlayer;

    private void Start()
    {
        Player whitePlayer = new Player(GridElement.GridElementColor.White, grid);
        Player blackPlayer = new Player(GridElement.GridElementColor.Black, grid);
    }

    


}
