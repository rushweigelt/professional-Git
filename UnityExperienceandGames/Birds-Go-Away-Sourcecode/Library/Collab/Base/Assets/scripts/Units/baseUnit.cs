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
        Debug.Log(toonName + " : " + description + " the card costs " + pageCost);

    }
    
}
