using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard_v0 : MonoBehaviour
{

    public baseUnit unit;
    public float xLoc;
    public float yLoc;
    public int xTile;
    public int yTile;
    public string tileStr;
    GameObject liz_ob;


    // Use this for initialization
    void Start()
    {
        //start declarations for class
        unit.toonName = "Lizard";
        unit.description = "He eats birds.";
        unit.elementType = "Water";

        unit.attack = 2;
        unit.health = 10;
        unit.movement = 2;
        unit.pageCost = 1;

        unit.Print();
        //fill in location info at start
        characterLocationUpdate();



        //just looking at dict in debug log.
        GameObject board = GameObject.Find("map");
        Map_v10 map = board.GetComponent<Map_v10>();
        foreach (var group in map.tileLocPairs)
            Debug.Log("Key:" + group.Key + " Value:" + group.Value);
        foreach (var group in map.tileLocPairsInverse)
            Debug.Log("Key:" + group.Key + " Value:" + group.Value);

    }

    public void characterLocationUpdate()
    {
        //updates location info. Does so every second, we may want to change to on.click
        Vector3 coor;
        string xLocStr;
        string yLocStr;
        string unityCoorStr;
        string xTileStr;
        string yTileStr;
        float floatUnityX;
        float floatUnityY;

        GameObject liz = GameObject.Find("Lizard");
        GameObject board = GameObject.Find("map");
        Map_v10 map = board.GetComponent<Map_v10>();
        coor = liz.transform.position;
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
    }


    //test movement module
    public void lizardMove()
    {
        //declarations
        string xstr;
        string ystr;
        xstr = xTile.ToString();
        ystr = yTile.ToString();
        float charHeight;

        //finds, assignments
        GameObject board = GameObject.Find("map");
        Map_v10 map = board.GetComponent<Map_v10>();
        ClickableTile_v4 click = board.GetComponent<ClickableTile_v4>();
        GameObject liz = GameObject.Find("Lizard");
        //finds the hex on which the lizard sits
        GameObject currentHex = GameObject.Find("Hex_" + xstr + "_" + ystr);
        //pulls the neighbors for that hex
        Neighbor_v2 neighbors = currentHex.GetComponent<Neighbor_v2>();


        //valid neighbor click
        if (neighbors.neighborX.Contains(click.clickCoor) || neighbors.neighborY.Contains(click.clickCoor))
        {
            //string unityCoor;
            float unityX;
            float unityY;

            //unityCoor = map.tileLocPairs[click.clickCoor];
            unityX = click.xLoc;
            unityY = click.yLoc;
            charHeight = .5f;
            liz.transform.position = new Vector3(unityX, charHeight, unityY);


        }
        //too far to move there
        else
        {
            Debug.Log("Cannot move this far");
        }
    }

}
