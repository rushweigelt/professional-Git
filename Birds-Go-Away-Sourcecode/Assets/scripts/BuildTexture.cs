using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTexture : MonoBehaviour {

    // size of map in tiles
    int width = 4;
    int height = 4;
    float x_offset = .9f;
    float y_offset = .8f;
    // Use this for initialization
    void Start()
    {
        BuildText();
    }
    void BuildText()
    {
        int textWidth = 64;
        int textHeight = 64;

        Texture2D texture = new Texture2D(textWidth, textHeight);
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {

            }
        }
    }

	
	
	// Update is called once per frame
	void Update () {
		
	}
}
