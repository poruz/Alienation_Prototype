using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour {

    public GameObject player;
    int dir;
    public float speed;
	// Use this for initialization
	void Start () {
        if (player.GetComponent<PlayerMovementAndAnimControl>().isMovingRight == true)
        {
            dir = 1;
        }
        else
        {
            dir = -1;
        }
        Destroy(gameObject, 5);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime * dir,
            transform.position.y, transform.position.z);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
		if(collision.gameObject.tag != "Player")
			Destroy(gameObject);
    }
}
