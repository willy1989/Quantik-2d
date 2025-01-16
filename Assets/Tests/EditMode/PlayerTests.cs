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
        public void X_Different_Shapes_Creates_One_Pair_For_Each_Shape()
        {
            // Arrange

            Player_TestHelper player_TestHelper = new Player_TestHelper(GridElement.GridElementColor.White, new Grid(width: 4, height: 4));


            // Assert

            var shapes = Enum.GetValues(typeof(GridElement.GridElementShape)).Cast<GridElement.GridElementShape>();

            var shapeCounts = player_TestHelper.StartingShapes
                .GroupBy(shape => shape)
                .ToDictionary(group => group.Key, group => group.Count());

            foreach (var shape in shapes)
            {
                Assert.AreEqual(2, shapeCounts.GetValueOrDefault(shape, 0), $"Shape {shape} does not have exactly two occurrences.");
            }
        }
    }

    public class PlayPiece
    {
        [Test]
        public void DummyMethod()
        {
            // Arrange

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

            Player_TestHelper player_TestHelper = new Player_TestHelper(GridElement.GridElementColor.White, grid_TestHelper);


            // Act

            player_TestHelper.PlayPiece(GridElement.GridElementShape.Pyramid, xGridCoordinate: 0, yGridCoordinate: 0);


            // Assert

            


        }
    }
}

