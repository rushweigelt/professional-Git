using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Map_v12 : MonoBehaviour
{
    //official (so far)
    public int width;
    public int height;
    public GameObject fire_prefab;
    public GameObject water_prefab;
    public GameObject enemy_prefab;
    public GameObject basic_prefab;
    public GameObject healing_prefab;
    private GameObject hex_prefab;
    private float charHeight;
    public GameObject SelectedUnit;
    public GameObject enemy;
    public int i;
    public baseUnit birdSubClass;
    //key is xTile, Ytile, value is (unity x, unity y)
    public Dictionary<string, string> tileLocPairs = new Dictionary<string, string>();
    //opposite, so keys are (unityX, unityY) and values are (xTile, Ytile)
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
        i = 1;
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
                int tileType = Random.Range(1, 6);
                
                if (tileType == 1)
                {
                    hex_prefab = fire_prefab;
                }

                else if (tileType == 2)
                {
                    hex_prefab = basic_prefab;
                }
                else if (tileType == 3)
                {
                    hex_prefab = water_prefab;
                }
                else if (tileType == 4)
                {
                    //temporary strings to make entry for list of healing tiles
                    string tmpXStr;
                    string tmpYStr;
                    string healTileStr;
                    //hex prefab assignment
                    hex_prefab = healing_prefab;
                    //string creation
                    tmpXStr = (x - (width / 2)).ToString();
                    tmpYStr = (y - (height / 2)).ToString();
                    healTileStr = '(' + tmpXStr + ", " + tmpYStr + ')';
                    //add tile coordinates to dictionary
                    GameObject liz = GameObject.Find("Lizard");
                    Lizard_v3 lizClass = liz.GetComponent<Lizard_v3>();
                    lizClass.healingTiles.Add(healTileStr);

                }
               
                else if (tileType == 5)
                {

                    string tmpXStr;
                    string tmpYStr;
                    hex_prefab = enemy_prefab;

                    //on all black tiles, spawn an instantiated version of our bird object
                    GameObject bird = (GameObject)Instantiate(enemy, new Vector3(x * x_offset, .5f , y_pos), Quaternion.Euler(90, 180, 0));
                    //name it Bird + i with i incrementing, so we can access them easily
                    bird.name = "Bird " + i;
                    Bird_v3 birdScript = bird.AddComponent<Bird_v3>();
                    Battle_v3 battle = bird.GetComponent<Battle_v3>();
                    //assign each bird with its unity coordinates and its tile coordinates.
                    birdScript.xLoc = (x * x_offset);
                    birdScript.yLoc = (y_pos);
                    birdScript.xTile = (x - (width / 2));
                    birdScript.yTile = (y - (height / 2));
                    tmpXStr = (x - (width / 2)).ToString();
                    tmpYStr = (y - (height / 2)).ToString();
                    birdScript.tileStr = '(' + tmpXStr + ", " + tmpYStr + ')';
                    //create a NEW base unit for each unit, so they do NOT share health
                    baseUnit sub = new baseUnit();
                    battle.self = sub;
                    birdScript.unit = sub;
                    //open lizards list of occupied hexes and append each spawned birds location for tracking
                    GameObject liz = GameObject.Find("Lizard");
                    Battle_v3 lizBattle = liz.GetComponent<Battle_v3>();
                    bird.transform.SetParent(this.transform);
                    lizBattle.OccupiedHexs.Add(birdScript.tileStr, bird.name);

                    //increment i for naming and tracking total number of birds
                    i++;
                }
                //once we randomize which prefab we are using, this is what actually creates, names, and parents each tile in map
                GameObject hex_ob = (GameObject)Instantiate(hex_prefab, new Vector3(x * x_offset, 0, y_pos), Quaternion.Euler(90, 90, 0));
                ClickableTile_v5 ct = hex_ob.AddComponent<ClickableTile_v5>();
                //This assigns values to each tile that contain its location in our coordinate system and in unity gamespace. This is tracked
                //via the ClickableTile script on the MAP game object
                ct.tileX = (x - (width / 2));
                ct.tileY = (y - (height / 2));
                ct.xLoc = x * x_offset;
                ct.yLoc = y_pos;
                ct.x = x;
                ct.y = y;
                ct.map = this;

                //dictionary pairings
                string coor;
                string unityCoor;
                string xString;
                string yString;
                string unityXStr;
                string unityYStr;
                float xFloat;
                float yFloat;
                int xCenterConv;
                int yCenterConv;

                //this was a major update that shifted our coordinate system (behind the scenes mostly) to an orientation
                //where 0,0 was center and everything radiated out from there. Simplified movement in the end
                xCenterConv = (x - (width / 2));
                yCenterConv = (y - (height / 2));
                //creating an (x,y) coordinate pair to store a key of (hexX, hexY)
                xString = xCenterConv.ToString();
                yString = yCenterConv.ToString();
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
                //is also reason our updated coordinate system works 
                //Starts communicating with our neighbor script to determine which hex border one another
                Neighbor_v3 neighbor = hex_ob.AddComponent<Neighbor_v3>();
                //creating and sending info for each neighbor script on each hex
                string xright;
                string xleft;
                string yup;
                string ydown;
                //up down left and right
                xright = (xCenterConv + 1).ToString();
                xleft = (xCenterConv - 1).ToString();
                yup = (yCenterConv + 1).ToString();
                ydown = (yCenterConv - 1).ToString();
                //hex 0 0
                if ((x == 0) & (y == 0))
                {
                    neighbor.neighborX.Add("(" + xright + ", " + yCenterConv + ")");
                    neighbor.neighborY.Add("(" + xCenterConv + ", " + yup + ")");

                }
                //if origin is 0-0 in bottom left, this is top left
                if ((x == 0) & (y == height - 1))
                {
                    neighbor.neighborX.Add("(" + xright + ", " + yCenterConv + ")");
                    neighbor.neighborX.Add("(" + xright + ", " + ydown + ")");
                    neighbor.neighborY.Add("(" + xCenterConv + ", " + ydown + ")");
                }
                //top right
                if ((x == width - 1) & (y == height - 1))
                {
                    neighbor.neighborX.Add("(" + xleft + ", " + yCenterConv + ")");
                    neighbor.neighborX.Add("(" + xleft + ", " + ydown + ")");
                    neighbor.neighborY.Add("(" + xCenterConv + ", " + ydown + ")");
                }
                //bottom right
                if ((x == width - 1) & (y == 0))
                {
                    neighbor.neighborX.Add("(" + xleft + ", " + yCenterConv + ")");
                    neighbor.neighborY.Add("(" + xCenterConv + ", " + yup + ")");
                }
                //left-most x minus the two endpoints
                if ((x == 0) & ((0 < y) & (y < height - 1)))
                {
                    neighbor.neighborX.Add("(" + xright + ", " + yCenterConv + ")");
                    neighbor.neighborX.Add("(" + xright + ", " + ydown + ")");
                    neighbor.neighborY.Add("(" + xCenterConv + ", " + yup + ")");
                    neighbor.neighborY.Add("(" + xCenterConv + ", " + ydown + ")");
                }
                //right-most x minus the two endpoints
                if ((x == width - 1) & ((0 < y) & (y < height - 1)))
                {
                    neighbor.neighborX.Add("(" + xleft + ", " + yCenterConv + ")");
                    neighbor.neighborX.Add("(" + xleft + ", " + ydown + ")");
                    neighbor.neighborY.Add("(" + xCenterConv + ", " + yup + ")");
                    neighbor.neighborY.Add("(" + xCenterConv + ", " + ydown + ")");
                }
                //all even columns at y = 0
                if ((x % 2 == 0) & (x != 0) & (x != width - 1) & (y == 0))
                {
                    neighbor.neighborX.Add("(" + xleft + ", " + yCenterConv + ")");
                    neighbor.neighborX.Add("(" + xright + ", " + yCenterConv + ")");
                    neighbor.neighborY.Add("(" + xCenterConv + ", " + yup + ")");

                }
                //all even columns y = map height
                if ((x % 2 == 0) & (x != 0) & (x != width - 1) & (y == height - 1))
                {
                    neighbor.neighborX.Add("(" + xleft + ", " + yCenterConv + ")");
                    neighbor.neighborX.Add("(" + xright + ", " + yCenterConv + ")");
                    neighbor.neighborX.Add("(" + xleft + ", " + ydown + ")");
                    neighbor.neighborX.Add("(" + xright + ", " + ydown + ")");
                    neighbor.neighborY.Add("(" + xCenterConv + ", " + ydown + ")");
                }
                //all even columns other than y = 0 and y = map height (essentially all even-column non-endpoints)
                if ((x % 2 == 0) & (x != 0) & (x != width - 1) & (y != 0) & (y != height - 1))
                {
                    neighbor.neighborX.Add("(" + xleft + ", " + yCenterConv + ")");
                    neighbor.neighborX.Add("(" + xright + ", " + yCenterConv + ")");
                    neighbor.neighborX.Add("(" + xleft + ", " + ydown + ")");
                    neighbor.neighborX.Add("(" + xright + ", " + ydown + ")");
                    neighbor.neighborY.Add("(" + xCenterConv + ", " + ydown + ")");
                    neighbor.neighborY.Add("(" + xCenterConv + ", " + yup + ")");
                }
                //all odd columns y = 0
                if ((x % 2 == 1) & (y == 0))
                {
                    neighbor.neighborX.Add("(" + xleft + ", " + yCenterConv + ")");
                    neighbor.neighborX.Add("(" + xright + ", " + yCenterConv + ")");
                    neighbor.neighborX.Add("(" + xleft + ", " + yup + ")");
                    neighbor.neighborX.Add("(" + xright + ", " + yup + ")");
                    neighbor.neighborY.Add("(" + xCenterConv + ", " + yup + ")");
                }
                //all odd columns y = height
                if ((x % 2 == 1) & (y == height - 1))
                {
                    neighbor.neighborX.Add("(" + xleft + ", " + yCenterConv + ")");
                    neighbor.neighborX.Add("(" + xright + ", " + yCenterConv + ")");
                    neighbor.neighborY.Add("(" + xCenterConv + ", " + ydown + ")");

                }
                //all odd columns non-endpoints
                if ((x % 2 == 1) & (y != 0) & (y != height - 1))
                {
                    neighbor.neighborX.Add("(" + xleft + ", " + yCenterConv + ")");
                    neighbor.neighborX.Add("(" + xright + ", " + yCenterConv + ")");
                    neighbor.neighborX.Add("(" + xleft + ", " + yup + ")");
                    neighbor.neighborX.Add("(" + xright + ", " + yup + ")");
                    neighbor.neighborY.Add("(" + xCenterConv + ", " + ydown + ")");
                    neighbor.neighborY.Add("(" + xCenterConv + ", " + yup + ")");
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
