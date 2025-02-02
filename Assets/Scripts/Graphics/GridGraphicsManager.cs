using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGraphicsManager : MonoBehaviour
{
    [SerializeField] private GameObject gridBackgroundTilePrefab;

    [SerializeField] private SpriteGridGraphicsFactory spriteGridGraphicsFactory;

    [SerializeField] private GameObject pieceGraphicsPrefab;

    private Grid grid;

    protected Dictionary<GridElement, GameObject> gridElementGridGraphicsDictionary = new Dictionary<GridElement, GameObject>();

    public void SetUp(Grid grid)
    {
        this.grid = grid;
        grid.OnGridElementAdded += AddPieceGraphics;
        grid.OnGridElementRemoved += RemovePieceGraphics;
    }

    protected void AddPieceGraphics(GridElement gridElement, int x, int y)
    {
        if (gridElement == null)
            return;

        GameObject instantiatedPieceGraphics = Instantiate(pieceGraphicsPrefab);

        instantiatedPieceGraphics.GetComponent<SpriteRenderer>().sprite = spriteGridGraphicsFactory.GetPieceSprite(gridElement);

        gridElementGridGraphicsDictionary.Add(gridElement, instantiatedPieceGraphics);

        PlacePieceGraphicsObject(instantiatedPieceGraphics, x, y);
    }

    protected void PlacePieceGraphicsObject(GameObject pieceGraphicsObject, int x, int y)
    {
        pieceGraphicsObject.transform.position = new Vector3(x, y, -1);
    }

    private void RemovePieceGraphics(GridElement gridElement)
    {
        if (gridElement == null)
            return;

        if (gridElementGridGraphicsDictionary.TryGetValue(gridElement, out GameObject pieceGraphics))
        {
            Destroy(pieceGraphics.gameObject);
            gridElementGridGraphicsDictionary.Remove(gridElement);
        }
    }
}
