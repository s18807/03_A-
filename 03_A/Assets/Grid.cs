using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Grid<TGridObj>
{
    private int _xSize;
    private int _ySize;
    private int _size;
    private TGridObj[,] gridFields;

    public TGridObj[,] GridFields { get => gridFields; set => gridFields = value; }
    public int XSize { get => _xSize; set => _xSize = value; }
    public int YSize { get => _ySize; set => _ySize = value; }

    public Grid(int x, int y, int size)
    {
        this._xSize = x;
        this._ySize = y;
        this._size = size;
        gridFields = new TGridObj[x, y];
    }

    public Vector3 GetWorldPos(int x, int y)
    {
        return new Vector3(x, y, 0) * _size + Vector3.right * 0.5f * _size + Vector3.up * 0.5f * _size;
    }

    public void GetXZ(Vector3 WorldPos, out int x, out int y)
    {
        x = Mathf.FloorToInt(WorldPos.x / _size) - 1;
        y = Mathf.FloorToInt(WorldPos.y / _size) - 1;
        if (x < 0) x = 0;
        if (y < 0) y = 0;
    }

    public void ReadValueFromGrid(Vector3 WorldPos)
    {
        int x, y;
        GetXZ(WorldPos, out x, out y);
        Debug.Log(gridFields[x, y]);
    }
    public Vector3 GetPosOnGrid(Vector3 WorldPos, out int x, out int y)
    {
        GetXZ(WorldPos, out x, out y);
        return GetWorldPos(x, y);
    }

    public TGridObj GetGridObj(Vector3 pos)
    {
        int x, y;
        GetXZ(pos, out x, out y);
        if (x > 0 && y > 0 && y < _ySize && x < _xSize) return gridFields[x, y];
        else return default;
    }
    public TGridObj GetGridObj(int x, int y)
    {
        return gridFields[x, y];
    }
}
