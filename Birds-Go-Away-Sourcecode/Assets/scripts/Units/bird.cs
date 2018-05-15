using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour
{

    public baseUnit unit;
    public float xLoc;
    public float yLoc;
    public int xTile;
    public int yTile;
    public string tileStr;

    // Use this for initialization
    void Start()
    {
        unit.toonName = "Bird";
        unit.description = "Bird is light as a feather";
        unit.elementType = "Pastoral";

        unit.attack = 4;
        unit.health = 4;
        unit.movement = 2;
        unit.pageCost = 1;



        unit.Print();
        //fill in location info at start
        characterLocationUpdateB();



        //just looking at dict in debug log.
        GameObject board = GameObject.Find("map");
        Map_v10 map = board.GetComponent<Map_v10>();
        foreach (var group in map.tileLocPairs)
            Debug.Log("Key:" + group.Key + " Value:" + group.Value);
        foreach (var group in map.tileLocPairsInverse)
            Debug.Log("Key:" + group.Key + " Value:" + group.Value);

    }

    public void characterLocationUpdateB()
    {
        //updates location info. Does so every second, we may want to change to on.click
        Vector3 coor;
        string xLocStr;
        string yLocStr;
        string unityCoorStr;
        //string tileStr;
        string xTileStr;
        string yTileStr;
        float floatUnityX;
        float floatUnityY;

        GameObject bird = GameObject.Find("Bird");
        GameObject board = GameObject.Find("map");
        Map_v10 map = board.GetComponent<Map_v10>();
        coor = bird.transform.position;
        floatUnityX = coor.x;
        floatUnityY = coor.z;
        xLoc = floatUnityX;
        yLoc = floatUnityY;
        xLocStr = coor.x.ToString();
        yLocStr = coor.z.ToString();
        //create unity coordinate system to search inverse dictionary
        unityCoorStr = '(' + xLocStr + ", " + yLocStr + ')';
        Debug.Log(unityCoorStr);
        //takes our unity coordinate system and pulls out the hex (x,y) system from inverse dictionary
        tileStr = map.tileLocPairsInverse[unityCoorStr];
        //split that string from dictionary into the tile numbers
        string[] tiles = tileStr.Split(new char[] { '(', ',', ')' });
        //x tile coordinate
        xTileStr = tiles[1];
        xTile = int.Parse(xTileStr);
        //y tile coordinate
        yTileStr = tiles[2];
        yTile = int.Parse(yTileStr);

        //test
        tileStr = map.tileLocPairsInverse[unityCoorStr];
    }


}
	
