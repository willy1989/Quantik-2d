using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GameLoopManagerTests
{
    public class GetPlayerPlayingThisTurn
    {
        private void Turn_X_Return_Y_Player(int turnIndex, Player whitePlayer, Player blackPlayer, Player expectedValue)
        {
            // Arrange

            GameObject gameObject = new GameObject();
            GameLoopManager_TestHelper gameLoopManager_TestHelper = gameObject.AddComponent<GameLoopManager_TestHelper>();

            gameLoopManager_TestHelper.WhitePlayer = whitePlayer;
            gameLoopManager_TestHelper.BlackPlayer = blackPlayer;
            gameLoopManager_TestHelper.TurnIndex = turnIndex;


            // Asset
            Player actualValue = gameLoopManager_TestHelper.GetPlayerPlayingThisTurn_UnitTest();

            Assert.AreEqual(expectedValue, actualValue);
        }

        private PlayerPair BlackAndWhitePlayerPair()
        {
            return new PlayerPair(whitePlayer: new Player(GridElement.GridElementColor.White, grid: null),
                                                   blackPlayer: new Player(GridElement.GridElementColor.Black, grid: null));
        }

        private class PlayerPair
        {
            public Player WhitePlayer { get; private set; }
            public Player BlackPlayer { get; private set; }

            public PlayerPair(Player whitePlayer, Player blackPlayer)
            {
                WhitePlayer = whitePlayer;
                BlackPlayer = blackPlayer;
            }
        }

            [Test]
        public void Turn_0_Return_White_Player()
        {
            PlayerPair playerPair = BlackAndWhitePlayerPair();

            Turn_X_Return_Y_Player(turnIndex: 0, playerPair.WhitePlayer, playerPair.BlackPlayer, expectedValue: playerPair.WhitePlayer);
        }

        [Test]
        public void Turn_1_Return_Black_Player()
        {
            PlayerPair playerPair = BlackAndWhitePlayerPair();

            Turn_X_Return_Y_Player(turnIndex: 1, playerPair.WhitePlayer, playerPair.BlackPlayer, expectedValue: playerPair.BlackPlayer);
        }

        [Test]
        public void Turn_2_Return_White_Player()
        {
            PlayerPair playerPair = BlackAndWhitePlayerPair();

            Turn_X_Return_Y_Player(turnIndex: 2, playerPair.WhitePlayer, playerPair.BlackPlayer, expectedValue: playerPair.WhitePlayer);
        }

        [Test]
        public void Turn_3_Return_Black_Player()
        {
            PlayerPair playerPair = BlackAndWhitePlayerPair();

            Turn_X_Return_Y_Player(turnIndex: 3, playerPair.WhitePlayer, playerPair.BlackPlayer, expectedValue: playerPair.BlackPlayer);
        }
    }

    public class CheckWinCondition
    {
        private void GridCoordinates_X_Y_Set_On_Grid_Return_True_or_False(int x, int y, Grid_TestHelper grid_TestHelper, bool expectedValue)
        {
            // Arrange

            GameObject gameObject = new GameObject();
            GameLoopManager_TestHelper gameLoopManager_TestHelper = gameObject.AddComponent<GameLoopManager_TestHelper>();

            gameLoopManager_TestHelper.Grid = grid_TestHelper;


            // Assert
            bool actualValue = gameLoopManager_TestHelper.CheckWinCondition_UnitTest(x: 0, y: 0);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void GridCoordinates_0_0_Bottom_Row_4_Different_Pieces_Return_True()
        {
            // Arrange
            Grid_TestHelper grid_TestHelper = new Grid_TestHelper(width: 4, height: 4);

            GridElement[] gridElements = new GridElement[]
            {
                new GridElement(shape: GridElement.GridElementShape.Pyramid, color: GridElement.GridElementColor.White),
                new GridElement(shape: GridElement.GridElementShape.Sphere, color: GridElement.GridElementColor.White),
                new GridElement(shape: GridElement.GridElementShape.Cylinder, color: GridElement.GridElementColor.White),
                new GridElement(shape: GridElement.GridElementShape.Cube, color: GridElement.GridElementColor.White),
            };

            grid_TestHelper.GridElements[0] = gridElements[0];
            grid_TestHelper.GridElements[1] = gridElements[1];
            grid_TestHelper.GridElements[2] = gridElements[2];
            grid_TestHelper.GridElements[3] = gridElements[3];

            GridCoordinates_X_Y_Set_On_Grid_Return_True_or_False(x: 0, y: 0, grid_TestHelper, expectedValue: true);
        }

        [Test]
        public void GridCoordinates_0_0_Bottom_Row_3_Different_Pieces_Return_False()
        {
            // Arrange
            Grid_TestHelper grid_TestHelper = new Grid_TestHelper(width: 4, height: 4);

            GridElement[] gridElements = new GridElement[]
            {
                new GridElement(shape: GridElement.GridElementShape.Pyramid, color: GridElement.GridElementColor.White),
                new GridElement(shape: GridElement.GridElementShape.Sphere, color: GridElement.GridElementColor.White),
                new GridElement(shape: GridElement.GridElementShape.Cylinder, color: GridElement.GridElementColor.White),
            };

            grid_TestHelper.GridElements[0] = gridElements[0];
            grid_TestHelper.GridElements[1] = gridElements[1];
            grid_TestHelper.GridElements[2] = gridElements[2];

            GridCoordinates_X_Y_Set_On_Grid_Return_True_or_False(x: 0, y: 0, grid_TestHelper, expectedValue: false);
        }

        [Test]
        public void GridCoordinates_0_0_Second_Column_4_Different_Pieces_Return_True()
        {
            // Arrange
            Grid_TestHelper grid_TestHelper = new Grid_TestHelper(width: 4, height: 4);

            GridElement[] gridElements = new GridElement[]
            {
                new GridElement(shape: GridElement.GridElementShape.Pyramid, color: GridElement.GridElementColor.White),
                new GridElement(shape: GridElement.GridElementShape.Sphere, color: GridElement.GridElementColor.White),
                new GridElement(shape: GridElement.GridElementShape.Cylinder, color: GridElement.GridElementColor.White),
                new GridElement(shape: GridElement.GridElementShape.Cube, color: GridElement.GridElementColor.White),
            };

            grid_TestHelper.GridElements[0] = gridElements[0];
            grid_TestHelper.GridElements[4] = gridElements[1];
            grid_TestHelper.GridElements[8] = gridElements[2];
            grid_TestHelper.GridElements[12] = gridElements[3];

            GridCoordinates_X_Y_Set_On_Grid_Return_True_or_False(x: 0, y: 0, grid_TestHelper, expectedValue: true);
        }

        [Test]
        public void GridCoordinates_0_0_Second_Column_2_Different_Pieces_Return_False()
        {
            // Arrange
            Grid_TestHelper grid_TestHelper = new Grid_TestHelper(width: 4, height: 4);

            GridElement[] gridElements = new GridElement[]
            {
                new GridElement(shape: GridElement.GridElementShape.Pyramid, color: GridElement.GridElementColor.White),
                new GridElement(shape: GridElement.GridElementShape.Cube, color: GridElement.GridElementColor.White),
            };

            grid_TestHelper.GridElements[0] = gridElements[0];
            grid_TestHelper.GridElements[4] = gridElements[1];

            GridCoordinates_X_Y_Set_On_Grid_Return_True_or_False(x: 0, y: 0, grid_TestHelper, expectedValue: false);
        }

        [Test]
        public void GridCoordinates_0_0_Bottom_Left_Corner_4_Different_Pieces_Return_True()
        {
            // Arrange
            Grid_TestHelper grid_TestHelper = new Grid_TestHelper(width: 4, height: 4);

            GridElement[] gridElements = new GridElement[]
            {
                new GridElement(shape: GridElement.GridElementShape.Pyramid, color: GridElement.GridElementColor.White),
                new GridElement(shape: GridElement.GridElementShape.Sphere, color: GridElement.GridElementColor.White),
                new GridElement(shape: GridElement.GridElementShape.Cylinder, color: GridElement.GridElementColor.White),
                new GridElement(shape: GridElement.GridElementShape.Cube, color: GridElement.GridElementColor.White),
            };

            grid_TestHelper.GridElements[0] = gridElements[0];
            grid_TestHelper.GridElements[1] = gridElements[1];
            grid_TestHelper.GridElements[4] = gridElements[2];
            grid_TestHelper.GridElements[5] = gridElements[3];

            GridCoordinates_X_Y_Set_On_Grid_Return_True_or_False(x: 0, y: 0, grid_TestHelper, expectedValue: true);
        }

        [Test]
        public void GridCoordinates_0_1_Bottom_Left_Corner_3_Different_Pieces_Return_False()
        {
            // Arrange
            Grid_TestHelper grid_TestHelper = new Grid_TestHelper(width: 4, height: 4);

            GridElement[] gridElements = new GridElement[]
            {
                new GridElement(shape: GridElement.GridElementShape.Pyramid, color: GridElement.GridElementColor.White),
                new GridElement(shape: GridElement.GridElementShape.Sphere, color: GridElement.GridElementColor.White),
                new GridElement(shape: GridElement.GridElementShape.Cylinder, color: GridElement.GridElementColor.White),
            };

            grid_TestHelper.GridElements[0] = gridElements[0];
            grid_TestHelper.GridElements[1] = gridElements[1];
            grid_TestHelper.GridElements[4] = gridElements[2];

            GridCoordinates_X_Y_Set_On_Grid_Return_True_or_False(x: 0, y: 1, grid_TestHelper, expectedValue: false);
        }
    }
}
