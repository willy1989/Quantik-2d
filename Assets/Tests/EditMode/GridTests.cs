using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GridTests
{
    public static GridElement[] CreateGridElements(int quantity)
    {
        GridElement[] result = new GridElement[quantity];

        for (int i = 0; i < quantity; i++)
        {
            result[i] = new GridElement();
        }

        return result;
    }

    public class CreateGrid
    {
        private void Create_X_By_X_Grid(int width, int height)
        {
            // Arrange

            Grid_TestHelper grid_TestHelper = new Grid_TestHelper(width: width, height: height);


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

            Grid_TestHelper grid_TestHelper = new Grid_TestHelper(width, height);

            GridElement[] gridElements = CreateGridElements(quantity: elementsQuantity);

            grid_TestHelper.PopulateGrid(gridElements);


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

            GridElement[] gridElements = CreateGridElements(quantity: elementsQuantity);

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

    
}
