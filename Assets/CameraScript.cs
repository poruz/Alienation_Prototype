using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public GameObject player;
    public float[] xCamPositions;
    public float[] playerBoundaries;
    public Vector3 newViewVector;
    public float speed;
    int currIndex;

    // Use this for initialization
	void Start () {
        currIndex = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if (player.transform.position.x > playerBoundaries[currIndex])
        {
            newViewVector = new Vector3(xCamPositions[currIndex+1], 
                transform.position.y, transform.position.z);
            if (Vector3.Distance(transform.position, newViewVector) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, newViewVector, speed * Time.deltaTime);
            }
            else
            {
                currIndex++;
            }
        }
        
        /*
        if (player.transform.position.x > boundary && Vector3.Distance(transform.position, newViewVector) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, newViewVector, speed * Time.deltaTime);
        }*/
	}
}
