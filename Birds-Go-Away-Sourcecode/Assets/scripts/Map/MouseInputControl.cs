using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputControl : MonoBehaviour
{ 
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

            //commented out mouse location to clean up debug log
            //Debug.Log("Mouse at: " + ourHitObject.name);

        }
    }
           // Debug.Log("Mouse at: " + hitInfo.collider.transform.parent.name);
            //we could enlarge the tile, with a pop-window of it's element and, if occupied by a unit, info on the unit?

           //new, scary shit. Fucking with OLD code is scary
           

}
