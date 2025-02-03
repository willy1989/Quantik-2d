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

    private List<GameObject> instantiatedPieceGraphics = new List<GameObject>();

    private void Awake()
    {
        GameLoopManager.OnResetGame += ResetState;
    }

    public void SetUp(Grid grid)
    {
        this.grid = grid;
        grid.OnGridElementAdded += AddPieceGraphics;
        grid.OnGridElementRemoved += RemovePieceGraphics;
    }

    private void ResetState()
    {
        foreach(GameObject pieceGraphic in instantiatedPieceGraphics)
        {
            Destroy(pieceGraphic.gameObject);
        }

        instantiatedPieceGraphics.Clear();

        gridElementGridGraphicsDictionary.Clear();
    }

    protected void AddPieceGraphics(GridElement gridElement, int x, int y)
    {
        if (gridElement == null)
            return;

        GameObject instantiatedPieceGraphic = Instantiate(pieceGraphicsPrefab);

        instantiatedPieceGraphic.GetComponent<SpriteRenderer>().sprite = spriteGridGraphicsFactory.GetPieceSprite(gridElement);

        instantiatedPieceGraphics.Add(instantiatedPieceGraphic);

        gridElementGridGraphicsDictionary.Add(gridElement, instantiatedPieceGraphic);

        PlacePieceGraphicsObject(instantiatedPieceGraphic, x, y);
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
