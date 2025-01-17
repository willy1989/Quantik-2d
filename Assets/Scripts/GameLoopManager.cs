using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoopManager : MonoBehaviour
{
    private Grid grid = new Grid(width: 4, height: 4);

    private GridElementPatternManager gridElementPatternManager = new GridElementPatternManager();

    private Player whitePlayer;
    private Player blackPlayer;

    private Player currentPlayer;

    protected int turnIndex = 0;

    private bool whitePlayerFinishedTheirTurn = false;
    private bool blackPlayerFinishedTheirTurn = false;

    private void Awake()
    {
        whitePlayer = new Player(GridElement.GridElementColor.White, grid);
        blackPlayer = new Player(GridElement.GridElementColor.Black, grid);

        whitePlayer.OnPiecePlaced += IncrementTurnIndex;
        blackPlayer.OnPiecePlaced += IncrementTurnIndex;

        currentPlayer = GetPlayerPlayingThisTurn();
    }

    private void Start()
    {
        // White
        PlayTurn(GridElement.GridElementShape.Pyramid, xGridCoordinate: 0, yGridCoordinate: 0);

        // Black
        PlayTurn(GridElement.GridElementShape.Pyramid, xGridCoordinate: 3, yGridCoordinate: 2);

        // White
        PlayTurn(GridElement.GridElementShape.Cube, xGridCoordinate: 1, yGridCoordinate: 0);

        // Black
        PlayTurn(GridElement.GridElementShape.Cube, xGridCoordinate: 2, yGridCoordinate: 2);

        // White
        PlayTurn(GridElement.GridElementShape.Sphere, xGridCoordinate: 2, yGridCoordinate: 0);

        // Black
        PlayTurn(GridElement.GridElementShape.Sphere, xGridCoordinate: 1, yGridCoordinate: 2);

        // White
        PlayTurn(GridElement.GridElementShape.Cylinder, xGridCoordinate: 3, yGridCoordinate: 0);

        // Black
        PlayTurn(GridElement.GridElementShape.Cylinder, xGridCoordinate: 0, yGridCoordinate: 2);

    }

    private void PlayTurn(GridElement.GridElementShape shape, int xGridCoordinate, int yGridCoordinate)
    {
        Player cachedPlayer = currentPlayer;

        currentPlayer.PlayPiece(shape, xGridCoordinate, yGridCoordinate);

        currentPlayer = GetPlayerPlayingThisTurn();

        if (cachedPlayer != currentPlayer)
        {
            CheckWinCondition(xGridCoordinate, yGridCoordinate);
        }
    }

    // To do: create unit tests
    private Player GetPlayerPlayingThisTurn()
    {
        int turnNumber = turnIndex % 2;

        if (turnNumber == 0)
            return whitePlayer;
        else
            return blackPlayer;
    }

    // To do: create unit tests
    protected void IncrementTurnIndex()
    {
        turnIndex++;
    }

    // To do: create unit tests
    private bool CheckWinCondition(int x, int y)
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
