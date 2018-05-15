using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputControl_v2 : MonoBehaviour
{
    //public GameObject hexPrefab;
    private bool boo = true;
    //public Color tileHighlightColor;
    //public Color normalColor;
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hitInfo;

    // Use this for initialization
    void Start()
    {
        //MeshRenderer mr = GetComponentInChildren<MeshRenderer>();
        //normalColor = mr.material.color;
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log("Mouse Position: " + Input.mousePosition);

        //fixed camera only--not ideal
        //Vector3 WorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log("World Position: " + WorldPoint);

        //a ray from the camera to the mouse, creates a ray called hit info which gathers info for later.
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        GameObject ourHitObject = hitInfo.collider.gameObject;
        Collider collider = ourHitObject.GetComponentInChildren<Collider>();
        MeshRenderer mr = ourHitObject.GetComponentInChildren<MeshRenderer>();

        if (collider.Raycast(ray, out hitInfo, Mathf.Infinity))
        {
            mr.material.color = Color.cyan;
        }
        else
        {
            mr.material.color = Color.red;
        }
           



        }





      /*
        RaycastHit hitInfo;
        //boolean function that determines whether mouse hits a collider.
        if (Physics.Raycast(ray, out hitInfo))
        {
            //hit info of which collider we hit by gameobject's parent (so we have the coordinates, not just the gameobject
            GameObject ourHitObject = hitInfo.collider.gameObject;
            //Debug.Log("Mouse at: " + ourHitObject.name);
            Debug.Log("Mouse at: " + hitInfo.collider.transform.parent.name);
            //we could enlarge the tile, with a pop-window of it's element and, if occupied by a unit, info on the unit?

            //collider and mesh info to highlight tile that the mouse is hovering over

        }
        Collider collider = ourHitObject.GetComponentInChildren<Collider>();
        MeshRenderer mr = ourHitObject.GetComponentInChildren<MeshRenderer>();
            if (collider.Raycast(ray, out hitInfo, Mathf.Infinity))
                {
                    boo = false;
                    while (boo == false)
                    {
                        mr.material.color = Color.cyan;
                    }
                }
                else
                {

                    //GameObject ourHitObject = hitInfo.collider.gameObject;
                    //MeshRenderer mr2 = ourHitObject.GetComponentInChildren<MeshRenderer>();
                    mr.material.color = Color.red;
                    boo = true;
                }
                */

        }

