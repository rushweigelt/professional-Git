using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Map_v10 : MonoBehaviour
{
    //official (so far)
    public int width;
    public int height;
    public GameObject fire_prefab;
    public GameObject water_prefab;
    public GameObject goth_prefab;
    private GameObject hex_prefab;
    private float charHeight;
    public GameObject SelectedUnit;

    //testing
    public Dictionary<string, string> tileLocPairs = new Dictionary<string, string>();
    public Dictionary<string, string> tileLocPairsInverse = new Dictionary<string, string>();


    // Use this for initialization
    void Start()
    {
        buildMapTiles();
        /*
        //new test shit
        GameObject liz = GameObject.Find("Lizard");
        battle_v1 battle = liz.GetComponent<battle_v1>();
        OccupiedHexs.Add("P", "P");
        //end new test shit
        */
    }
    //buildmap function
    public void buildMapTiles()
    {

        // size of map in tiles
        float x_offset = .76f;
        float y_offset = .89f;
        //start loop to formulate grid. The grid ends up WIDTH x HEIGHT Hexs
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {   //odd column? If so, we push it over some. If not, aligned ass normal
                float y_pos = y * y_offset;

                if (x % 2 == 1)
                {
                    y_pos += y_offset / 2;
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

                GameObject hex_ob = (GameObject)Instantiate(hex_prefab, new Vector3(x * x_offset, 0, y_pos), Quaternion.Euler(90, 90, 0));
                ClickableTile_v4 ct = hex_ob.AddComponent<ClickableTile_v4>();
                //This assigns values to each tile that contain its location in our coordinate system and in unity gamespace
                ct.tileX = x;
                ct.tileY = y;
                ct.xLoc = x * x_offset;
                ct.yLoc = y_pos;
                ct.map = this;

                //test dictionary pairings
                string coor;
                string unityCoor;
                string xString;
                string yString;
                string unityXStr;
                string unityYStr;
                float xFloat;
                float yFloat;
                
                //creating an (x,y) coordinate pair to store a key of (hexX, hexY)
                xString = x.ToString();
                yString = y.ToString();
                //creating an (x,y) coordinate pair as a value for (HexUnitySpaceX, HexUnitySpaceY)
                xFloat = x * x_offset;
                yFloat = y_pos;
                unityXStr = (xFloat).ToString();
                unityYStr = yFloat.ToString();

                //convert these values to strings for storage in dict
                coor = "(" + xString + ", " + yString + ")";
                unityCoor = "(" + unityXStr + ", " + unityYStr + ")";
                //unityCoor = string.Format("({0:0.0##}, {0:0.0##})", unityXStr, unityYStr);
                //add (hexX, HexY) : (HexUnitySpaceX, HexUnitySpaceY
                tileLocPairs.Add(coor, unityCoor);
                tileLocPairsInverse.Add(unityCoor, coor);



                //Starts communicating with our neighbor script to determine which hex border one another
                Neighbor_v2 neighbor = hex_ob.AddComponent<Neighbor_v2>();
                //creating and sending info for each neighbor script on each hex
                string xright;
                string xleft;
                string yup;
                string ydown;
                //up down left and right
                xright = (x + 1).ToString();
                xleft = (x - 1).ToString();
                yup = (y + 1).ToString();
                ydown = (y - 1).ToString();
                //hex 0 0
                if ((x == 0) & (y == 0))
                {
                    neighbor.neighborX.Add("(" + xright + ", " + y + ")");
                    neighbor.neighborY.Add("(" + x + ", " + yup + ")");

                }
                //if origin is 0-0 in bottom left, this is top left
                if ((x == 0) & (y == height - 1))
                {
                    neighbor.neighborX.Add("(" + xright + ", " + y + ")");
                    neighbor.neighborX.Add("(" + xright + ", " + ydown + ")");
                    neighbor.neighborY.Add("(" + x + ", " + ydown + ")");
                }
                //top right
                if ((x == width-1) & (y == height -1))
                {
                    neighbor.neighborX.Add("(" + xleft + ", " + y + ")");
                    neighbor.neighborX.Add("(" + xleft + ", " + ydown + ")");
                    neighbor.neighborY.Add("(" + x + ", " + ydown + ")");
                }
                //bottom right
                if ((x== width - 1) & (y == 0))
                {
                    neighbor.neighborX.Add("(" + xleft + ", " + y + ")");
                    neighbor.neighborY.Add("(" + x + ", " + yup + ")");
                }
                //left-most x minus the two endpoints
                if ((x == 0) & ((0 < y) & (y < height - 1)))
                {
                    neighbor.neighborX.Add("(" + xright + ", " + y + ")");
                    neighbor.neighborX.Add("(" + xright + ", " + ydown + ")");
                    neighbor.neighborY.Add("(" + x + ", " + yup + ")");
                    neighbor.neighborY.Add("(" + x + ", " + ydown + ")");
                }
                //right-most x minus the two endpoints
                if ((x == width-1) & ((0 < y) & (y < height - 1)))
                {
                    neighbor.neighborX.Add("(" + xleft + ", " + y + ")");
                    neighbor.neighborX.Add("(" + xleft + ", " + ydown + ")");
                    neighbor.neighborY.Add("(" + x + ", " + yup + ")");
                    neighbor.neighborY.Add("(" + x + ", " + ydown + ")");
                }
                //all even columns at y = 0
                if ((x%2==0) & (x != 0) & (x != width - 1) & (y == 0))
                {
                    neighbor.neighborX.Add("(" + xleft + ", " + y + ")");
                    neighbor.neighborX.Add("(" + xright + ", " + y + ")");
                    neighbor.neighborY.Add("(" + x + ", " + yup + ")");
                    
                }
                //all even columns y = map height
                if ((x % 2 == 0) & (x != 0) & (x != width - 1) & (y == height - 1))
                {
                    neighbor.neighborX.Add("(" + xleft + ", " + y + ")");
                    neighbor.neighborX.Add("(" + xright + ", " + y + ")");
                    neighbor.neighborX.Add("(" + xleft + ", " + ydown + ")");
                    neighbor.neighborX.Add("(" + xright + ", " + ydown + ")");
                    neighbor.neighborY.Add("(" + x + ", " + ydown + ")");
                }
                //all even columns other than y = 0 and y = map height (essentially all even-column non-endpoints)
                if ((x % 2 == 0) & (x != 0) & (x != width - 1) & (y != 0) & (y != height-1))
                {
                    neighbor.neighborX.Add("(" + xleft + ", " + y + ")");
                    neighbor.neighborX.Add("(" + xright + ", " + y + ")");
                    neighbor.neighborX.Add("(" + xleft + ", " + ydown + ")");
                    neighbor.neighborX.Add("(" + xright + ", " + ydown + ")");
                    neighbor.neighborY.Add("(" + x + ", " + ydown + ")");
                    neighbor.neighborY.Add("(" + x + ", " + yup + ")");
                }
                //all odd columns y = 0
                if ((x%2==1) & (y == 0))
                {
                    neighbor.neighborX.Add("(" + xleft + ", " + y + ")");
                    neighbor.neighborX.Add("(" + xright + ", " + y + ")");
                    neighbor.neighborX.Add("(" + xleft + ", " + yup + ")");
                    neighbor.neighborX.Add("(" + xright + ", " + yup + ")");
                    neighbor.neighborY.Add("(" + x + ", " + yup + ")");
                }
                //all odd columns y = height
                if ((x % 2 == 1) & (y == height - 1))
                {
                    neighbor.neighborX.Add("(" + xleft + ", " + y + ")");
                    neighbor.neighborX.Add("(" + xright + ", " + y + ")");
                    neighbor.neighborY.Add("(" + x + ", " + ydown + ")");
                   
                }
                //all odd columns non-endpoints
                if ((x%2 == 1) & (y != 0) & (y != height - 1))
                {
                    neighbor.neighborX.Add("(" + xleft + ", " + y + ")");
                    neighbor.neighborX.Add("(" + xright + ", " + y + ")");
                    neighbor.neighborX.Add("(" + xleft + ", " + yup + ")");
                    neighbor.neighborX.Add("(" + xright + ", " + yup + ")");
                    neighbor.neighborY.Add("(" + x + ", " + ydown + ")");
                    neighbor.neighborY.Add("(" + x + ", " + yup + ")");
                }
                //names each hex with coordinate point, puts all instantiated hexs within map empty game element.
                hex_ob.name = "Hex_" + x + "_" + y;
                hex_ob.transform.SetParent(this.transform);



            }

        }
    }
    //move unit method
    public void MoveUnitTo(float x, float y)
    {
        charHeight = .5f;
        SelectedUnit.transform.position = new Vector3(x, charHeight, y);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
