using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformUp : MonoBehaviour {

    public bool playerOnTop; //only true if the player is on top of the platform
    public float maxY;
    public float speed;
    float minY;

	// Use this for initialization
	void Start () {
        playerOnTop = false;
        minY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        if (playerOnTop == true)
        {
            if (transform.position.y < maxY) {
                transform.position = new Vector3 (transform.position.x,
                    transform.position.y + speed*Time.deltaTime, transform.position.z);
            }
        }
        else
        {
            if (transform.position.y > minY) {
                transform.position = new Vector3(transform.position.x,
                    transform.position.y - speed * Time.deltaTime, transform.position.z);
            }
        }
	}

    private void OnCollisionStay(Collision info) {
        if(info.gameObject.tag == "Player")
        {
            playerOnTop = true;
        }
    }
    
    private void OnCollisionExit(Collision info)
    {
        if (info.gameObject.tag == "Player")
        {
            playerOnTop = false;
        }
    }
    
}
