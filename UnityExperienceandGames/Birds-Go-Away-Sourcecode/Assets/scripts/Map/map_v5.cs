using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map_v5 : MonoBehaviour
{
    public int width;
    public int height;
    public GameObject fire_prefab;
    public GameObject water_prefab;
    public GameObject goth_prefab;
    private GameObject hex_prefab;
    // Use this for initialization
    void Start()
    {
        buildMapTiles();
    }
    //buildmap function
    public void buildMapTiles()
    {
        
        // size of map in tiles
        float x_offset = .9f;
        float y_offset = .8f;
        //start loop to formulate grid. The grid ends up WIDTH x HEIGHT Hexs
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {   //odd row? If so, we push it over some. If not, aligned ass normal
                float x_pos = x * x_offset;

                if (y % 2 == 1)
                {
                    x_pos += x_offset / 2;
                }
                //randomize an integer so we can assign what type of tile will be used
                //for each instantiation. Thus, this allows for a randomized tile board.
                int tileType = Random.Range(1, 4);
                    if (tileType == 1)
                    {
                        hex_prefab = fire_prefab;
                    }
                    else if (tileType == 2)
                    {
                        hex_prefab = water_prefab;
                    }
                    else if (tileType == 3)
                    {
                        hex_prefab = goth_prefab;
                    }
                //once it has which prefab to use, this is what actually creates, names, and parents each tile in map
                GameObject hex_ob = (GameObject)Instantiate(hex_prefab, new Vector3(x_pos, 0, y * y_offset), Quaternion.identity);
                hex_ob.name = "Hex_" + x + "_" + y;
                hex_ob.transform.SetParent(this.transform);
            }

        }
    }
    
    // Update is called once per frame
    void Update()
    {

    }
}

