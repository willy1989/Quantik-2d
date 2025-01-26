using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public GridElement.GridElementColor ElementColor { get; private set; }

    public List<GridElement> StartingGridElements { get; private set; } = new List<GridElement>();

    private Grid grid;

    public Action OnPiecePlaced;

    public Player(GridElement.GridElementColor elementColor, Grid grid)
    {
        this.ElementColor = elementColor;

        this.grid = grid;

        GenerateStartingGridElements();
    }

    private void GenerateStartingGridElements()
    {
        Array shapes = Enum.GetValues(typeof(GridElement.GridElementShape));

        foreach (GridElement.GridElementShape shape in shapes)
        {
            StartingGridElements.Add(new GridElement(shape, ElementColor));
            StartingGridElements.Add(new GridElement(shape, ElementColor));
        }
    }

    public void PlayPiece(GridElement passedGridElement, int xGridCoordinate, int yGridCoordinate)
    {
        // Check whether the shape is still available
        bool isGridElementAvailable = IsGridElementAvailable(passedGridElement);

        if (isGridElementAvailable == false)
            return;

        // Check whether the grid cell is empty or not

        bool cellIsEmpty = grid.IsCellEmpty(xGridCoordinate, yGridCoordinate);

        if (cellIsEmpty == false)
            return;

        // Temporarily add the element on the grid
        grid.AddElement(passedGridElement, xGridCoordinate, yGridCoordinate);

        // Check whether it is legal to add a piece there

        bool rowIsLegal = grid.IsRowLegal(xGridCoordinate, yGridCoordinate);

        bool columnIsLegal = grid.IsColumnLegal(xGridCoordinate, yGridCoordinate);

        bool cornerIsLegal = grid.IsCornerLegal(xGridCoordinate, yGridCoordinate);

        // Remove piece if the move was not legal

        if(rowIsLegal == false || columnIsLegal == false || cornerIsLegal == false)
        {
            grid.RemoveElement(xGridCoordinate, yGridCoordinate);
        }

        else
        {
            UseGridElement(passedGridElement);
        }
    }

    private void UseGridElement(GridElement gridElement)
    {
        StartingGridElements.RemoveAt(StartingGridElements.IndexOf(gridElement));
        OnPiecePlaced?.Invoke();
    }

    private bool IsGridElementAvailable(GridElement gridElement)
    {
        return StartingGridElements.Contains(gridElement);
    }
}
