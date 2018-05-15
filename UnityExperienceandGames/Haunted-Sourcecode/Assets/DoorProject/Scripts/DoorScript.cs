using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    //animate door swinging
    public Animator _animator;
    //our text prompt that tells the player what button opens doors
    public GameObject openPrompt;

    //should change this to private later, its public right now for testing
    //public bool hasKey;

    //accesses the FirstPersonController script
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController myPlayer;

    //GameObject player = GameObject.FindGameObjectWithTag("Player");
    //PlayerScript ps = player.getcomponent<PlayerScript>();




    // Use this for initialization
    void Start ()
    {
        //_animator = GetComponent<Animator>();

        //at start, hide button prompt
        openPrompt.SetActive(false);

		
	}

    //how we open the door by getting close to it
    //this function automatically opens door when player approaches
    
    private void OnTriggerEnter(Collider other)
    {
         //GameObject canvas = GameObject.Find("DoorOpenPrompt");
        if (other.tag == "Player")
        {
            //_animator.SetBool("open", true);
            openPrompt.SetActive(true);
        }
    }
    
    //how we let door close and prompt disappear when we move away from door.
    private void OnTriggerExit(Collider other)
    {
       if (other.tag == "Player")
        {
            _animator.SetBool("open", false);
            openPrompt.SetActive(false);
        }
    }

    //used to tell if prompt is up--or, if we're in range of a door.
    private bool IsopenPromptActive
    {
        get
        {
            return openPrompt.activeInHierarchy;
        }

    }

    
    //used to tell if player has key 
    private bool PlayerHasKey()
    {
        if (myPlayer.hasKey == true)
            return true;
        else
            return false;
    }

    // Update is called once per frame
    void Update ()
    {
		if (IsopenPromptActive)
        {
            if (PlayerHasKey())
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    _animator.SetBool("open", true);
                    openPrompt.SetActive(false);
                }
            }
        }
	}
}
