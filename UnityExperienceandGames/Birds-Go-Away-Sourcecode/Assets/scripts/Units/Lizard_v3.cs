using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Lizard_v3 : MonoBehaviour
{

    //data storing declarations
    public baseUnit unit;
    public float xLoc;
    public float yLoc;
    public int xTile;
    public int yTile;
    public int x;
    public int y;
    public string tileStr;
    public string unityStr;
    GameObject liz_ob;
    public GameObject mouseHexPrefab;
    public List<string> actualNeighbors = new List<string>();

    //testing HEALING 
    public List<string> healingTiles = new List<string>();

    // Use this for initialization
    void Start()
    {
        //start declarations for class
        unit.toonName = "Lizard";
        unit.description = "He eats birds.";
        unit.elementType = "Water";

        unit.attack = 2;
        unit.health = 100;
        unit.movement = 2;
        unit.pageCost = 1;

        unit.Print();
        //fill in location info at start
        characterLocationUpdate();



        //grabbing info from the map in an inefficient way. DEBUGS are if you want to look at either coordinate dictionary
        GameObject board = GameObject.Find("map");
        Map_v12 map = board.GetComponent<Map_v12>();
        //foreach (var group in map.tileLocPairs)
          //  Debug.Log("Key:" + group.Key + " Value:" + group.Value);
       //foreach (var group in map.tileLocPairsInverse)
            //Debug.Log("Key:" + group.Key + " Value:" + group.Value);

        //move hexes, getting our location in unity coordinates by looking up the dictionary that stores all the pairs
        unityStr = map.tileLocPairs[tileStr];

        //everything below is to spawn the highlights that show player their possible moves.
        //temporary strings we will be saving to and combining for dictionary and list reasons. 
        string unityXStr;
        string unityYStr;
        string neighUnityStr;
        //down 1 tile
        GameObject moveTiles = (GameObject)Instantiate(mouseHexPrefab, new Vector3(xLoc, 0, (yLoc - .89f)), Quaternion.Euler(90, 90, 0));
        moveTiles.gameObject.tag = "moveHex";
        //we take our unity location, turn it into a string, then add this neighbor to list if it is "in bounds" of map
        unityXStr = xLoc.ToString();
        unityYStr = (yLoc - .89f).ToString();
        neighUnityStr = '(' + unityXStr + ", " + unityYStr + ')';
        actualNeighbors.Add(map.tileLocPairsInverse[neighUnityStr]);
        //to the left 1 and up 1
        if ((xLoc - .76f) > 0 && yLoc + (.445f) < 5.8)
        {
            moveTiles = (GameObject)Instantiate(mouseHexPrefab, new Vector3(xLoc - .76f, 0, yLoc + (.445f)), Quaternion.Euler(90, 90, 0));
            moveTiles.gameObject.tag = "moveHex";
            //we take our unity location, turn it into a string, then add this neighbor to list if it is "in bounds" of map
            unityXStr = (xLoc - .76f).ToString();
            unityYStr = (yLoc + (.445f)).ToString();
            neighUnityStr = '(' + unityXStr + ", " + unityYStr + ')';
            actualNeighbors.Add(map.tileLocPairsInverse[neighUnityStr]);
        }
        //left 1, down 1
        if ( ((xLoc - .76f) > 0) && (yLoc - (.445f) > 0) )
        { 
            moveTiles = (GameObject)Instantiate(mouseHexPrefab, new Vector3(xLoc - (.76f), 0, yLoc - (.445f)), Quaternion.Euler(90, 90, 0));
            moveTiles.gameObject.tag = "moveHex";
            //we take our unity location, turn it into a string, then add this neighbor to list if it is "in bounds" of map
            unityXStr = (xLoc - .76f).ToString();
            unityYStr = (yLoc - (.445f)).ToString();
            neighUnityStr = '(' + unityXStr + ", " + unityYStr + ')';
            actualNeighbors.Add(map.tileLocPairsInverse[neighUnityStr]);
        }
        //to the left 2
        if (xLoc - (.76f * 2) > 0)
        {
            moveTiles = (GameObject)Instantiate(mouseHexPrefab, new Vector3(xLoc - (.76f * 2), 0, yLoc), Quaternion.Euler(90, 90, 0));
            moveTiles.gameObject.tag = "moveHex";
            //we take our unity location, turn it into a string, then add this neighbor to list if it is "in bounds" of map
            unityXStr = (xLoc - (.76f * 2)).ToString();
            unityYStr = (yLoc).ToString();
            neighUnityStr = '(' + unityXStr + ", " + unityYStr + ')';
            actualNeighbors.Add(map.tileLocPairsInverse[neighUnityStr]);
        }
        //to the left 2, up 2
        if ((xLoc - (.76f * 2) > 0) && ((yLoc + .89f) < 5.8))
        {
            moveTiles = (GameObject)Instantiate(mouseHexPrefab, new Vector3(xLoc - (.76f * 2), 0, yLoc + .89f), Quaternion.Euler(90, 90, 0));
            moveTiles.gameObject.tag = "moveHex";
            //we take our unity location, turn it into a string, then add this neighbor to list if it is "in bounds" of map
            unityXStr = (xLoc - (.76f * 2)).ToString();
            unityYStr = (yLoc + .89f).ToString();
            neighUnityStr = '(' + unityXStr + ", " + unityYStr + ')';
            actualNeighbors.Add(map.tileLocPairsInverse[neighUnityStr]);
        }
        //to the left 2, down 2
        if ((xLoc - (.76f * 2) > 0) && ((yLoc - .89f) > 0))
        {
            moveTiles = (GameObject)Instantiate(mouseHexPrefab, new Vector3(xLoc - (.76f * 2), 0, yLoc - .89f), Quaternion.Euler(90, 90, 0));
            moveTiles.gameObject.tag = "moveHex";
            //we take our unity location, turn it into a string, then add this neighbor to list if it is "in bounds" of map
            unityXStr = (xLoc - (.76f * 2)).ToString();
            unityYStr = (yLoc - .89f).ToString();
            neighUnityStr = '(' + unityXStr + ", " + unityYStr + ')';
            actualNeighbors.Add(map.tileLocPairsInverse[neighUnityStr]);
        }
        //to the right one and up
        if ( ((xLoc + (.76f)) < 4.56) && (yLoc + ((.445f)) < 5.8) ) 
        {
            moveTiles = (GameObject)Instantiate(mouseHexPrefab, new Vector3(xLoc + (.76f), 0, yLoc + (.445f)), Quaternion.Euler(90, 90, 0));
            moveTiles.gameObject.tag = "moveHex";
            //we take our unity location, turn it into a string, then add this neighbor to list if it is "in bounds" of map
            unityXStr = (xLoc + .76f).ToString();
            unityYStr = (yLoc + (.445f)).ToString();
            neighUnityStr = '(' + unityXStr + ", " + unityYStr + ')';
            actualNeighbors.Add(map.tileLocPairsInverse[neighUnityStr]);
        }
        //to the right one and down
        if ( ((xLoc + (.76f)) < 4.56) && (yLoc - (.445f) >= 0) )
        { 
            moveTiles = (GameObject)Instantiate(mouseHexPrefab, new Vector3(xLoc + (.76f), 0, yLoc - (.445f)), Quaternion.Euler(90, 90, 0));
            moveTiles.gameObject.tag = "moveHex";
            //we take our unity location, turn it into a string, then add this neighbor to list if it is "in bounds" of map
            unityXStr = (xLoc + .76f).ToString();
            unityYStr = Math.Round((yLoc - .445f), 4).ToString();
            neighUnityStr = '(' + unityXStr + ", " + unityYStr + ')';
            actualNeighbors.Add(map.tileLocPairsInverse[neighUnityStr]);

        }
        //to the right 2
        if ((xLoc + (.76f * 2)) < 4.56)
        {
            moveTiles = (GameObject)Instantiate(mouseHexPrefab, new Vector3(xLoc + (.76f * 2), 0, yLoc), Quaternion.Euler(90, 90, 0));
            moveTiles.gameObject.tag = "moveHex";
            //we take our unity location, turn it into a string, then add this neighbor to list if it is "in bounds" of map
            unityXStr = (xLoc + (.76f * 2)).ToString();
            unityYStr = (yLoc).ToString();
            neighUnityStr = '(' + unityXStr + ", " + unityYStr + ')';
            actualNeighbors.Add(map.tileLocPairsInverse[neighUnityStr]);
        }
        //right 2, up 2
        if (((xLoc + (.76f * 2)) < 4.56) && (yLoc + .89f < 5.8))
        {
            moveTiles = (GameObject)Instantiate(mouseHexPrefab, new Vector3(xLoc + (.76f * 2), 0, yLoc + .89f), Quaternion.Euler(90, 90, 0));
            moveTiles.gameObject.tag = "moveHex";
            //we take our unity location, turn it into a string, then add this neighbor to list if it is "in bounds" of map
            unityXStr = (xLoc + (.76f * 2)).ToString();
            unityYStr = (yLoc + .89f).ToString();
            neighUnityStr = '(' + unityXStr + ", " + unityYStr + ')';
            actualNeighbors.Add(map.tileLocPairsInverse[neighUnityStr]);
        }
        //right 2, up 2
        if (((xLoc + (.76f * 2)) < 4.56) && (yLoc - .89f > 0))
        { 
            moveTiles = (GameObject)Instantiate(mouseHexPrefab, new Vector3(xLoc + (.76f * 2), 0, yLoc - .89f), Quaternion.Euler(90, 90, 0));
            moveTiles.gameObject.tag = "moveHex";
            //we take our unity location, turn it into a string, then add this neighbor to list if it is "in bounds" of map
            unityXStr = (xLoc + (.76f * 2)).ToString();
            unityYStr = (yLoc - .89f).ToString();
            neighUnityStr = '(' + unityXStr + ", " + unityYStr + ')';
            actualNeighbors.Add(map.tileLocPairsInverse[neighUnityStr]);
        }
        //one up
        if ((yLoc + .89f) < 5.8)
        {
            moveTiles = (GameObject)Instantiate(mouseHexPrefab, new Vector3(xLoc, 0, yLoc + .89f), Quaternion.Euler(90, 90, 0));
            moveTiles.gameObject.tag = "moveHex";
            //we take our unity location, turn it into a string, then add this neighbor to list if it is "in bounds" of map
            unityXStr = (xLoc).ToString();
            unityYStr = (yLoc + .89f).ToString();
            neighUnityStr = '(' + unityXStr + ", " + unityYStr + ')';
            actualNeighbors.Add(map.tileLocPairsInverse[neighUnityStr]);
        }
    }
    
    public void characterLocationUpdate()
    {
        //updates location info. Does so when called with "ON CLICK" in ClickableTile script
        //data we will need
        Vector3 coor;
        string xLocStr;
        string yLocStr;
        string unityCoorStr;
        string xTileStr;
        string yTileStr;
        float floatUnityX;
        float floatUnityY;
        //find the lizard and get his coordinates from unity, turn these into a string.
        GameObject liz = GameObject.Find("Lizard");
        GameObject board = GameObject.Find("map");
        Map_v12 map = board.GetComponent<Map_v12>();
        coor = liz.transform.position;
        floatUnityX = coor.x;
        floatUnityY = coor.z;
        xLoc = floatUnityX;
        yLoc = floatUnityY;
        xLocStr = coor.x.ToString();
        yLocStr = coor.z.ToString();
        //create unity coordinate system to search inverse dictionary
        unityCoorStr = '(' + xLocStr + ", " + yLocStr + ')';
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
        //open map and clickable tile
        GameObject board = GameObject.Find("map");
        Map_v12 map = board.GetComponent<Map_v12>();
        ClickableTile_v5 click = board.GetComponent<ClickableTile_v5>();
        //declarations
        string xstr;
        string ystr;
        xstr = click.x.ToString();
        ystr = click.y.ToString();
        float charHeight;

        //opening lizard and lizards battle script for battle
        GameObject liz = GameObject.Find("Lizard");
        Battle_v3 battle = liz.GetComponent<Battle_v3>();
        Lizard_v3 lizClass = liz.GetComponent<Lizard_v3>();

        //give movement permissions: aka these below are the only valid click options to move/attack
            //left or right 2
        if ( ((click.clickX == xTile - 2 & click.clickY == yTile) || (click.clickX == xTile + 2 & click.clickY == yTile)) ||
            //left or right 1
            ((click.clickX == xTile - 1 & click.clickY == yTile) || (click.clickX == xTile + 1 & click.clickY == yTile)) ||
           //diagonal up 2
           ((click.clickX == xTile - 2 & click.clickY == yTile+1) || (click.clickX == xTile + 2 & click.clickY == yTile+1)) ||
           //up and down 1
           ((click.clickX == xTile & click.clickY == yTile-1) || (click.clickX == xTile & click.clickY == yTile+1)) ||
           //diagonal down 2
           ((click.clickX == xTile - 2 & click.clickY == yTile-1) || (click.clickX == xTile + 2 & click.clickY == yTile-1)) ||
            //bug cases, because they are dependent on orientation of x value being odd/even
           //diagonal up 1 if x is even
           (((click.clickX == xTile - 1 & click.clickY == yTile+1) || (click.clickX == xTile + 1 & click.clickY == yTile+1)) & (xTile % 2 == 0)) ||
           //diagonal down 1 if x is odd
           ( ( (click.clickX == xTile - 1 & click.clickY == yTile - 1) || (click.clickX == xTile + 1 & click.clickY == yTile-1) ) & ( (xTile % 2 == 1) || (xTile % 2 == -1) )) )
    
        {
            //names we need
            float unityX;
            float unityY;
            unityX = click.xLoc;
            unityY = click.yLoc;
            charHeight = .5f;
            //checks if the coordinates of the tile clicked on matches the coordinates of a list containing all occupied tiles
            //if true (ie if tile is occuppied) then battle commences

            //this needs to be cleaned up/unwrapped I believe it is wholly unneccessary/redundent here, as battle is called elsewhere
            if (battle.OccupiedHexs.ContainsKey(click.clickCoor))
            {
                //Debug.Log("BATTLE");
                //battle.Battle();
            }

            else if (lizClass.healingTiles.Contains(click.clickCoor))
            {
                //heal
            }

            //otherwise, move if it is a valid destination
            else
            {
                //restart neighbors list because we moved
                actualNeighbors.Clear();

                //find the list of move tiles and destroy all the game objects
                GameObject[] moveTilesArray;
                moveTilesArray = GameObject.FindGameObjectsWithTag("moveHex");
                foreach (GameObject moveTile in moveTilesArray)
                {
                    Destroy(moveTile);
                }
                //move to the unity coordinates of valid click/move/attack tile
                liz.transform.position = new Vector3(unityX, charHeight, unityY);
                //temporary strings we will be using to create next batch of highlight tiles and update our list of neighbors for valid locations
                string unityXStr;
                string unityYStr;
                string neighUnityStr;
                //spawn optional move highlights, ensure these spawns are bound in the map
                //down 1
                if ((unityY - .89f) >= 0)
                {
                    GameObject moveTiles = (GameObject)Instantiate(mouseHexPrefab, new Vector3(unityX, 0, unityY - .89f), Quaternion.Euler(90, 90, 0));
                    moveTiles.gameObject.tag = "moveHex";
                    //we take our unity location, turn it into a string, then add this neighbor to list if it is "in bounds" of map
                    unityXStr = (unityX).ToString();
                    unityYStr = Math.Round((unityY - .89f), 3).ToString();
                    neighUnityStr = '(' + unityXStr + ", " + unityYStr + ')';
                    Debug.Log(neighUnityStr);
                    actualNeighbors.Add(map.tileLocPairsInverse[neighUnityStr]);

                }
                //to the left 1 and up 1
                if (((unityX - .76f) >= 0) && ((unityY + .445f) <= 5.8))
                {
                    GameObject moveTiles = (GameObject)Instantiate(mouseHexPrefab, new Vector3(unityX - .76f, 0, unityY + .445f), Quaternion.Euler(90, 90, 0));
                    moveTiles.gameObject.tag = "moveHex";
                    //we take our unity location, turn it into a string, then add this neighbor to list if it is "in bounds" of map
                    unityXStr = (unityX - .76f).ToString();
                    unityYStr = Math.Round((unityY + .445f), 3).ToString();
                    neighUnityStr = '(' + unityXStr + ", " + unityYStr + ')';
                    actualNeighbors.Add(map.tileLocPairsInverse[neighUnityStr]);
                }
                //left 1, down 1
                if (((unityX - .76f) >= 0) && (unityY - (.445f) >= 0))
                {
                    GameObject moveTiles = (GameObject)Instantiate(mouseHexPrefab, new Vector3(unityX - (.76f), 0, unityY - (.445f)), Quaternion.Euler(90, 90, 0));
                    moveTiles.gameObject.tag = "moveHex";
                    //we take our unity location, turn it into a string, then add this neighbor to list if it is "in bounds" of map
                    unityXStr = (unityX - .76f).ToString();
                    unityYStr = Math.Round((unityY - .445f), 3).ToString();
                    neighUnityStr = '(' + unityXStr + ", " + unityYStr + ')';
                    actualNeighbors.Add(map.tileLocPairsInverse[neighUnityStr]);
                }
                //to the left 2
                if (unityX - (.76f * 2) >= 0)
                {
                    GameObject moveTiles = (GameObject)Instantiate(mouseHexPrefab, new Vector3(unityX - (.76f * 2), 0, unityY), Quaternion.Euler(90, 90, 0));
                    moveTiles.gameObject.tag = "moveHex";
                    //we take our unity location, turn it into a string, then add this neighbor to list if it is "in bounds" of map
                    unityXStr = (unityX - (.76f * 2)).ToString();
                    unityYStr = Math.Round(unityY, 3).ToString();
                    neighUnityStr = '(' + unityXStr + ", " + unityYStr + ')';
                    actualNeighbors.Add(map.tileLocPairsInverse[neighUnityStr]);
                }
                //to the left 2, up 2
                if ((unityX - (.76f * 2) >= 0) && ((unityY + .89f) <= 5.785))
                {
                    GameObject moveTiles = (GameObject)Instantiate(mouseHexPrefab, new Vector3(unityX - (.76f * 2), 0, unityY + .89f), Quaternion.Euler(90, 90, 0));
                    moveTiles.gameObject.tag = "moveHex";
                    //we take our unity location, turn it into a string, then add this neighbor to list if it is "in bounds" of map
                    unityXStr = (unityX - (.76f * 2)).ToString();
                    unityYStr = Math.Round((unityY + .89f), 3).ToString();
                    neighUnityStr = '(' + unityXStr + ", " + unityYStr + ')';
                    actualNeighbors.Add(map.tileLocPairsInverse[neighUnityStr]);

                }
                //to the left 2, down 2
                if ((unityX - (.76f * 2) >= 0) && ((unityY - .89f) >= 0))
                {
                    GameObject moveTiles = (GameObject)Instantiate(mouseHexPrefab, new Vector3(unityX - (.76f * 2), 0, unityY - .89f), Quaternion.Euler(90, 90, 0));
                    moveTiles.gameObject.tag = "moveHex";
                    //we take our unity location, turn it into a string, then add this neighbor to list if it is "in bounds" of map
                    unityXStr = (unityX - (.76f * 2)).ToString();
                    unityYStr = Math.Round((unityY - .89f), 3).ToString();
                    neighUnityStr = '(' + unityXStr + ", " + unityYStr + ')';
                    actualNeighbors.Add(map.tileLocPairsInverse[neighUnityStr]);
                }
                //to the right one, up one
                if (((unityX + .76f) <= 4.56) && ((unityY + (.445f)) <= 5.8))
                {
                    GameObject moveTiles = (GameObject)Instantiate(mouseHexPrefab, new Vector3(unityX + .76f, 0, unityY + (.445f)), Quaternion.Euler(90, 90, 0));
                    moveTiles.gameObject.tag = "moveHex";
                    //we take our unity location, turn it into a string, then add this neighbor to list if it is "in bounds" of map
                    unityXStr = (unityX + .76f).ToString();
                    unityYStr = Math.Round((unityY + .445f), 3).ToString();
                    neighUnityStr = '(' + unityXStr + ", " + unityYStr + ')';
                    actualNeighbors.Add(map.tileLocPairsInverse[neighUnityStr]);
                }
                //to the right one, down 1
                if (((unityX + .76f) <= 4.56) && ((unityY - (.445f)) >= 0))
                {
                    GameObject moveTiles = (GameObject)Instantiate(mouseHexPrefab, new Vector3(unityX + .76f, 0, unityY - .445f), Quaternion.Euler(90, 90, 0));
                    moveTiles.gameObject.tag = "moveHex";
                    //we take our unity location, turn it into a string, then add this neighbor to list if it is "in bounds" of map
                    unityXStr = (unityX + .76f).ToString();
                    unityYStr = Math.Round((unityY - .445f), 3).ToString();
                    neighUnityStr = '(' + unityXStr + ", " + unityYStr + ')';
                    actualNeighbors.Add(map.tileLocPairsInverse[neighUnityStr]);
                }
                //to the right 2
                if ((unityX + (.76f * 2)) <= 4.56)
                {
                    GameObject moveTiles = (GameObject)Instantiate(mouseHexPrefab, new Vector3(unityX + (.76f * 2), 0, unityY), Quaternion.Euler(90, 90, 0));
                    moveTiles.gameObject.tag = "moveHex";
                    //we take our unity location, turn it into a string, then add this neighbor to list if it is "in bounds" of map
                    unityXStr = (unityX + (.76f * 2)).ToString();
                    unityYStr = Math.Round(unityY, 3).ToString();
                    neighUnityStr = '(' + unityXStr + ", " + unityYStr + ')';
                    actualNeighbors.Add(map.tileLocPairsInverse[neighUnityStr]);
                }
                //right 2, up 2
                if (((unityX + (.76f * 2)) <= 4.56) && (unityY + .89f <= 5.8))
                {
                    GameObject moveTiles = (GameObject)Instantiate(mouseHexPrefab, new Vector3(unityX + (.76f * 2), 0, unityY + .89f), Quaternion.Euler(90, 90, 0));
                    moveTiles.gameObject.tag = "moveHex";
                    //we take our unity location, turn it into a string, then add this neighbor to list if it is "in bounds" of map
                    unityXStr = (unityX + (.76f * 2)).ToString();
                    unityYStr = Math.Round((unityY + .89f), 3).ToString();
                    neighUnityStr = '(' + unityXStr + ", " + unityYStr + ')';
                    actualNeighbors.Add(map.tileLocPairsInverse[neighUnityStr]);
                }
                //right 2, up 2
                if (((unityX + (.76f * 2)) <= 4.56) && (unityY - .89f >= 0))
                {
                    GameObject moveTiles = (GameObject)Instantiate(mouseHexPrefab, new Vector3(unityX + (.76f * 2), 0, unityY - .89f), Quaternion.Euler(90, 90, 0));
                    moveTiles.gameObject.tag = "moveHex";
                    //we take our unity location, turn it into a string, then add this neighbor to list if it is "in bounds" of map
                    unityXStr = (unityX + (.76f * 2)).ToString();
                    unityYStr = Math.Round((unityY - .89f), 3).ToString();
                    neighUnityStr = '(' + unityXStr + ", " + unityYStr + ')';
                    actualNeighbors.Add(map.tileLocPairsInverse[neighUnityStr]);
                }
                //one up
                if ((unityY + .89f) <= 5.8)
                {
                    GameObject moveTiles = (GameObject)Instantiate(mouseHexPrefab, new Vector3(unityX, 0, unityY + .89f), Quaternion.Euler(90, 90, 0));
                    moveTiles.gameObject.tag = "moveHex";
                    //we take our unity location, turn it into a string, then add this neighbor to list if it is "in bounds" of map
                    unityXStr = (unityX).ToString();
                    unityYStr = Math.Round((unityY + .89f), 3).ToString();
                    neighUnityStr = '(' + unityXStr + ", " + unityYStr + ')';
                    actualNeighbors.Add(map.tileLocPairsInverse[neighUnityStr]);
                }
            }
        }
        //too far to move there, tell the player so in a better way than this.
        else
        {
            Debug.Log("Cannot move this far");
        }
    }

}
