using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : MonoBehaviour
{
    [SerializeField]
    private GridManager gridManager;
    [SerializeField]
    private GameObject player;
    List<GridField> Path = null;
    public int pathIndex = 0;
    public Vector3 targetVector;

    private List<GridField> open;
    private List<GridField> closed;

    public GameObject Player { get => player; set => player = value; }
    public GridManager GridManager { get => gridManager; set => gridManager = value; }


    // Start is called before the first frame update
    void Start()
    {
        FindPath();
        if(Path!=null) Path = calcPath(gridManager.GameGrid.Grid.GetGridObj(player.transform.position));

    }

    // Update is called once per frame
    void Update()
    {
        if (Path == null)
        {
            FindPath();
            Path = calcPath(gridManager.GameGrid.Grid.GetGridObj(player.transform.position));
        }
        MoveToPoint();
    }

    private List<GridField> FindPath()
    {
        if (gridManager.GameGrid != null) {
            Path = new List<GridField>();
            GridField start = gridManager.GameGrid.Grid.GetGridObj(this.transform.position + new Vector3(0.5f, 0.5f, 0));
            GridField end = gridManager.GameGrid.Grid.GetGridObj(player.transform.position + new Vector3(0.5f, 0.5f, 0));
            if (end.TestVal != 0) return null;
            open = new List<GridField> { start };
            closed = new List<GridField>();
            foreach (GridField field in gridManager.GameGrid.Grid.GridFields)
            {
                field.gCost = int.MaxValue;
                field.CalcFCost();
                field.prevField = null;
            }

            start.gCost = 0;
            start.hCost = calcDist(start, end);
            start.CalcFCost();

            while (open.Count > 0)
            {
                GridField curr = GetLowestF(open);
                if (curr == end)
                {
                    return Path;
                }
                open.Remove(curr);
                closed.Add(curr);
                foreach (GridField field in ReturnNeighbours(curr))
                {
                    if (closed.Contains(field) || field.TestVal == 0) continue;
                    int tCost = curr.gCost + calcDist(curr, field);
                    if (tCost < field.gCost)
                    {
                        field.prevField = curr;
                        field.gCost = tCost;
                        field.hCost = calcDist(field, end);
                        field.CalcFCost();
                        if (!open.Contains(field))
                        {
                            open.Add(field);
                        }
                    }
                }
            }

        }
        return null;

    }

    List<GridField> calcPath(GridField end)
    {
        List<GridField> list = new List<GridField>();
        list.Add(end);
        GridField curr = end;
        while (curr.prevField != null)
        {
            list.Add(curr.prevField);
            curr = curr.prevField;
        }
        list.Reverse();
        return list;
    }

    private int calcDist(GridField a, GridField b)
    {
        int x = (int)Mathf.Abs(a.Position.x - b.Position.x);
        int y = (int)Mathf.Abs(a.Position.y - b.Position.y);
        int rest = (int)Mathf.Abs(x - y) * b.TestVal;
        return rest;
    }

    private GridField GetLowestF(List<GridField> fields)
    {
        GridField field = fields[0];
        foreach (GridField x in fields)
        {
            if (field.fCost > x.fCost) field = x;
        }
        return field;
    }


    List<GridField> ReturnNeighbours(GridField field)
    {
        List<GridField> list = new List<GridField>();
        int X = 0, Y = 0;
        gridManager.GameGrid.Grid.GetXZ(field.Position, out X, out Y);
        if (X + 1 < gridManager.GameGrid.Grid.XSize) list.Add(gridManager.GameGrid.Grid.GridFields[X + 1, Y]);
        if (X - 1 >= 0) list.Add(gridManager.GameGrid.Grid.GridFields[X - 1, Y]);
        if (Y + 1 < gridManager.GameGrid.Grid.YSize) list.Add(gridManager.GameGrid.Grid.GridFields[X, Y + 1]);
        if (Y - 1 >= 0) list.Add(gridManager.GameGrid.Grid.GridFields[X, Y - 1]);
        return list;
    }
    float CalcD(List<GridField> list)
    {
        float x = 0;
        foreach (GridField field in list)
        {
            x += field.TestVal;
        }
        return x;
    }

    void MoveToPoint()
    {
        if (Path != null&&Path.Count>0)
        {
            targetVector = Path[pathIndex].Position;
            if (Vector2.Distance(transform.position, targetVector) > 0.1)
            {
                Vector3 movedir = (targetVector - transform.position);
                transform.position = transform.position + movedir * 1 * Time.deltaTime;
            }
            else
            {
                pathIndex++;
                if (pathIndex >= Path.Count)
                {
                    targetVector = Vector3.zero;
                    pathIndex = 0;
                    Path = null;
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        if (Path != null)
        {
            foreach (GridField field in Path)
            {
                if (field.prevField != null) {

                    Gizmos.color = Color.red;
                    Gizmos.DrawLine(field.Position, field.prevField.Position);

                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") Application.LoadLevel(Application.loadedLevel);
    }
}
