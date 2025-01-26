using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerTests
{
    public class Constructor
    {
        private void Color_X(GridElement.GridElementColor color)
        {
            // Arrange

            Player_TestHelper player_TestHelper = new Player_TestHelper(color, new Grid(width: 4, height:4));


            // Assert

            GridElement.GridElementColor expectedValue = color;

            GridElement.GridElementColor actualValue = player_TestHelper.ElementColor;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void Color_Black()
        {
            Color_X(GridElement.GridElementColor.Black);
        }

        [Test]
        public void Color_White()
        {
            Color_X(GridElement.GridElementColor.White);
        }

        [Test]
        public void X_Different_GridElements_Creates_One_Pair_For_Each_Shape()
        {
            // Arrange
            Player_TestHelper player_TestHelper = new Player_TestHelper(GridElement.GridElementColor.White, new Grid(width: 4, height: 4));

            // Act
            var gridElements = player_TestHelper.StartingGridElements;

            // Group by Shape and Color and count occurrences
            var gridElementsCount = gridElements
                .GroupBy(gridElement => new { gridElement.Shape, gridElement.Color })
                .ToDictionary(group => group.Key, group => group.Count());

            // Assert
            foreach (var group in gridElementsCount)
            {
                Assert.AreEqual(2, group.Value, $"GridElement with Shape={group.Key.Shape} and Color={group.Key.Color} does not have exactly two occurrences.");
            }
        }

    }

    public class PlayPiece
    {
        private Grid_TestHelper Grid_TestHelperFactoryMethod_3_Elements_Bottom_Row()
        {
            Grid_TestHelper grid_TestHelper = new Grid_TestHelper(width: 4, height: 4);

            GridElement[] gridElements =
            {
                new GridElement(shape: GridElement.GridElementShape.Cylinder, color: GridElement.GridElementColor.Black),
                new GridElement(shape: GridElement.GridElementShape.Sphere, color: GridElement.GridElementColor.Black),
                new GridElement(shape: GridElement.GridElementShape.Cube, color: GridElement.GridElementColor.Black),
            };

            grid_TestHelper.AddElement(gridElements[0], x: 1, y: 0);
            grid_TestHelper.AddElement(gridElements[1], x: 2, y: 0);
            grid_TestHelper.AddElement(gridElements[2], x: 3, y: 0);

            return grid_TestHelper;
        }

        private Grid_TestHelper Grid_TestHelperFactoryMethod_Full_Bottom_Row()
        {
            Grid_TestHelper grid_TestHelper = new Grid_TestHelper(width: 4, height: 4);

            GridElement[] gridElements =
            {
                new GridElement(shape: GridElement.GridElementShape.Cylinder, color: GridElement.GridElementColor.Black),
                new GridElement(shape: GridElement.GridElementShape.Sphere, color: GridElement.GridElementColor.Black),
                new GridElement(shape: GridElement.GridElementShape.Cube, color: GridElement.GridElementColor.Black),
                new GridElement(shape: GridElement.GridElementShape.Cube, color: GridElement.GridElementColor.Black),
            };

            grid_TestHelper.AddElement(gridElements[0], x: 0, y: 0);
            grid_TestHelper.AddElement(gridElements[1], x: 1, y: 0);
            grid_TestHelper.AddElement(gridElements[2], x: 2, y: 0);
            grid_TestHelper.AddElement(gridElements[3], x: 3, y: 0);

            return grid_TestHelper;
        }

        private void Coordinate_X_Y_Move_Is_Legal_Piece_Is_Placed(int x, int y, Grid_TestHelper grid_TestHelper, GridElement.GridElementShape shapeToBePlayed)
        {
            // Arrange

            Player_TestHelper player_TestHelper = new Player_TestHelper(GridElement.GridElementColor.White, grid_TestHelper);

            // Pyramid
            GridElement gridElement = player_TestHelper.StartingGridElements[2];

            int startingGridElementsCount = player_TestHelper.StartingGridElements.Count;

            // Act

            player_TestHelper.PlayPiece(gridElement, xGridCoordinate: x, yGridCoordinate: y);


            // Assert
            Assert.IsNotNull(grid_TestHelper.GetElementFromGrid(x, y));
            Assert.AreEqual(player_TestHelper.StartingGridElements.Count, startingGridElementsCount - 1);
        }

        [Test]
        public void Three_Elements_On_Grid_Coordinate_0_0_Move_Is_Legal_Piece_Is_Placed()
        {
            Grid_TestHelper grid_TestHelper = Grid_TestHelperFactoryMethod_3_Elements_Bottom_Row();

            Coordinate_X_Y_Move_Is_Legal_Piece_Is_Placed(x: 0, y: 0, grid_TestHelper, GridElement.GridElementShape.Pyramid);
        }

        [Test]
        public void Three_Elements_On_Grid_Coordinate_0_1_Move_Is_Legal_Piece_Is_Placed()
        {
            Grid_TestHelper grid_TestHelper = Grid_TestHelperFactoryMethod_3_Elements_Bottom_Row();

            Coordinate_X_Y_Move_Is_Legal_Piece_Is_Placed(x: 0, y: 1, grid_TestHelper, GridElement.GridElementShape.Pyramid);
        }

        private void Coordinate_X_Y_Move_Is_illegal_Piece_Is_Not_Placed(int x, int y, Grid_TestHelper grid_TestHelper, GridElement.GridElementShape shapeToBePlayed, GridElement.GridElementColor playerColor)
        {
            // Arrange

            Player_TestHelper player_TestHelper = new Player_TestHelper(playerColor, grid_TestHelper);
            int startingGridElementsCount = player_TestHelper.StartingGridElements.Count;

            GridElement gridElement = new GridElement(shapeToBePlayed, playerColor);

            // Act

            player_TestHelper.PlayPiece(gridElement, xGridCoordinate: x, yGridCoordinate: y);


            // Assert
            Assert.IsNull(grid_TestHelper.GetElementFromGrid(x, y));
            Assert.AreEqual(player_TestHelper.StartingGridElements.Count, startingGridElementsCount);
        }

        [Test]
        public void Four_Elements_On_Grid_Coordinate_0_0_Move_Is_Illegal_Piece_Is_Not_Placed()
        {
            Grid_TestHelper grid_TestHelper = Grid_TestHelperFactoryMethod_3_Elements_Bottom_Row();

            Coordinate_X_Y_Move_Is_illegal_Piece_Is_Not_Placed(x: 0, y: 0, grid_TestHelper, GridElement.GridElementShape.Cylinder, GridElement.GridElementColor.White);
        }
    }
}

