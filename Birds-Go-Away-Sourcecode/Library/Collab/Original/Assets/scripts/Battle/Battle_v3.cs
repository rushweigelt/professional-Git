using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle_v3 : MonoBehaviour
{

    public baseUnit self;
    public baseUnit enemy;
    public Dictionary<string, string> OccupiedHexs = new Dictionary<string, string>();
    public int birdsSlain = 0;

    public void Battle()
    {
        //access lizard and his battle script
        GameObject liz = GameObject.Find("Lizard");
        Lizard_v3 lizClass = liz.GetComponent<Lizard_v3>();
        Battle_v3 lizBattle = liz.GetComponent<Battle_v3>();
        //access the map and clickableTile scripts
        GameObject board = GameObject.Find("map");
        Map_v12 map = board.GetComponent<Map_v12>();
        ClickableTile_v5 click = board.GetComponent<ClickableTile_v5>();
        //debug info about battle
        Debug.Log("A Battle has Begun!");
        //attack lowers the enemy's health
        enemy.health = enemy.health - self.attack;
        Debug.Log("Bird has " + enemy.health + " health remaining!");
        //it also hurts our hero equal to enemy's attack value.
        self.health = self.health - enemy.attack;
        Debug.Log(self.name + " has " + self.health + " health remaining!");
        //if an enemy is killed, this is what we do
        if (enemy.health <= 0)
        {
            //tell us he died, name him dead, and then destroy the game object
            Debug.Log(enemy.toonName + " has DIED!");
            GameObject dead = GameObject.Find(lizBattle.OccupiedHexs[click.clickCoor]);
            Destroy(dead);
            lizBattle.OccupiedHexs.Remove(click.clickCoor);
            //increment birds slain for scoring purposes
            birdsSlain += 1;
            Debug.Log("Lizard has slain " + birdsSlain + " birds");
        }
        //if the hero dies. This should end game more elegently than crashing, as we do now.
        if (self.health <= 0)
        {
            Debug.Log(self.toonName + " has DIED");
            GameObject dead = GameObject.Find("Lizard");
            Destroy(dead);

        }
    }
    //this is how we tell if a hex is occupied
    public void OccupiedHex()
    {        
        string clickTile;
        //open and access the map and click
        GameObject board = GameObject.Find("map");
        Map_v12 map = board.GetComponent<Map_v12>();
        ClickableTile_v5 click = board.GetComponent<ClickableTile_v5>();
        clickTile = click.clickCoor;
        //access the lizard battle so it runs on that, not the general battle script
        GameObject liz = GameObject.Find("Lizard");
        Lizard_v3 lizClass = liz.GetComponent<Lizard_v3>();
        Battle_v3 lizBattle = liz.GetComponent<Battle_v3>();
        //Debug.Log(clickTile);
        //this is how battle is called, and the condition is if the hex is in occupied hex list AND is in the lizards neighbor list
        if ( (lizBattle.OccupiedHexs.ContainsKey(clickTile)) && (lizClass.actualNeighbors.Contains(clickTile)) )
        {
            GameObject bird = GameObject.Find(lizBattle.OccupiedHexs[clickTile]);
            Bird_v3 birdClass = bird.GetComponent<Bird_v3>();
            lizBattle.enemy = birdClass.unit;
            lizBattle.Battle();
          
        }

        //Healing
        if ( (lizClass.healingTiles.Contains(clickTile)) && (lizClass.actualNeighbors.Contains(clickTile)) )
        {
            Debug.Log("Lizard walked into a healing fountain and replenished 10 Health");
            self.health += 10;
            lizClass.healingTiles.Remove(clickTile);

            //lizBattle.healing();
            Debug.Log(self.health);
        }
    }
   
    
    public void OccupiedHexList()
    { 
        //updates the lizards-battlescripts-occupied hex list, first by removing his old location and then by adding his new one.
        GameObject liz = GameObject.Find("Lizard");
        Lizard_v3 lizClass = liz.GetComponent<Lizard_v3>();
        Battle_v3 lizBattle = liz.GetComponent<Battle_v3>();
        lizBattle.OccupiedHexs.Remove(lizClass.tileStr);
        lizBattle.OccupiedHexs.Add(lizClass.tileStr, lizClass.name);
    }
    
    /*
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }
    */
}
