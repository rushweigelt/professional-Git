using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lizard : MonoBehaviour {

    public baseUnit unit;
    public float xLoc;
    public float yLoc;
    public int xTile;
    public int yTile;
    public string tileStr;
    GameObject liz_ob;


	// Use this for initialization
	void Start () {
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

        //new, for 2-Y movement in a turn
        int twoYup = yTile + 1;
        int twoYDown = yTile - 1;
        string twoYUpStr = twoYup.ToString();
        string twoYDownStr = twoYDown.ToString();
        
        //finds, assignments
        GameObject board = GameObject.Find("map");
        Map_v10 map = board.GetComponent<Map_v10>();
        ClickableTile_v4 click = board.GetComponent<ClickableTile_v4>();
        GameObject liz = GameObject.Find("Lizard");
        //finds the hex on which the lizard sits
        GameObject currentHex = GameObject.Find("Hex_" + xstr + "_" + ystr);
        //2Yup neighbor game object
        GameObject twoYUpHex = GameObject.Find("Hex_" + xstr + "_" + twoYUpStr);
        //2YDown neighbor ob
        GameObject twoYDownHex = GameObject.Find("Hex_" + xstr + "_" + twoYDownStr);
        //pulls the neighbors for that hex
        Neighbor_v2 neighbors = currentHex.GetComponent<Neighbor_v2>();
        //also pulls the neighbor for 1UpYaxis so he can move 1 X, 1 Y, or 2 Y in a single turn
        Neighbor_v2 neighbor2Yup = twoYUpHex.GetComponent<Neighbor_v2>();
        //pulls neighbor 1DownAxis
        Neighbor_v2 neighbor2YDown = twoYDownHex.GetComponent<Neighbor_v2>();



        //new, used to find battle
        Battle_v3 battle = liz.GetComponent<Battle_v3>();

        //valid neighbor click
        if (neighbors.neighborX.Contains(click.clickCoor) || neighbors.neighborY.Contains(click.clickCoor) 
            || neighbor2Yup.neighborY.Contains(click.clickCoor) || neighbor2YDown.neighborY.Contains(click.clickCoor))
        {
            //string unityCoor;
            float unityX;
            float unityY;

            //unityCoor = map.tileLocPairs[click.clickCoor];
            unityX = click.xLoc;
            unityY = click.yLoc;
            charHeight = .5f;



            //new shit to make occupied hexs un-enterable
            if (battle.OccupiedHexs.ContainsKey(click.clickCoor)) 
            {
                battle.Battle();
            }
            //otherwise, move if it is a valid destination
            else
            {
                liz.transform.position = new Vector3(unityX, charHeight, unityY);
            }
            
            
            
        }
        //too far to move there
        else
        {
            Debug.Log("Cannot move this far");
        }
    }
    
}
