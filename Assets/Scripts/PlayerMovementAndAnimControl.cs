using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementAndAnimControl : MonoBehaviour {

    Animator anim;
    bool jump;
    public bool isMovingRight;
    bool prevDir;
    public float speed;
    bool isGrounded;
    bool run;
    SpriteRenderer renderer;
    public int HP;
    
    //CharacterController controller;
        

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        run = false;
        jump = false;

        isMovingRight = true;
        prevDir = true; //Say was facing right before as well

       
        isGrounded = true;
        renderer = GetComponent<SpriteRenderer>();

        anim.SetBool("jump", jump);
        anim.SetBool("run", run);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) //Move right
        {
            run = true;
            prevDir = isMovingRight;
            isMovingRight = true;
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime,
                    transform.position.y, transform.position.z);
            if (prevDir != isMovingRight) {
                renderer.flipX = !renderer.flipX;
            }

        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            run = true;
            prevDir = isMovingRight;
            isMovingRight = false;
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime,
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
            GetComponent<Rigidbody>().AddForce(new Vector3(0,7,0), ForceMode.Impulse);
            jump = true;
            run = false;
            isGrounded = false; //because je just jump. He'll be grounded again when he lands back!
        }

        if (!isGrounded) //in air = jump animation
        {
            jump = true;
        }
        else
        {
            jump = false;
        }

        anim.SetBool("jump", jump);
        anim.SetBool("run", run);

        run = false; //only run if key is hit again
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            jump = false;
        }
        else if (collision.gameObject.tag == "Fire")
        {
            HP--;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jump = true;
        }
    }
}
