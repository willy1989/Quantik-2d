using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoopManager : MonoBehaviour
{
    [SerializeField] private GridGraphicsManager gridGraphicsManager;

    [SerializeField] private GridInteractionManager gridInteractionManager;

    [SerializeField] private SelectablePieceInteractionManager selectablePiecesManager;

    protected Grid grid;

    private GridElementPatternManager gridElementPatternManager = new GridElementPatternManager();

    protected Player whitePlayer;
    protected Player blackPlayer;

    private Player currentPlayer;

    protected int turnIndex = 0;

    private void Awake()
    {
        SetUp();
        
        gridInteractionManager.Setup(grid, whitePlayer);
    }

    private void SetUp()
    {
        grid = new Grid(width: 4, height: 4);

        whitePlayer = new Player(GridElement.GridElementColor.White, grid);
        blackPlayer = new Player(GridElement.GridElementColor.Black, grid);

        whitePlayer.OnPiecePlaced += IncrementTurnIndex;
        blackPlayer.OnPiecePlaced += IncrementTurnIndex;

        currentPlayer = GetPlayerPlayingThisTurn();
        

        gridGraphicsManager.SetUp(grid);

        selectablePiecesManager.SetupSelectablePieces(whitePlayer);
    }

    protected void PlayTurn(GridElement gridElement, int xGridCoordinate, int yGridCoordinate)
    {
        Player cachedPlayer = currentPlayer;

        //currentPlayer.PlayPiece(gridElement, shape: null, xGridCoordinate, yGridCoordinate);

        currentPlayer = GetPlayerPlayingThisTurn();

        if (cachedPlayer != currentPlayer)
        {
            CheckWinCondition(xGridCoordinate, yGridCoordinate);
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
