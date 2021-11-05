using System;
using System.Collections.Generic;

using UnityEngine;

public class GridField
{
    private Vector3 _position;
    private int _testVal;

    public int gCost, hCost, fCost;

    public GridField prevField;

    private GameObject _quad;

   

    public GridField(GameObject p_quad=null)
    {
        _testVal = 1;
        _quad = p_quad;
    }
    public void CalcFCost() {
        fCost = gCost + hCost;
    }
   
    public GameObject Quad { get => _quad; }
    public int TestVal { get => _testVal; set => _testVal = value; }
    public Vector3 Position { get => _position; set => _position = value; }
}