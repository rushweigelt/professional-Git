using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_v3 : MonoBehaviour
{

    public baseUnit unit;
    public float xLoc;
    public float yLoc;
    public int xTile;
    public int yTile;
    public string tileStr;

    // Use this for initialization, starting bird values
    void Start()
    {
        //str values
        unit.toonName = "Bird";
        unit.description = "Bird is light as a feather";
        unit.elementType = "Pastoral";
        //int values
        unit.attack = 4;
        unit.health = 4;
        unit.movement = 2;
        unit.pageCost = 1;
        //print his opening line. Optional
        unit.Print();

           //can delete everything below this i believe, keeping just in case


        //fill in location info at start
        //this might not need to exist anymore PLEASE CHECK
        //characterLocationUpdateB();
        //Debug.Log(tileStr);



        //just looking at dict in debug log.
        //GameObject board = GameObject.Find("map");
        //Map_v12 map = board.GetComponent<Map_v12>();
        //foreach (var group in map.tileLocPairs)
           // Debug.Log("Key:" + group.Key + " Value:" + group.Value);
        //foreach (var group in map.tileLocPairsInverse)
           // Debug.Log("Key:" + group.Key + " Value:" + group.Value);

    }
    /*
    public void characterLocationUpdateB()
    {

    }
    */
}

