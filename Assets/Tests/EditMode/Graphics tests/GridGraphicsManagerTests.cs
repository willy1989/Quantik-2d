using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GridGraphicsManagerTests
{
    /*public class AddPieceGraphics
    {
        [Test]
        public void Grid_Coordinate_0_0_Graphics_Object_Is_Placed_At_World_Coordinate_0_0_Minus_1()
        {
            // Arrange

            FakeGridGraphicsObjectFactory fakeGridGraphicsObjectFactory = new GameObject().AddComponent<FakeGridGraphicsObjectFactory>();
            GridGraphicsManager_TestHelper gridGraphicsManager_TestHelper = new GameObject().AddComponent<GridGraphicsManager_TestHelper>();
            gridGraphicsManager_TestHelper.GridGraphicsObjectFactory = fakeGridGraphicsObjectFactory;

            GridElement gridElement = new GridElement(shape: GridElement.GridElementShape.Pyramid, GridElement.GridElementColor.Black);

            gridGraphicsManager_TestHelper.AddPieceGraphics_UnitTest(gridElement, 0, 0);


            // Assert

            GameObject instantiatedPieceGraphics = gridGraphicsManager_TestHelper.GridElementGridGraphicsDictionary[gridElement];

            // Check that the graphics object was added to the dictionary
            Assert.IsNotNull(instantiatedPieceGraphics);

            // Check that the graphics object was spawned at the right location
            Assert.AreEqual(new Vector3(0, 0, -1), instantiatedPieceGraphics.transform.position);
        }
    }
    */

    public class PlacePieceGraphicsObject
    {
        [Test]
        public void Grid_Coordinate_0_0_Graphics_Object_Is_Placed_At_World_Coordinate_0_0_Minus_1()
        {
            // Arrange
            GridGraphicsManager_TestHelper gridGraphicsManager_TestHelper = new GameObject().AddComponent<GridGraphicsManager_TestHelper>();
            GridElement gridElement = new GridElement();

            GameObject graphicsObject = new GameObject();

            // Act
            gridGraphicsManager_TestHelper.PlacePieceGraphicsObject_UnitTest(graphicsObject, x: 0, y: 0);

            // Assert
            Assert.AreEqual(new Vector3(0, 0, -1), graphicsObject.transform.position);
        }
    }
}
