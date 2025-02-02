using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoopManager : MonoBehaviour
{
    [SerializeField] private GridGraphicsManager gridGraphicsManager;

    [SerializeField] private MasterInteractionManager masterInteractionManager;

    protected Grid grid;

    private GridElementPatternManager gridElementPatternManager = new GridElementPatternManager();

    protected Player whitePlayer;
    protected Player blackPlayer;

    private Player currentPlayer;

    protected int turnIndex = 0;

    private void Awake()
    {
        SetUp(); 
    }

    private void SetUp()
    {
        grid = new Grid(width: 4, height: 4);

        whitePlayer = new Player(GridElement.GridElementColor.White, grid);
        blackPlayer = new Player(GridElement.GridElementColor.Black, grid);

        currentPlayer = GetPlayerPlayingThisTurn();

        gridGraphicsManager.SetUp(grid);

        masterInteractionManager.Setup(grid, whitePlayer, blackPlayer);
        masterInteractionManager.OnPlaceGridElement += HandleGridElementPlaced;

        masterInteractionManager.SwitchPlayer(currentPlayer);
    }

    private void HandleGridElementPlaced(GridElement gridElement, Vector2Int gridCoordinates)
    {
        bool currentPlayerWins = CheckWinCondition(gridCoordinates.x, gridCoordinates.y);

        if(currentPlayerWins == true)
        {
            Debug.Log(currentPlayer.ElementColor.ToString() + " player wins");
        }

        else
        {
            IncrementTurnIndex();
            currentPlayer = GetPlayerPlayingThisTurn();
            masterInteractionManager.SwitchPlayer(currentPlayer);
        }
    }

    protected Player GetPlayerPlayingThisTurn()
    {
        int turnNumber = turnIndex % 2;

        if (turnNumber == 0)
            return whitePlayer;
        else
            return blackPlayer;
    }

    protected void IncrementTurnIndex()
    {
        turnIndex++;
    }

    protected bool CheckWinCondition(int x, int y)
    {
        GridElement[] rowElements = grid.GetRowFromCoordinatesOfGridElement(x, y);

        if (gridElementPatternManager.WinConditionMet(rowElements) == true)
            return true;

        GridElement[] columnElements = grid.GetColumnFromCoordinatesOfGridElement(x, y);

        if (gridElementPatternManager.WinConditionMet(columnElements) == true)
            return true;

        GridElement[] cornerElements = grid.GetCornerFromCoordinatesOfGridElement(x, y);

        if (gridElementPatternManager.WinConditionMet(cornerElements) == true)
            return true;

        return false;
    }
}
