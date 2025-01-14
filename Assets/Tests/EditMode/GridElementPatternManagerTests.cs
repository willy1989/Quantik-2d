using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GridElementPatternManagerTests
{
    public class TwoElementsOfSameShapeAndDifferentColorsArePresentInSet
    {
        private void X_Elements_In_Set_Y_Element_Of_Same_Shape_And_Of_Different_Colors_Return_True_Or_False(GridElement[] gridElements, bool expectedValue)
        {
            // Arrange

            GridElementPatternManager gridElementPatternManager = new GridElementPatternManager();


            // Assert

            bool actualValue = gridElementPatternManager.TwoElementsOfSameShapeAndDifferentColorsArePresentInSet(gridElements);
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void Two_Elements_In_Set_Two_Element_Of_Same_Shape_And_Of_Different_Colors_Return_True()
        {
            GridElement[] gridElements = new GridElement[]
            {
                new GridElement(shape: GridElement.GridElementShape.Pyramid, color: GridElement.GridElementColor.Black),
                new GridElement(shape: GridElement.GridElementShape.Pyramid, color: GridElement.GridElementColor.White),
            };

            X_Elements_In_Set_Y_Element_Of_Same_Shape_And_Of_Different_Colors_Return_True_Or_False(gridElements, expectedValue: true);

        }

        [Test]
        public void Two_Elements_In_Set_Two_Element_Of_Same_Shape_And_Of_Same_Color_Return_False()
        {
            GridElement[] gridElements = new GridElement[]
            {
                new GridElement(shape: GridElement.GridElementShape.Pyramid, color: GridElement.GridElementColor.Black),
                new GridElement(shape: GridElement.GridElementShape.Pyramid, color: GridElement.GridElementColor.Black),
            };

            X_Elements_In_Set_Y_Element_Of_Same_Shape_And_Of_Different_Colors_Return_True_Or_False(gridElements, expectedValue: false);
        }

        [Test]
        public void Two_Elements_In_Set_Two_Element_Of_Different_Shape_And_Of_Same_Color_Return_False()
        {
            GridElement[] gridElements = new GridElement[]
            {
                new GridElement(shape: GridElement.GridElementShape.Cube, color: GridElement.GridElementColor.Black),
                new GridElement(shape: GridElement.GridElementShape.Pyramid, color: GridElement.GridElementColor.Black),
            };

            X_Elements_In_Set_Y_Element_Of_Same_Shape_And_Of_Different_Colors_Return_True_Or_False(gridElements, expectedValue: false);
        }

        [Test]
        public void Two_Elements_In_Set_Two_Element_Of_Different_Shape_And_Of_Different_Color_Return_False()
        {
            GridElement[] gridElements = new GridElement[]
            {
                new GridElement(shape: GridElement.GridElementShape.Cube, color: GridElement.GridElementColor.Black),
                new GridElement(shape: GridElement.GridElementShape.Pyramid, color: GridElement.GridElementColor.White),
            };

            X_Elements_In_Set_Y_Element_Of_Same_Shape_And_Of_Different_Colors_Return_True_Or_False(gridElements, expectedValue: false);
        }
    }
}
