﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot : MonoBehaviour {

    public GameObject bullet;

    bool readyToShoot;

	// Use this for initialization
	void Start () {
        readyToShoot = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Return) && readyToShoot)
        {
            StartCoroutine(bulletCoroutine());
        }
	}

    IEnumerator bulletCoroutine() {
        bool facingRight = GetComponent<PlayerMovementAndAnimControl>().isMovingRight;

        Vector3 bulletVector;

        if (facingRight)
        {
            bulletVector = new Vector3(transform.position.x + 1f,
                transform.position.y, transform.position.z);
        }
        else
        {
            bulletVector = new Vector3(transform.position.x - 1f,
                transform.position.y, transform.position.z);
        }

        bullet.GetComponent<BulletMove>().player = this.gameObject;
        Instantiate(bullet, bulletVector, transform.rotation);

        readyToShoot = false;
        yield return new WaitForSeconds(0.3f);
        readyToShoot = true;
    }

}