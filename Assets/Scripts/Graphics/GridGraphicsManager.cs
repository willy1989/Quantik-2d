using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGraphicsManager : MonoBehaviour
{
    [SerializeField] private GameObject gridBackgroundTilePrefab;

    [SerializeField] private GameObject CubePiecePrefab;
    [SerializeField] private GameObject PyramidPiecePrefab;
    [SerializeField] private GameObject SpherePiecePrefab;
    [SerializeField] private GameObject CylinderPiecePrefab;

    private Grid grid;

    private Dictionary<GridElement, GameObject> gridElementGridGraphicsDictionary = new Dictionary<GridElement, GameObject>();

    public void SetUp(Grid grid)
    {
        this.grid = grid;
        grid.OnGridElementAdded += AddPieceGraphics;
        grid.OnGridElementRemoved += RemovePieceGraphics;
    }

    public void GeneratebackgroundTiles()
    {
        for (int y = 0; y < grid.Height; y++)
        {
            for (int x = 0; x < grid.Width; x++)
            {
                GameObject gridBackgroundTileInstance = Instantiate(original: gridBackgroundTilePrefab, parent: this.transform);
                gridBackgroundTileInstance.transform.position = new Vector3(x, y, 0);
            }
        }
    }

    private void AddPieceGraphics(GridElement gridElement, int x, int y)
    {
        if (gridElement == null)
            return;

        GameObject instantiatedPieceGraphics = CreatePieceGraphics(gridElement);

        gridElementGridGraphicsDictionary.Add(gridElement, instantiatedPieceGraphics);

        instantiatedPieceGraphics.transform.position = new Vector3(x, y, -1);
    }

    private void RemovePieceGraphics(GridElement gridElement)
    {
        if (gridElement == null)
            return;

        GameObject pieceGraphics = gridElementGridGraphicsDictionary[gridElement];
        Destroy(pieceGraphics.gameObject);
    }


    private GameObject CreatePieceGraphics(GridElement gridElement)
    {
        if(gridElement.Shape == GridElement.GridElementShape.Cube)
        {
            return Instantiate(original: CubePiecePrefab, parent: this.transform);
        }

        else if (gridElement.Shape == GridElement.GridElementShape.Pyramid)
        {
            return Instantiate(original: PyramidPiecePrefab, parent: this.transform);
        }

        else if (gridElement.Shape == GridElement.GridElementShape.Sphere)
        {
            return Instantiate(original: SpherePiecePrefab, parent: this.transform);
        }

        else if (gridElement.Shape == GridElement.GridElementShape.Cylinder)
        {
            return Instantiate(original: CylinderPiecePrefab, parent: this.transform);
        }

        return null;
    }
}
