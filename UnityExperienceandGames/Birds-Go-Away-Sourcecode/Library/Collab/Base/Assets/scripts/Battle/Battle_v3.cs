using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle_v3 : MonoBehaviour
{

    public baseUnit self;
    public baseUnit enemy;
    public Dictionary<string, string> OccupiedHexs = new Dictionary<string, string>();



    public void Battle()
    {
        Debug.Log("A Battle has Begun!");
        enemy.health = enemy.health - self.attack;
        Debug.Log(enemy.name + " has " + enemy.health + " health remaining!");
        self.health = self.health - enemy.attack;
        Debug.Log(self.name + " has " + self.health + " health remaining!");
        if (enemy.health <= 0)
        {
            Debug.Log(enemy.toonName + " has DIED!");
            GameObject dead = GameObject.Find("Bird");
            Destroy(dead);
        }
        if (self.health <= 0)
        {
            Debug.Log(self.toonName + " has DIED");

        }
    }

    public void OccupiedHex()
    {
        GameObject liz = GameObject.Find("Lizard");
        Lizard_v3 lizClass = liz.GetComponent<Lizard_v3>();
        GameObject bird = GameObject.Find("Bird");
        Bird_v3 birdClass = bird.GetComponent<Bird_v3>();
        if (lizClass.tileStr == birdClass.tileStr)
        {
            Battle();
        }
        else
        {

        }
    }

    public void OccupiedHexList()
    {
        GameObject liz = GameObject.Find("Lizard");
        Lizard_v3 lizClass = liz.GetComponent<Lizard_v3>();
        GameObject bird = GameObject.Find("Bird");
        Bird_v3 birdClass = bird.GetComponent<Bird_v3>();

        //
        //OccupiedHexs.Add("Placeholder", "Placeholder");

        OccupiedHexs.Clear();
        OccupiedHexs.Add(lizClass.tileStr, lizClass.name);
        OccupiedHexs.Add(birdClass.tileStr, birdClass.name);

        //Debug.Log(map.OccupiedHexs);
    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
