using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.TestTools;

public class GridTests
{
    public static Grid_TestHelper CreatePopulatedGrid(int width, int height)
    {
        Grid_TestHelper grid_TestHelper = new Grid_TestHelper(width, height);

        GridElement[] gridElements = UnitTestingUtils.CreateGridElements(quantity: width * height, elementsAreNull: false);

        grid_TestHelper.PopulateGrid(gridElements);

        return grid_TestHelper;
    }

    public static Grid_TestHelper CreateEmptyGrid(int width, int height)
    {
        Grid_TestHelper grid_TestHelper = new Grid_TestHelper(width, height);

        GridElement[] gridElements = UnitTestingUtils.CreateGridElements(quantity: width * height, elementsAreNull: true);

        grid_TestHelper.PopulateGrid(gridElements);

        return grid_TestHelper;
    }

    public class CreateGrid
    {
        private void Create_X_By_X_Grid(int width, int height)
        {
            // Arrange

            Grid_TestHelper grid_TestHelper = new Grid_TestHelper(width, height);


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
            Grid_TestHelper grid_TestHelper = CreatePopulatedGrid(width, height);


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

            Grid_TestHelper grid_TestHelper = new Grid_TestHelper(width, height);

            GridElement[] gridElements = UnitTestingUtils.CreateGridElements(quantity: elementsQuantity, elementsAreNull: false);

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
            fakeGridCoordinateValidator.GridCoordinatesAreValid = true;

            Grid_TestHelper grid_TestHelper = new Grid_TestHelper(width, height);
            grid_TestHelper.GridCoordinateValidator = fakeGridCoordinateValidator;

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

            Grid_TestHelper grid_TestHelper = new Grid_TestHelper(width, height);

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

        [Test]
        public void InvalidGridCoordinates_Throw_Argument_Exception()
        {
            // Arrange

            FakeGridCoordinateValidator fakeGridCoordinateValidator = new FakeGridCoordinateValidator();
            fakeGridCoordinateValidator.GridCoordinatesAreValid = false;

            Grid_TestHelper grid_TestHelper = CreateEmptyGrid(2, 2);
            grid_TestHelper.GridCoordinateValidator = fakeGridCoordinateValidator;

            GridElement addedGridElement = new GridElement();


            // Assert

            Assert.Throws<ArgumentException>(() =>
            {
                grid_TestHelper.AddElement(addedGridElement, 0, 0);
            });
        }

        [Test]
        public void Target_Cell_Is_Not_Empty_Throw_Argument_Exception()
        {
            // Arrange

            Grid_TestHelper grid_TestHelper = CreatePopulatedGrid(width: 2, height: 2);

            GridElement addedGridElement = new GridElement();

            // Assert

            Assert.Throws<ArgumentException>(() =>
            {
                grid_TestHelper.AddElement(addedGridElement, 0, 0);
            });
        }
    }

