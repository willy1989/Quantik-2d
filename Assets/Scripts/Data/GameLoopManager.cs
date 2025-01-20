using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoopManager : MonoBehaviour
{
    [SerializeField] private GridGraphicsManager gridGraphicsManager;

    protected Grid grid;

    private GridElementPatternManager gridElementPatternManager = new GridElementPatternManager();

    protected Player whitePlayer;
    protected Player blackPlayer;

    private Player currentPlayer;

    protected int turnIndex = 0;

    private bool whitePlayerFinishedTheirTurn = false;
    private bool blackPlayerFinishedTheirTurn = false;

    private void Awake()
    {
        SetUp();
    }

    private void Start()
    {
        GridElement gridElement = new GridElement(shape: GridElement.GridElementShape.Pyramid, color: GridElement.GridElementColor.White);

        grid.AddElement(gridElement, x: 0, y: 1);
        grid.RemoveElement(x: 0, y: 1);
    }

    private void SetUp()
    {
        whitePlayer = new Player(GridElement.GridElementColor.White, grid);
        blackPlayer = new Player(GridElement.GridElementColor.Black, grid);

        whitePlayer.OnPiecePlaced += IncrementTurnIndex;
        blackPlayer.OnPiecePlaced += IncrementTurnIndex;

        currentPlayer = GetPlayerPlayingThisTurn();
        grid = new Grid(width: 4, height: 4);

        gridGraphicsManager.SetUp(grid);
        gridGraphicsManager.GeneratebackgroundTiles();
    }

    protected void PlayTurn(GridElement.GridElementShape shape, int xGridCoordinate, int yGridCoordinate)
    {
        Player cachedPlayer = currentPlayer;

        currentPlayer.PlayPiece(shape, xGridCoordinate, yGridCoordinate);

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
