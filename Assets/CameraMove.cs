using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public GameObject player;

    //public bool followPlayer;

	// Use this for initialization
	void Start () {
      //  followPlayer = true;
	}

    // Update is called once per frame
    void Update()
    {
      
            transform.position = new Vector3(player.transform.position.x, 4.99f, transform.position.z);
        
    }

    

}
