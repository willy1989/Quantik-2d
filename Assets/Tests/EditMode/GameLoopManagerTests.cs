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
}
