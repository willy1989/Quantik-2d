using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridElementPatternManager
{
    public bool TwoElementsOfSameShapeAndDifferentColorsArePresentInSet(GridElement[] gridElements)
    {
        // Find same elements

        foreach (GridElement outterLoopElement in gridElements)
        {
            foreach (GridElement innerLoopElement in gridElements)
            {
                if (innerLoopElement == outterLoopElement)
                    continue;

                if(innerLoopElement.Shape == outterLoopElement.Shape &&
                   innerLoopElement.Color != outterLoopElement.Color)
                {
                    return true;
                }
            }
        }

        return false;
    }
    

    public List<GridElement> FindElementsOfSameShape(GridElement[] gridElements, GridElement.GridElementShape targetShape)
    {
        List<GridElement> result = new List<GridElement>();

        foreach (GridElement element in gridElements)
        {
            if(element.Shape == targetShape)
            {
                result.Add(element);
            }
        }

        return result;
    }

    public bool TwoElementsAreOfDifferentColors(GridElement[] gridElements)
    {
        foreach (GridElement outterElement in gridElements)
        {
            foreach (GridElement innerElement in gridElements)
            {
                if (outterElement == innerElement)
                    continue;

                if (outterElement.Color != innerElement.Color)
                    return true;
            }
        }

        return false;
    }
}
