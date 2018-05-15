using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace map_v08
{
    public class map_v8 : MonoBehaviour
    {
        public int width;
        public int height;
        public GameObject fire_prefab;
        public GameObject water_prefab;
        public GameObject goth_prefab;

        private GameObject hex_prefab;
        private float charHeight;

        public GameObject SelectedUnit;
        public Collider collider;
        public MeshFilter MeshFilter;
        //private ClickableTile ct;
        // private ClickableTile ct;
        //private int x;
        //private int y;


        //new 
        private UnitMovement_v1 move;


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
                    ClickableTile_v3 ct = hex_ob.AddComponent<ClickableTile_v3>();
                    //UnitMovement_v1 move = hex_ob.AddComponent<UnitMovement_v1>();
                    ct.tileX = x;
                    ct.tileY = y;
                    ct.xLoc = x_pos;
                    ct.yLoc = y * y_offset;
                    ct.map = this;
                    //ct.Unit = hex_ob.GetComponent<SelectedUnit>;
                    hex_ob.name = "Hex_" + x + "_" + y;

                    //trying to inherient meshes from prefabs(NOT WORKING YET!)
                    Collider collider = hex_prefab.GetComponentInParent<Collider>();
                    MeshFilter meshfilter = hex_prefab.GetComponentInParent<MeshFilter>();
                    hex_ob.transform.SetParent(this.transform);

                    //new shit
                    ct.SelectedUnit = SelectedUnit;
                    ct.move = hex_ob.AddComponent<UnitMovement_v1>();


                }

            }
        }
        /*
        public void MoveUnitTo(float x, float y)
        {
            charHeight = .5f;
            SelectedUnit.transform.position = new Vector3(x, charHeight, y);
        }
        */
        // Update is called once per frame
        void Update()
        {

        }
    }
}

