using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_v1 : MonoBehaviour
{
    //add player object to enemy
    public Transform player;
    //time it takes to close gap
    public float time = 10.0f;
    //velocity of the enemy
    private Vector3 velocity = Vector3.zero;


	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        //look at player
        transform.LookAt(player);
        //distance between enemy and player
        float distance = Vector3.Distance(transform.position, player.position);

        transform.position = Vector3.SmoothDamp(transform.position, player.position, ref velocity, time);
    }

    //will determine if the enemy touches the player, thus ending the game
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "guide")
        {
            Debug.Log("The player has been captured by the monster. GAME OVER!");
        }
    }

}
