﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableTile : MonoBehaviour
{
    public map_v6 board;
    public int tileX;
    public int tileY;
    public float xLoc;
    public float yLoc;

    void OnMouseUp()
    {

        Debug.Log("Click!");
        board.MoveUnitTo(tileX, tileY);
    }
}

