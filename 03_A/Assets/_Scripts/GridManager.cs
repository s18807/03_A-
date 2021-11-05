using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{

    [SerializeField, Range(0, 1000)] private int _quadDisplayWidth, _quadDisplayHeight;
    [SerializeField] private GameObject _gridQuadDisplay;
    [SerializeField] private int gridSize;
    [SerializeField] private GameObject corner1;
    [SerializeField] private GameObject corner2;
    [SerializeField] private Tilemap obstacles;
    private GameGrid gameGrid;



    public int GridSize { get => gridSize; set => gridSize = value; }
    public GameGrid GameGrid { get => gameGrid; set => gameGrid = value; }

    private void Start()
    {
        Grid<GridField> grid = new Grid<GridField>((int)((corner2.transform.position.x- corner1.transform.position.x) / gridSize), (int)((corner2.transform.position.y - corner1.transform.position.y) / gridSize), gridSize);
        gameGrid = new GameGrid(grid,corner1.transform.position, _gridQuadDisplay, _quadDisplayWidth, _quadDisplayHeight);

        for (int n = obstacles.cellBounds.xMin; n < obstacles.cellBounds.xMax; n++)
        {
            for (int p = obstacles.cellBounds.yMin; p < obstacles.cellBounds.yMax; p++)
            {
                Vector3Int localPlace = (new Vector3Int(n, p, 0));
                Vector3 place = obstacles.CellToWorld(localPlace);
                if (obstacles.HasTile(localPlace))
                {
                    GridField x = gameGrid.Grid.GetGridObj(place);
                    if (x != null) {
                        x.TestVal = 0;
                    }
                }
            }
        }
        //foreach (GridField g in gameGrid.Grid.GridFields) { Debug.Log(g.TestVal); }

    }


    private void OnDrawGizmos()
    {
        foreach (GridField gridField in gameGrid.Grid.GridFields) {
            Gizmos.DrawSphere(gridField.Position,0.1f);
        }
    }

}
