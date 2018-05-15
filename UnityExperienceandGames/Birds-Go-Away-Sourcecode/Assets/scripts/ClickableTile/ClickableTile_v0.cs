using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableTile_v0 : MonoBehaviour
{
    public Map_v10 map;
    public int tileX;
    public int tileY;
    public float xLoc;
    public float yLoc;
    public int clickX;
    public int clickY;
    public string clickCoor;


    void OnMouseUp()

    {
        string xstr;
        string ystr;
        string unityStr;
        string unityStrX;
        string unityStrY;
        GameObject board = GameObject.Find("map");
        Map_v10 map = board.GetComponent<Map_v10>();
        ClickableTile_v4 ct = board.GetComponent<ClickableTile_v4>();

        GameObject liz = GameObject.Find("Lizard");
        lizard lizard = liz.GetComponent<lizard>();

        ct.clickX = tileX;
        ct.clickY = tileY;
        xstr = tileX.ToString();
        ystr = tileY.ToString();

        ct.clickCoor = "(" + xstr + ", " + ystr + ")";

        unityStr = map.tileLocPairs[ct.clickCoor];
        string[] tiles = unityStr.Split(new char[] { '(', ',', ')' });
        //x tile coordinate
        unityStrX = tiles[1];
        unityStrY = tiles[2];
        ct.xLoc = float.Parse(unityStrX);
        //y tile coordinate
        ct.yLoc = float.Parse(unityStrY);


        lizard.lizardMove();
        lizard.characterLocationUpdate();



        /*
        Debug.Log("Click!");
        map.MoveUnitTo(xLoc, yLoc);
        GameObject liz = GameObject.Find("Lizard");
        lizard lizard = liz.GetComponent<lizard>();
        lizard.characterLocationUpdate();
        */

    }
}

