using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalPlatform : MonoBehaviour {

    public float maxX;
    public float minX;
    public GameObject player;
    bool moveRight;
    public float speed;
    bool playerOnTop;

    // Use this for initialization
    void Start () {
        moveRight = true;
        playerOnTop = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (moveRight)
        {
            if (transform.position.x < maxX)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime,
                    transform.position.y, transform.posiion.z);
            }
            else
            {
                moveRight = false;
            }
        }
        else {
            if (transform.position.x > maxX)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime,
                    transform.position.y, transform.posiion.z);
            }
            else
            {
                moveRight = true;
            }
        }
	}

    private void OnCollisionStay(Collision info) {
        if (info.gameObject.tag == "Player")
        {
            playerOnTop = true;
        }
    }

    private void OnCollisionExit(Collision info) {
        if (info.gameObject.tag == "Player")
        {
            playerOnTop = false;
        }
    }
}
