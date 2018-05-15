using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_v2 : MonoBehaviour {

    public GameObject OpenPanel = null;

    private bool _isInsideTrigger = false;

    public Animator _animator;

    public bool isLocked = false;


    void OnTriggerEnter(Collider other)
    {
        GameObject guide = GameObject.FindGameObjectWithTag("guide");
        HoldObj_v1 hold = guide.GetComponent<HoldObj_v1>();

        if ( (other.tag == "Player") && (isLocked == false) )
        {
            _isInsideTrigger = true;
            OpenPanel.SetActive(true);
            //Debug.Log(isLocked);
        }
        if ( ((other.tag == "Player") && (isLocked == true)) && (hold.holdingKey == false) )
        {
            Debug.Log("The Door is Locked, You Need a Key");
        }
        if ( ((other.tag == "Player") && (isLocked == true)) && (hold.holdingKey == true))
        {
            _isInsideTrigger = true;
            OpenPanel.SetActive(true);
            Debug.Log("You have the key, and the door unlocks!");
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _isInsideTrigger = false;
            _animator.SetBool("open", false);
            OpenPanel.SetActive(false);
        }
    }

    private bool IsOpenPanelActive
    {
        get
        {
            return OpenPanel.activeInHierarchy;
        }
    }


    // Update is called once per frame
    void Update () {
        GameObject guide = GameObject.FindGameObjectWithTag("guide");
        HoldObj_v1 hold = guide.GetComponent<HoldObj_v1>();
        if (IsOpenPanelActive && _isInsideTrigger && (isLocked == false) )
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                OpenPanel.SetActive(false);
                _animator.SetBool("open", true);
            }
        }
        else if (IsOpenPanelActive && _isInsideTrigger && (isLocked == true ) && (hold.holdingKey == true) )
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                OpenPanel.SetActive(false);
                _animator.SetBool("open", true);
            }
        }
    }
}
