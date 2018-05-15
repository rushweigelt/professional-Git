using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class baseUnit : ScriptableObject {

    public string toonName;
    public string description;
    public string elementType;
    public int attack;
    public int health;
    public int movement;
    public int pageCost;
    public int tileX;



    public void Print()
    {
        
        string outText = toonName + " : " + description + " the card costs " + pageCost;
        Debug.Log(outText);
        GameObject textEd = GameObject.Find("textControl");
        textEd.BroadcastMessage("textUpdate", outText);

    }
    
}
