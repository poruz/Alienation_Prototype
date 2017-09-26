using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRotateAndAttack : MonoBehaviour {

    public GameObject gem;
    float targetAngle;
    
    // Use this for initialization
    /*
     * We want to rotate the fire according to it's position relative to the gem.
     * gemToFire = gem_position_vector - fire_position_vector
     * Then we calculate the angle of rotation with respect to positive y axis.
     */
	void Start () {
        Vector3 gemToFire = (this.transform.position - gem.transform.position).normalized;
        targetAngle = 180f * (float)(Math.Atan2(gemToFire.y,gemToFire.x)/Math.PI); //[-270, 90]
        
        transform.Rotate(0f, 0f, targetAngle - 90);
        this.GetComponent<Rigidbody>().AddForce(gemToFire * 400f);//, ForceMode.Impulse);
        Destroy(gameObject, 5.0f);
    }

    // Update is called once per frame
    void Update () {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if(!collision.gameObject.CompareTag("Fire")) //Destroy if collided with anything but fire
            Destroy(gameObject);
    }
}
