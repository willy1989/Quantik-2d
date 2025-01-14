using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitTestingUtils : MonoBehaviour
{
    public static GridElement[] CreateGridElements(int quantity, bool elementsAreNull)
    {
        GridElement[] result = new GridElement[quantity];

        for (int i = 0; i < quantity; i++)
        {
            if (elementsAreNull == false)
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
}
