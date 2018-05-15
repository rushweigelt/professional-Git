using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSelectionHex : MonoBehaviour {
    public GameObject mouse_prefab;
    public Transform mh;
    //public Transform mHex;
	// Use this for initialization
	void Start ()
    {
        //trying to instantiate the mouse hex tile so it does not start in an empty unity scene
        /*
        GameObject MouseHex = (GameObject)Instantiate(mouse_prefab, new Vector3(0, 0, 0), Quaternion.identity);
        MouseHex.transform.SetParent(this.transform);
        GameObject Mouse_Hex = MouseHex;
        Transform mh = MouseHex.transform;
        */




    }

    // Update is called once per frame
    void Update () {
        //ray to move mouse hex overlay
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            GameObject ourHitObject = hitInfo.collider.gameObject;
            mh.transform.position = ourHitObject.transform.position;
            
        }

    }
}
