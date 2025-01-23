using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_TestHelper : Player
{
    public List<GridElement.GridElementShape> StartingShapes => base.StartingShapes;

    public GridElement.GridElementColor ElementColor => base.ElementColor;

    public Player_TestHelper(GridElement.GridElementColor elementColor, Grid grid) : base(elementColor, grid)
    {

    }
}
