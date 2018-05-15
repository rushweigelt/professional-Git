using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MirrorCover_v1 : MonoBehaviour {

    public Rigidbody rig;

	// Use this for initialization
	void Start ()
    {
        rig.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //knockDown();
	}

    private void OnTriggerEnter(Collider other)
    {
        //if the key hits the sheet, knock sheet down
        if (other.gameObject.tag == "key")
        {
            rig.isKinematic = false;
        }
        //else, if its the player, let them hit q to knock it down
        else if (other.gameObject.tag == "guide")
        {

            if (Input.GetKeyDown(KeyCode.Q)) 
            {
                rig.isKinematic = false;
            }
        }
    }

    /*
    private void knockDown()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            rig.isKinematic = false;
        }
    }
    */
}
