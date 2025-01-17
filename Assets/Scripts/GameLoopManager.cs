using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoopManager : MonoBehaviour
{
    private Grid grid = new Grid(width: 4, height: 4);

    private Player whitePlayer;
    private Player blackPlayer;

    private Player currentPlayer;

    private int turnIndex = 0;

    private bool whitePlayerFinishedTheirTurn = false;
    private bool blackPlayerFinishedTheirTurn = false;

    private void Awake()
    {
        whitePlayer = new Player(GridElement.GridElementColor.White, grid);
        blackPlayer = new Player(GridElement.GridElementColor.Black, grid);

        whitePlayer.OnPiecePlaced += IncrementTurnIndex;
        blackPlayer.OnPiecePlaced += IncrementTurnIndex;
    }

    private void Start()
    {
        currentPlayer = GetPlayerPlayingThisTurn();

        currentPlayer.PlayPiece(GridElement.GridElementShape.Pyramid, xGridCoordinate:0, yGridCoordinate:0);




        currentPlayer = GetPlayerPlayingThisTurn();

        currentPlayer.PlayPiece(GridElement.GridElementShape.Pyramid, xGridCoordinate: 0, yGridCoordinate: 0);

        currentPlayer = GetPlayerPlayingThisTurn();

        currentPlayer.PlayPiece(GridElement.GridElementShape.Pyramid, xGridCoordinate: 1, yGridCoordinate: 0);




        currentPlayer = GetPlayerPlayingThisTurn();
    }

    private Player GetPlayerPlayingThisTurn()
    {
        int turnNumber = turnIndex % 2;

        if (turnNumber == 0)
            return whitePlayer;
        else
            return blackPlayer;
    }

    private void IncrementTurnIndex()
    {
        turnIndex++;
    }

    private void CheckWinCondition()
    {

    }

    


}
