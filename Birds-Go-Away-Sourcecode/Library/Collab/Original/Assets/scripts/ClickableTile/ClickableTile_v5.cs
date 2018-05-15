using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableTile_v5 : MonoBehaviour
{
    public Map_v12 map;
    public int tileX;
    public int tileY;
    public float xLoc;
    public float yLoc;
    public int clickX;
    public int clickY;
    public int x;
    public int y;
    public string clickCoor;


    void OnMouseUp()

    {
        string xstr;
        string ystr;
        string unityStr;
        string unityStrX;
        string unityStrY;
        //testing
        int length;
        //end testing


        GameObject board = GameObject.Find("map");

        map = board.GetComponent<Map_v12>();
        ClickableTile_v5 ct = board.GetComponent<ClickableTile_v5>();

        GameObject liz = GameObject.Find("Lizard");
        Lizard_v3 lizard = liz.GetComponent<Lizard_v3>();
        Battle_v3 lizBattle = liz.GetComponent<Battle_v3>();
        lizBattle.OccupiedHexs.Remove(lizard.tileStr);

        GameObject mouse = GameObject.Find("mouse");
        MouseInputControl_v3 mouseInput = mouse.GetComponent<MouseInputControl_v3>();

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


        //test from here down(battle testing)
        Battle_v3 battle = liz.GetComponent<Battle_v3>();
        battle.OccupiedHex();
        battle.OccupiedHexList();

        length = battle.OccupiedHexs.Count;

        //selected unit toggling?
        //mouseInput.SelectedUnit();

        if (length == 0)
        {
            Debug.Log("No Occupied Hexs");
        }
        if (length >= 1)
        {
            //foreach (var units in battle.OccupiedHexs)
              //  Debug.Log("Key:" + units.Key + " Value:" + units.Value);
        }
        /*
        Debug.Log("Click!");
        map.MoveUnitTo(xLoc, yLoc);
        GameObject liz = GameObject.Find("Lizard");
        lizard lizard = liz.GetComponent<lizard>();
        lizard.characterLocationUpdate();
        */

    }
}

