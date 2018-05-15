using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldObj_v1 : MonoBehaviour
{

    public float speed = 20;
    public bool canHold = true;
    public GameObject key;
    public Transform guide;
    public bool holdingKey = false;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //if canhold is false (because youre already holding it), throw object
            if (!canHold)
            {
                ThrowOb();
                holdingKey = false;
            }
            //if youre not holding it, pick it up and toggle holdingKey true
            else
            {
                Pickup();
                //holdingKey = true;    //moved to inside Pickup()
            }
            
            //to stabilize cube i am guessing
            if (!canHold && key)
            {
                key.transform.position = guide.position;
            }
            

        }
        
        /*
        //update key position, causes key to clip through objects
        if (holdingKey == true)
        {
            //rotate with camera
            key.transform.localRotation = guide.rotation;
            //move key with cam
            key.transform.position = guide.position;
        }
        */
    }

    //trigger on collision
    void OnTriggerEnter(Collider coll)
    {
        //;ets us know palyer is touching key
        if (coll.gameObject.tag == "key")
        {
            key = coll.gameObject;
        }
        else
        {

        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "key")
        {
            if (canHold)
            {
                key = null;
            }
        }
    }

    private void Pickup()
    {
        if (!key)
            return;

        //sets key to guide
        key.transform.SetParent(guide);

        //falsifly gravity so key doesnt freak out when turning and running into objs
        key.GetComponent<Rigidbody>().useGravity = false;
        

        //rotate with camera
        key.transform.localRotation = guide.rotation;
        //move key with cam
        key.transform.position = guide.position;
        //toggle so we know we're holding the obj
        canHold = false;
        key.GetComponent<Rigidbody>().isKinematic = true;
        holdingKey = true;

    }


    private void ThrowOb()
    {
        if (!key)
            return;

        key.GetComponent<Rigidbody>().useGravity = true;
        key.GetComponent<Rigidbody>().isKinematic = false;

        key = null;

        //apply velocity
        guide.GetChild(0).gameObject.GetComponent<Rigidbody>().velocity = transform.forward * speed;

        guide.GetChild(0).parent = null;
        canHold = true;
    }
        
}
