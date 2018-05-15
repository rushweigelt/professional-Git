using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map_v4 : MonoBehaviour
{
    public int width;
    public int height;
    public GameObject hexPrefab;



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
    //implement later to delete old hex tiles upon REGENERATION button press
    public void destroyTiles()
    {
        
    }

    public void buildText()
    {
        //texture declarations
        int textWidth = 64;
        int textHeight = 64;

        Texture2D texture = new Texture2D(textWidth, textHeight);
        for (int x = 0; x < textWidth; x++)
        {
            for (int y = 0; y < textHeight; y++)
            {
                texture.SetPixel(x, y, Color.red);
            }
        }
        texture.Apply();
        MeshRenderer mr = GetComponentInChildren<MeshRenderer>();
        mr.sharedMaterial.mainTexture = texture;

    }

    // Update is called once per frame
    void Update()
    {

    }
}

