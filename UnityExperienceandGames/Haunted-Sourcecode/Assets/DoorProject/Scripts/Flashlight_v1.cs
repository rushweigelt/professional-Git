using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight_v1 : MonoBehaviour {

    public Light flashlight;

	// Use this for initialization
	void Start () {
    
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetButtonDown("f"))
        {
            flashlight.enabled = !flashlight.enabled;
        }
		
	}
}
