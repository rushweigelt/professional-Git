using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//shit, chandelier sucks to spell
public class Chandelier_v1 : MonoBehaviour
{
    public Rigidbody rig;
	// Use this for initialization; make rigidbody kinematic at start so it stays in air
	void Start ()
    {
        rig = GetComponent<Rigidbody>();
        rig.isKinematic = true;
	}
	// Update is called once per frame
	void Update ()
    {
		
	}
    //if hit with key, turn kinematic off so it falls
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "key")
        {
            rig.isKinematic = false;
        }
    }
}
