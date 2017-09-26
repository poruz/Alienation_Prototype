using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementAndAnimControl : MonoBehaviour {

    Animator anim;
    bool jump;
    bool isMovingRight;
    bool prevDir;
    public float speed;
    float forwardSpeed;
    public bool isGrounded;
    public bool run;
    SpriteRenderer renderer;
    //CharacterController controller;
        

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        anim.SetBool("jump", jump);
        anim.SetBool("run", run);
        run = false;
        jump = false;
        isMovingRight = true;
        prevDir = true; //Say was facing right before as well
        forwardSpeed = 0;
        isGrounded = true;
        renderer = GetComponent<SpriteRenderer>();
        //controller = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) //Move right
        {
            run = true;
            forwardSpeed = speed;
            prevDir = isMovingRight;
            isMovingRight = true;
            anim.SetBool("jump", jump);
            anim.SetBool("run", run);
            transform.position = new Vector3(transform.position.x + forwardSpeed * Time.deltaTime,
                    transform.position.y, transform.position.z);
            if (prevDir != isMovingRight) {
                renderer.flipX = !renderer.flipX;
            }

        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            run = true;
            forwardSpeed = speed;
            prevDir = isMovingRight;
            isMovingRight = false;
            anim.SetBool("jump", jump);
            anim.SetBool("run", run);
            transform.position = new Vector3(transform.position.x - forwardSpeed * Time.deltaTime,
                    transform.position.y, transform.position.z);
            if (prevDir != isMovingRight)
            {
                renderer.flipX = !renderer.flipX;
            }
        }
        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
              && isGrounded)
        {
            /*
            Figure out if the player is grounded.
            If he is then give him a vertical velocity*/
            GetComponent<Rigidbody>().AddForce(new Vector3(0,400,0));
            jump = true;
            run = false;
            isGrounded = false;
        }

        anim.SetBool("jump", jump);
        anim.SetBool("run", run);

        run = false;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
