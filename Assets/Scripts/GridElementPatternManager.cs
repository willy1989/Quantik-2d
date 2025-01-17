using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridElementPatternManager
{
    public bool TwoElementsOfSameShapeAndDifferentColors(GridElement[] gridElements)
    {
        if (gridElements.Length < 2)
        {
            throw new ArgumentException("You need to provide at least 2 elements for a comparison to occur.");
        }

        return gridElements
            .Where(element => element != null)
            .GroupBy(element => element.Shape)
            .Any(group => group.Select(element => element.Color).Distinct().Count() > 1);
    }


    public bool ElementsAreOfDifferentShapes(GridElement[] gridElements)
    {
        if (gridElements.Length < 2)
        {
            throw new ArgumentException("You need to provide at least 2 elements for a comparison to occur.");
        }

        return gridElements
            .Select(element => element.Shape)
            .Distinct()
            .Count() == gridElements.Length;
    }

    public bool WinConditionMet(GridElement[] gridElements) 
    {
        if(gridElements.Length > 4)
        {
            throw new ArgumentException("You should provide exactly 4 gridElements");
        }

        GridElement[] nonNullElements = gridElements.Where(element => element != null).ToArray();

        if (nonNullElements.Length < 4)
            return false;

        // Should be false
        bool noTwoElementsOfSameShapeAndDifferentColors = TwoElementsOfSameShapeAndDifferentColors(nonNullElements);

        // Should be true
        bool allDifferentShapes = ElementsAreOfDifferentShapes(nonNullElements);

        if (noTwoElementsOfSameShapeAndDifferentColors == false && allDifferentShapes == true)
            return true;

        return false;
    }
}
