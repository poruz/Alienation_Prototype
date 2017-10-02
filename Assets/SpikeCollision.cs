using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeCollision : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        print("Entered\n");
        if (collision.gameObject.tag == "Player")
        {
            print("Player");
            player.GetComponent<GameOver>().enabled = true;
        }
    }
}
