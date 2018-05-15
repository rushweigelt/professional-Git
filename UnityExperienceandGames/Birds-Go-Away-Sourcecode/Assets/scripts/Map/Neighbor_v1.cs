using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neighbor_v1 : MonoBehaviour {

    //public static Map_v9 map;
    //public static Map_v9 map;
    public int maxX;
    public int maxY;

	// Use this for initialization
	void Start () {
        GameObject board = GameObject.Find("map");
        Map_v9 map = board.GetComponent<Map_v9>();
        maxX = map.width - 1;
        maxY = map.height - 1;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