    public class RemoveElement
    {
        private void Coordinates_X_Y_Cell_Full_Removal_Successful(int x, int y)
        {
            // Arrange
            Grid_TestHelper grid_TestHelper = CreatePopulatedGrid(width: 4, height: 4);

            // Act
            grid_TestHelper.RemoveElement(x, y);

            // Assert
            GridElement expectedValue = null;
            GridElement actualValue = grid_TestHelper.GetElementFromGrid(x, y);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void Coordinates_0_0_Cell_Full_Removal_Successful()
        {
            Coordinates_X_Y_Cell_Full_Removal_Successful(x: 0, y: 0);
        }

        [Test]
        public void Coordinates_0_1_Cell_Full_Removal_Successful()
        {
            Coordinates_X_Y_Cell_Full_Removal_Successful(x: 0, y: 1);
        }

        [Test]
        public void GridCoordinates_Are_Not_Valid_Throw_Argument_Exception()
        {
            // Arrange
            Grid_TestHelper grid_TestHelper = CreatePopulatedGrid(width: 4, height: 4);

            Assert.Throws<ArgumentException>(() =>
            {
                grid_TestHelper.RemoveElement(-1, -1);
            });
        }

        [Test]
        public void GridCoordinates_0_0_Cell_Is_Empty_Throw_Argument_Exception()
        {
            // Arrange
            Grid_TestHelper grid_TestHelper = CreateEmptyGrid(width: 4, height: 4);

            Assert.Throws<ArgumentException>(() =>
            {
                grid_TestHelper.RemoveElement(0, 0);
            });
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

    public class GetRowFromCoordinatesOfGridElement
    {
        private void GridCoordinates_X_Y_Grid_4_By_4_Return_Z_Row(int x, int y, int rowIndex)
        {
            // Arrange

            Grid_TestHelper grid_TestHelper = CreatePopulatedGrid(4, 4);


            // Assert

            GridElement[] expectedValue = new GridElement[4];

            for(int i = 0; i < 4; i++)
            {
                expectedValue[i] = grid_TestHelper.GridElements[grid_TestHelper.Width * y + i];
            }

            GridElement[] actualValue = grid_TestHelper.GetRowFromCoordinatesOfGridElement(x, y);

            Assert.AreEqual(expectedValue, actualValue);
        }


        [Test]
        public void GridCoordinates_0_0_Grid_4_By_4_Return_Bottom_Row()
        {
            GridCoordinates_X_Y_Grid_4_By_4_Return_Z_Row(x: 0, y: 0, 0);
        }

        [Test]
        public void GridCoordinates_1_0_Grid_4_By_4_Return_Bottom_Row()
        {
            GridCoordinates_X_Y_Grid_4_By_4_Return_Z_Row(x: 1, y: 0, 0);
        }

        [Test]
        public void GridCoordinates_1_1_Grid_4_By_4_Return_Second_Row_From_Bottom()
        {
            GridCoordinates_X_Y_Grid_4_By_4_Return_Z_Row(x: 1, y: 1, 1);
        }

        [Test]
        public void GridCoordinates_0_3_Grid_4_By_4_Return_First_Row_From_Top()
        {
            GridCoordinates_X_Y_Grid_4_By_4_Return_Z_Row(x: 0, y: 3, 3);
        }

        [Test]
        public void GridCoordinates_Are_Not_Valid_Throw_Argument_Exception()
        {
            // Arrange

            FakeGridCoordinateValidator fakeGridCoordinateValidator = new FakeGridCoordinateValidator();
            fakeGridCoordinateValidator.GridCoordinatesAreValid = false;

            Grid_TestHelper grid_TestHelper = CreatePopulatedGrid(4, 4);
            grid_TestHelper.GridCoordinateValidator = fakeGridCoordinateValidator;

            Assert.Throws<ArgumentException>(() =>
            {
                grid_TestHelper.GetRowFromCoordinatesOfGridElement(0, 0);
            });
        }
    }

    public class GetColumnFromCoordinatesOfGridElement
    {
        private void GridCoordinates_X_Y_Grid_4_By_4_Return_Z_Column(int gridWidth, int gridHeight, int x, int y, int columnIndex)
        {
            // Arrange

            Grid_TestHelper grid_TestHelper = CreatePopulatedGrid(gridWidth, gridHeight);


            // Assert

            GridElement[] expectedValue = new GridElement[gridHeight];

            for (int i = 0; i < gridHeight; i++)
            {
                expectedValue[i] = grid_TestHelper.GridElements[grid_TestHelper.Width * i + x];
            }

            GridElement[] actualValue = grid_TestHelper.GetColumnFromCoordinatesOfGridElement(x, y);

            Assert.AreEqual(expectedValue, actualValue);
        }


        [Test]
        public void GridCoordinates_0_0_Grid_4_By_4_Return_First_Column_From_Left()
        {
            GridCoordinates_X_Y_Grid_4_By_4_Return_Z_Column(gridWidth: 4, gridHeight:4, x: 0, y: 0, columnIndex: 0);
        }

        [Test]
        public void GridCoordinates_0_3_Grid_4_By_4_Return_First_Column_From_Left()
        {
            GridCoordinates_X_Y_Grid_4_By_4_Return_Z_Column(gridWidth: 4, gridHeight: 4, x: 0, y: 3, columnIndex: 0);
        }

        [Test]
        public void GridCoordinates_2_2_Grid_4_By_4_Return_Third_Column_From_Left()
        {
            GridCoordinates_X_Y_Grid_4_By_4_Return_Z_Column(gridWidth: 4, gridHeight: 4, x: 2, y: 2, columnIndex: 2);
        }

        [Test]
        public void GridCoordinates_1_1_Grid_2_By_2_Return_Second_Column_From_Left()
        {
            GridCoordinates_X_Y_Grid_4_By_4_Return_Z_Column(gridWidth: 2, gridHeight: 2, x: 1, y: 1, columnIndex: 1);
        }


        [Test]
        public void GridCoordinates_Are_Not_Valid_Throw_Argument_Exception()
        {
            // Arrange

            FakeGridCoordinateValidator fakeGridCoordinateValidator = new FakeGridCoordinateValidator();
            fakeGridCoordinateValidator.GridCoordinatesAreValid = false;

            Grid_TestHelper grid_TestHelper = CreatePopulatedGrid(4, 4);
            grid_TestHelper.GridCoordinateValidator = fakeGridCoordinateValidator;

            Assert.Throws<ArgumentException>(() =>
            {
                grid_TestHelper.GetColumnFromCoordinatesOfGridElement(0, 0);
            });
        }
    }

    public class GetCornerFromCoordinatesOfGridElement
    {
        private void GridCoordinates_X_Y_Return_Z_Corner(int x, int y, int[] ExpectedGridElementIndexes)
        {
            // Arrange

            Grid_TestHelper grid_TestHelper = CreatePopulatedGrid(4, 4);


            // Assert

            GridElement[] expectedValue = new GridElement[ExpectedGridElementIndexes.Length];

            for(int i = 0; i < ExpectedGridElementIndexes.Length; i++)
            {
                int index = ExpectedGridElementIndexes[i];

                expectedValue[i] = grid_TestHelper.GridElements[index];
            }
           
            GridElement[] actualValue = grid_TestHelper.GetCornerFromCoordinatesOfGridElement(x, y);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void GridCoordinates_0_0_Return_Bottom_Left_Corner()
        {
            int[] expectedGridElementIndexes = new int[] { 0, 1, 4, 5 };

            GridCoordinates_X_Y_Return_Z_Corner(0, 0, expectedGridElementIndexes);
        }

        [Test]
        public void GridCoordinates_2_0_Return_Bottom_Right_Corner()
        {
            int[] expectedGridElementIndexes = new int[] { 2, 3, 6, 7 };

            GridCoordinates_X_Y_Return_Z_Corner(2, 0, expectedGridElementIndexes);
        }

        [Test]
        public void GridCoordinates_1_3_Return_Top_Left_Corner()
        {
            int[] expectedGridElementIndexes = new int[] { 8, 9, 12, 13 };

            GridCoordinates_X_Y_Return_Z_Corner(1, 3, expectedGridElementIndexes);
        }

        [Test]
        public void GridCoordinates_Are_Not_Valid_Throw_Argument_Exception()
        {
            // Arrange

            FakeGridCoordinateValidator fakeGridCoordinateValidator = new FakeGridCoordinateValidator();
            fakeGridCoordinateValidator.GridCoordinatesAreValid = false;

            Grid_TestHelper grid_TestHelper = CreatePopulatedGrid(4, 4);
            grid_TestHelper.GridCoordinateValidator = fakeGridCoordinateValidator;


            // Assert

            Assert.Throws<ArgumentException>(() =>
            {
                grid_TestHelper.GetCornerFromCoordinatesOfGridElement(0, 0);
            });
        }
    }

    public class IsCellEmpty
    {
        private void Coordinates_X_Y_Cell_Is_Empty_Return_True_Or_False(int x, int y, bool gridIsPopulated, bool expectedValue)
        {
            // Arrange

            Grid_TestHelper grid_TestHelper;

            if (gridIsPopulated == true)
            {
                grid_TestHelper = CreatePopulatedGrid(width: 4, height: 4);
            }

            else
            {
                grid_TestHelper = CreateEmptyGrid(width: 4, height: 4);
            }

            // Assert

            bool actualValue = grid_TestHelper.IsCellEmpty(x, y);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void Coordinates_0_0_Cell_Is_Empty_Return_True()
        {
            Coordinates_X_Y_Cell_Is_Empty_Return_True_Or_False(x: 0, y: 0, gridIsPopulated: false, expectedValue: true);
        }

        [Test]
        public void Coordinates_0_1_Cell_Is_Empty_Return_True()
        {
            Coordinates_X_Y_Cell_Is_Empty_Return_True_Or_False(x: 0, y: 1, gridIsPopulated: false, expectedValue: true);
        }

        [Test]
        public void Coordinates_0_0_Cell_Is_Not_Empty_Return_False()
        {
            Coordinates_X_Y_Cell_Is_Empty_Return_True_Or_False(x: 0, y: 1, gridIsPopulated: true, expectedValue: false);
        }

        [Test]
        public void GridCoordinates_Are_Not_Valid_Throw_Argument_Exception()
        {
            // Arrange

            FakeGridCoordinateValidator fakeGridCoordinateValidator = new FakeGridCoordinateValidator();
            fakeGridCoordinateValidator.GridCoordinatesAreValid = false;

            Grid_TestHelper grid_TestHelper = CreatePopulatedGrid(4, 4);
            grid_TestHelper.GridCoordinateValidator = fakeGridCoordinateValidator;

            Assert.Throws<ArgumentException>(() =>
            {
                grid_TestHelper.IsCellEmpty(0, 0);
            });
        }
    }

    public class RowIsLegal
    {
        private void Coordinates_X_Y_Two_Same_Or_Different_Shape_Same_Or_Different_Color_Return_True_Or_False(int x, int y, GridElement[] gridElements, bool expectedValue)
        {
            // Arrange

            Grid_TestHelper grid_TestHelper = new Grid_TestHelper(width: 4, height: 4);

            grid_TestHelper.AddElement(gridElements[0], x: 0, y: 0);
            grid_TestHelper.AddElement(gridElements[1], x: 1, y: 0);
            grid_TestHelper.AddElement(gridElements[2], x: 2, y: 0);
            grid_TestHelper.AddElement(gridElements[3], x: 3, y: 0);

            // Assert
            bool actualValue = grid_TestHelper.RowIsLegal(xGridCoordinate: x, yGridCoordinate: y);

            Assert.AreEqual(expectedValue, actualValue);
        }


        [Test]
        public void Coordinates_0_0_No_Two_Same_Shapes_Return_True()
        {
            GridElement[] gridElements = new GridElement[] 
            {
                new GridElement(shape:GridElement.GridElementShape.Pyramid, color: GridElement.GridElementColor.White),
                new GridElement(shape:GridElement.GridElementShape.Cylinder, color: GridElement.GridElementColor.White),
                new GridElement(shape:GridElement.GridElementShape.Cube, color: GridElement.GridElementColor.White),
                new GridElement(shape:GridElement.GridElementShape.Sphere, color: GridElement.GridElementColor.White),
            };

            Coordinates_X_Y_Two_Same_Or_Different_Shape_Same_Or_Different_Color_Return_True_Or_False(x: 0, y: 0, gridElements, expectedValue: true);
        }

        [Test]
        public void Coordinates_0_0_Two_Same_Shapes_Of_Same_Color_Return_True()
        {
            GridElement[] gridElements = new GridElement[]
            {
                new GridElement(shape:GridElement.GridElementShape.Pyramid, color: GridElement.GridElementColor.White),
                new GridElement(shape:GridElement.GridElementShape.Cylinder, color: GridElement.GridElementColor.White),
                new GridElement(shape:GridElement.GridElementShape.Cylinder, color: GridElement.GridElementColor.White),
                new GridElement(shape:GridElement.GridElementShape.Sphere, color: GridElement.GridElementColor.White),
            };

            Coordinates_X_Y_Two_Same_Or_Different_Shape_Same_Or_Different_Color_Return_True_Or_False(x: 0, y: 0, gridElements, expectedValue: true);
        }

        [Test]
        public void Coordinates_1_0_Two_Same_Shapes_Of_Different_Color_Return_False()
        {
            GridElement[] gridElements = new GridElement[]
            {
                new GridElement(shape:GridElement.GridElementShape.Pyramid, color: GridElement.GridElementColor.White),
                new GridElement(shape:GridElement.GridElementShape.Cylinder, color: GridElement.GridElementColor.White),
                new GridElement(shape:GridElement.GridElementShape.Cylinder, color: GridElement.GridElementColor.Black),
                new GridElement(shape:GridElement.GridElementShape.Sphere, color: GridElement.GridElementColor.White),
            };

            Coordinates_X_Y_Two_Same_Or_Different_Shape_Same_Or_Different_Color_Return_True_Or_False(x: 1, y: 0, gridElements, expectedValue: false);
        }
    }
}
