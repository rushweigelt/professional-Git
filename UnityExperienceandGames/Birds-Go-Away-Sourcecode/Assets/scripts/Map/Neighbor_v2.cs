using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neighbor_v2 : MonoBehaviour
{
    public int maxX;
    public int maxY;
    public List<string> neighborX = new List<string>();
    public List<string> neighborY = new List<string>();

    // Use this for initialization
    void Start()
    {
        //List<int> neighborX = new List<int>();
        //neighborX.Add(3);
        GameObject board = GameObject.Find("map");
        Map_v10 map = board.GetComponent<Map_v10>();
        maxX = map.width - 1;
        maxY = map.height - 1;

        //Debug.Log(neighborX);

         
    }

    // Update is called once per frame
    void Update()
    {

    }
}
