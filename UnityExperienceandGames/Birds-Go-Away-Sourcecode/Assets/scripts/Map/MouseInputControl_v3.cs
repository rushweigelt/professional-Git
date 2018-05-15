using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputControl_v3 : MonoBehaviour
{
    GameObject ourHitObject;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //a ray from the camera to the mouse, creates a ray called hit info which gathers info for later.
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            //hit info of which collider we hit by gameobject's parent (so we have the coordinates, not just the gameobject
            GameObject ourHitObject = hitInfo.collider.gameObject;
            Debug.Log("Mouse at: " + ourHitObject.name);

        }
    }
    public void SelectedUnit()

    {
        //remove later, hard coded but should be procedural
        GameObject lizard = GameObject.Find("Lizard");
        GameObject bird = GameObject.Find("Bird");
        GameObject board = GameObject.Find("map");
        if (ourHitObject == bird)
        {
            Map_v11 map = board.GetComponent<Map_v11>();
            map.SelectedUnit = bird;
        }
        if (ourHitObject == lizard)
        {
            Map_v11 map = board.GetComponent<Map_v11>();
            map.SelectedUnit = lizard;
        }
    }
    // Debug.Log("Mouse at: " + hitInfo.collider.transform.parent.name);
    //we could enlarge the tile, with a pop-window of it's element and, if occupied by a unit, info on the unit?

    //new, scary shit. Fucking with OLD code is scary


}
