using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public GameObject player;
    public float boundary;
    public Vector3 newViewVector;
    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(player.transform.position.x > boundary && Vector3.Distance(transform.position, newViewVector) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, newViewVector, speed * Time.deltaTime);
        }
	}
}
