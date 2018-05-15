using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableTile_v3 : MonoBehaviour
{ 
    public Map_v9 map;
    public int tileX;
    public int tileY;
    public float xLoc;
    public float yLoc;

    void OnMouseUp()
    {

        Debug.Log("Click!");
        map.MoveUnitTo(xLoc, yLoc);

    }
}

