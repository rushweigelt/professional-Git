using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript_v2 : MonoBehaviour
{
    //drop panel into script
    public GameObject OpenPanel;
    private bool isInsideTrigger = false;
    public Animator animator;
    //if the player runs into the door, show panel which allows door to be opened.
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isInsideTrigger = true;
            OpenPanel.SetActive(true);
        }
    }
    //if you exit door, take prompt away.
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isInsideTrigger = false;
            OpenPanel.SetActive(false);
            animator.SetBool("open", false);
        }
    }
    //is the open panel up?
    private bool IsOpenPanelActive
    {
        get
        {
            return OpenPanel.activeInHierarchy;
        }
    }
    // Update is called once per frame
    void Update()
    {
        //if panel is open and we are inside the trigger box, let e open the door.
        if (IsOpenPanelActive && isInsideTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                OpenPanel.SetActive(false);
                animator.SetBool("open", true);
            }
        }
    }
}
