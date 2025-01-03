using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class RealGridCoordinateValidatorTests
{
    private void GridCoordinates_X_Y_Return_True_False(int width, int height, int x, int y, bool expectedValue)
    {
        // Arrange

        RealGridCoordinateValidator realGridCoordinateValidator = new RealGridCoordinateValidator();


        // Assert

        bool actualValue = realGridCoordinateValidator.AreGridCoordinatesValid(width, height, x, y);

        Assert.AreEqual(expectedValue, actualValue);
    }

    [Test]
    public void GridCoordinate_0_0_On_2_By_2_Grid_Return_True()
    {
        GridCoordinates_X_Y_Return_True_False(width: 2, height: 2, x: 0, y: 0, expectedValue: true);
    }

    [Test]
    public void GridCoordinate_1_1_On_3_By_3_Grid_Return_True()
    {
        GridCoordinates_X_Y_Return_True_False(width: 3, height: 3, x: 1, y: 1, expectedValue: true);
    }

    [Test]
    public void GridCoordinate_3_3_On_2_By_2_Grid_Return_False()
    {
        GridCoordinates_X_Y_Return_True_False(width: 2, height: 2, x: 3, y: 3, expectedValue: false);
    }

    [Test]
    public void GridCoordinate_Minus_1_0_On_2_By_2_Grid_Return_False()
    {
        GridCoordinates_X_Y_Return_True_False(width: 2, height: 2, x: -1, y: 0, expectedValue: false);
    }

    [Test]
    public void GridCoordinate_Minus_1_Minus_1_On_2_By_2_Grid_Return_False()
    {
        GridCoordinates_X_Y_Return_True_False(width: 2, height: 2, x: -1, y: -1, expectedValue: false);
    }
}
