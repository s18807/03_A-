using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid 
{
    private Grid<GridField> _grid;
    private GameObject _displayQuadPrefab;
    private int _quadDisplayWidth, _quadDisplayHeight;


    public Grid<GridField> Grid { get => _grid; set => _grid = value; }

    public GameGrid(Grid<GridField> grid,Vector3 start, GameObject p_displayQuadPrefab, int p_quadDisplayWidth, int p_quadDisplayHeight)
    {
        _grid = grid;
        _displayQuadPrefab = p_displayQuadPrefab;
        _quadDisplayWidth = p_quadDisplayWidth;
        _quadDisplayHeight = p_quadDisplayHeight;
        BuildGridField(start);
    }

    public void BuildGridField(Vector3 start)
    {
        for (int i = 0; i < _grid.GridFields.GetLength(0); i++)
        {
            for (int j = 0; j < _grid.GridFields.GetLength(1); j++)
            {
                Vector3 pos = Grid.GetWorldPos(i, j)+start;

                if (i < _quadDisplayWidth && j < _quadDisplayHeight)
                {
                    GameObject quad = GameObject.Instantiate(_displayQuadPrefab, pos + Vector3.right * 0.5f + Vector3.up * 0.5f , _displayQuadPrefab.transform.rotation);
                    _grid.GridFields[i, j] = new GridField(quad);

                    if (i == 0 && j == 0)
                        _grid.GridFields[i, j].Quad.GetComponent<Renderer>().material.color = Color.yellow;
                }
                else
                {
                    _grid.GridFields[i, j] = new GridField(null);
                }

                _grid.GridFields[i, j].Position = pos;
            }
        }
    }



}
