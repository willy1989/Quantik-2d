using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GridTests
{
    public static Grid_TestHelper CreatePopulatedGrid(int width, int height, GridCoordinateValidator gridCoordinateValidator)
    {
        Grid_TestHelper grid_TestHelper = new Grid_TestHelper(width, height, gridCoordinateValidator);

        GridElement[] gridElements = CreateGridElements(quantity: width * height, elementsAreEmpty: false);

        grid_TestHelper.PopulateGrid(gridElements);

        return grid_TestHelper;
    }

    public static Grid_TestHelper CreateEmptyGrid(int width, int height)
    {
        RealGridCoordinateValidator realGridCoordinateValidator = new RealGridCoordinateValidator();

        Grid_TestHelper grid_TestHelper = new Grid_TestHelper(width, height, realGridCoordinateValidator);

        GridElement[] gridElements = CreateGridElements(quantity: width * height, elementsAreEmpty: true);

        grid_TestHelper.PopulateGrid(gridElements);

        return grid_TestHelper;
    }

    public static GridElement[] CreateGridElements(int quantity, bool elementsAreEmpty)
    {
        GridElement[] result = new GridElement[quantity];

        for (int i = 0; i < quantity; i++)
        {
            if(elementsAreEmpty == false)
            {
                result[i] = new GridElement();
            }

            else
            {
                result[i] = null;
            }
        }

        return result;
    }

    public class CreateGrid
    {
        private void Create_X_By_X_Grid(int width, int height)
        {
            // Arrange

            RealGridCoordinateValidator realGridCoordinateValidator = new RealGridCoordinateValidator();

            Grid_TestHelper grid_TestHelper = new Grid_TestHelper(width, height, realGridCoordinateValidator);


            // Assert

            bool expectedValue = true;
            bool actualValue = grid_TestHelper.Width == width &&
                               grid_TestHelper.Height == height &&
                               grid_TestHelper.GridElements.Length == width * height;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void Create_2_By_2_Grid()
        {
            Create_X_By_X_Grid(width: 2, height: 2);
        }

        [Test]
        public void Create_3_By_2_Grid()
        {
            Create_X_By_X_Grid(width: 3, height: 2);
        }

        [Test]
        public void Create_4_By_4_Grid()
        {
            Create_X_By_X_Grid(width: 4, height: 4);
        }
    }

    public class PopulateGrid
    {
        private void PopulateGrid_Pass_X_Elements_Grid_Has_X_Elements(int width, int height, int elementsQuantity)
        {
            // Arrange
            RealGridCoordinateValidator realGridCoordinateValidator = new RealGridCoordinateValidator();
            Grid_TestHelper grid_TestHelper = CreatePopulatedGrid(width, height, realGridCoordinateValidator);


            // Assert

            int expectedValue = width * height;
            int actualValue = grid_TestHelper.GridElements.Length;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void PopulateGrid_2_By_2_Grid_Pass_4_Elements_Grid_Has_4_Elements()
        {
            PopulateGrid_Pass_X_Elements_Grid_Has_X_Elements(width: 2, height: 2, elementsQuantity: 4);
        }

        [Test]
        public void PopulateGrid_3_By_2_Grid_Pass_6_Elements_Grid_Has_6_Elements()
        {
            PopulateGrid_Pass_X_Elements_Grid_Has_X_Elements(width: 3, height: 2, elementsQuantity: 6);
        }

        [Test]
        public void PopulateGrid_4_By_4_Grid_Pass_16_Elements_Grid_Has_16_Elements()
        {
            PopulateGrid_Pass_X_Elements_Grid_Has_X_Elements(width: 4, height: 4, elementsQuantity: 16);
        }


        private void PopulateGrid_Pass_X_Elements_Does_Not_Match_Set_Elements_Quantity_Throw_Argument_Error(int width, int height, int elementsQuantity)
        {
            // Arrange
            RealGridCoordinateValidator realGridCoordinateValidator = new RealGridCoordinateValidator();

            Grid_TestHelper grid_TestHelper = new Grid_TestHelper(width, height, realGridCoordinateValidator);

            GridElement[] gridElements = CreateGridElements(quantity: elementsQuantity, elementsAreEmpty: false);

            // Assert

            Assert.Throws<ArgumentException>(() =>
            {
                grid_TestHelper.PopulateGrid(gridElements);
            });
        }

        [Test]
        public void PopulateGrid_Pass_5_Elements_Does_Not_Match_Set_Elements_Quantity_Throw_Argument_Error()
        {
            PopulateGrid_Pass_X_Elements_Does_Not_Match_Set_Elements_Quantity_Throw_Argument_Error(width: 2, height: 2, elementsQuantity: 5);
        }

        [Test]
        public void PopulateGrid_Pass_3_Elements_Does_Not_Match_Set_Elements_Quantity_Throw_Argument_Error()
        {
            PopulateGrid_Pass_X_Elements_Does_Not_Match_Set_Elements_Quantity_Throw_Argument_Error(width: 2, height: 2, elementsQuantity: 3);
        }
    }

    public class GetElementFromGrid
    {
        private void GetElementAt_X_Y_Return_Element(int width, int height, int expectedGridElementIndex, int x, int y)
        {
            // Arrange

            FakeGridCoordinateValidator fakeGridCoordinateValidator = new FakeGridCoordinateValidator();

            Grid_TestHelper grid_TestHelper = new Grid_TestHelper(width, height, fakeGridCoordinateValidator);


            // Assert

            GridElement expectedValue = grid_TestHelper.GridElements[expectedGridElementIndex];
            GridElement actualValue = grid_TestHelper.GetElementFromGrid(x, y);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void On_2_By_2_Grid_GetElementAt_0_0()
        {
            GetElementAt_X_Y_Return_Element(width: 2, height: 2, expectedGridElementIndex:0, x: 0, y: 0);
        }

        [Test]
        public void On_2_By_2_Grid_GetElementAt_0_1()
        {
            GetElementAt_X_Y_Return_Element(width: 2, height: 2, expectedGridElementIndex: 2, x: 0, y: 1);
        }

        [Test]
        public void On_3_By_3_Grid_GetElementAt_1_1()
        {
            GetElementAt_X_Y_Return_Element(width: 3, height: 3, expectedGridElementIndex: 4, x: 1, y: 1);
        }

        private void GetElement_At_Invalid_Coordinates_Throw_ArgumentException(int width, int height, int x, int y)
        {
            // Arrange

            RealGridCoordinateValidator realGridCoordinateValidator = new RealGridCoordinateValidator();

            Grid_TestHelper grid_TestHelper = new Grid_TestHelper(width, height, realGridCoordinateValidator);

            // Assert

            Assert.Throws<ArgumentException>(() =>
            {
                grid_TestHelper.GetElementFromGrid(x,y);
            });
        }

        [Test]
        public void GetElement_At_Invalid_Coordinates_3_3_On_2_By_2_Grid_Throw_ArgumentException()
        {
            GetElement_At_Invalid_Coordinates_Throw_ArgumentException(width: 2, height: 2, x: 3, y: 3);
        }

        [Test]
        public void GetElement_At_Invalid_Coordinates_Minus_1_0_On_2_By_2_Grid_Throw_ArgumentException()
        {
            GetElement_At_Invalid_Coordinates_Throw_ArgumentException(width: 2, height: 2, x: -1, y: 0);
        }

        [Test]
        public void GetElement_At_Invalid_Coordinates_Minus_1_Minus_1_On_2_By_2_Grid_Throw_ArgumentException()
        {
            GetElement_At_Invalid_Coordinates_Throw_ArgumentException(width: 2, height: 2, x: -1, y: -1);
        }
    }

    // To do: check for exceptions
    public class AddElement
    {
        private void GridCoordinates_X_Y_Grid_Cell_Empty_Successfully_Add_Element(int width, int height, int x, int y, int expectedElementGridIndex)
        {
            // Arrange

            Grid_TestHelper grid_TestHelper = CreateEmptyGrid(width, height);

            GridElement addedGridElement = new GridElement();

            grid_TestHelper.AddElement(addedGridElement, x, y);

            // Assert

            GridElement expectedValue = addedGridElement;
            GridElement actualValue = grid_TestHelper.GridElements[expectedElementGridIndex];

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void GridCoordinates_0_0_On_2_By_2_Grid_Grid_Cell_Empty_Successfully_Add_Element()
        {
            GridCoordinates_X_Y_Grid_Cell_Empty_Successfully_Add_Element(width: 2, height: 2, x: 0, y: 0, expectedElementGridIndex: 0);
        }

        [Test]
        public void GridCoordinates_1_1_On_2_By_2_Grid_Grid_Cell_Empty_Successfully_Add_Element()
        {
            GridCoordinates_X_Y_Grid_Cell_Empty_Successfully_Add_Element(width: 2, height: 2, x: 1, y: 1, expectedElementGridIndex: 3);
        }
    }

    public class GridCoordinateIndex
    {
        private void GridCoordinates_X_Y_Return_Z(int width, int height, int x, int y, int expectedGridCoordinateIndex)
        {
            // Arrange

            Grid_TestHelper grid_TestHelper = CreateEmptyGrid(width, height);


            // Assert

            int actualValue = grid_TestHelper.GridCoordinateIndex_UnitTest(x, y);

            Assert.AreEqual(expectedGridCoordinateIndex, actualValue);
        }

        [Test] public void GridCoordinates_0_0_On_2_By_2_Grid_Return_0()
        {
            GridCoordinates_X_Y_Return_Z(width: 2, height:2, x: 0, y: 0, expectedGridCoordinateIndex: 0);
        }

        [Test]
        public void GridCoordinates_2_2_On_3_By_3_Grid_Return_9()
        {
            GridCoordinates_X_Y_Return_Z(width: 3, height: 3, x: 2, y: 2, expectedGridCoordinateIndex: 8);
        }

        [Test]
        public void GridCoordinates_4_4_On_1_By_3_Grid_Return_13()
        {
            GridCoordinates_X_Y_Return_Z(width: 4, height: 4, x: 1, y: 3, expectedGridCoordinateIndex: 13);
        }
    }
}
