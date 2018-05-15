using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map_v3 : MonoBehaviour
{

    public GameObject hexPrefab;
    // size of map in tiles
    int width = 4;
    int height = 4;
    float x_offset = .9f;
    float y_offset = .8f;

    // Use this for initialization
    void Start()
    {

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {   //odd row?
                float x_pos = x * x_offset;

                if (y % 2 == 1)
                {
                    x_pos += x_offset / 2;
                }

                GameObject hex_ob = (GameObject)Instantiate(hexPrefab, new Vector3(x_pos, 0, y * y_offset), Quaternion.identity);
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
