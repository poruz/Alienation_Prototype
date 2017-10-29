using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovementAndAnimControlVillage : MonoBehaviour
{

    Animator anim;
    bool jump;
    public bool isMovingRight;
    bool prevDir;
    public float speed;
    bool isGrounded;
    bool run;
    SpriteRenderer renderer;
    public int HP;
    //bool mInAir;
    public GameObject camera;
    public GameObject gameOverText;
    //New variables
    public bool mInAir;
    bool mSpacePressed;
    public float YMaxSpeed;
    public float XMaxSpeed;
    float mXSpeed;
    float mYSpeed;
    //public AudioSource hurtAudio;

    public GameObject playerHP;

    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody2D>().freezeRotation = true;
        gameOverText.GetComponent<Text>().enabled = false;

        playerHP.SetActive(false);

        anim = GetComponent<Animator>();
        run = false;

        isMovingRight = true;
        prevDir = true; //Say was facing right before as well
        
        renderer = GetComponent<SpriteRenderer>();

        mInAir = false;

        anim.SetBool("jump", mInAir);
        anim.SetBool("run", run);
    }

    // Update is called once per frame
    void Update()
    {
        camera.transform.position = new Vector3(transform.position.x, transform.position.y + 5.0f, camera.transform.position.z);
        //COMMENT OUT THE ABOVE CODE LATER********************


        if (HP <= 0)
        {
            // player Died
            GameObject startGameButton = GameObject.Find("StartGameButton");
            startGameButton.GetComponent<MetricManager>().AddToDeathMetric(1, 1);
            startGameButton.GetComponent<MetricManager>().AddToLevelMetric((int)Time.timeSinceLevelLoad,
                startGameButton.GetComponent<MetricManager>().levelNameToIndex[SceneManager.GetActiveScene().name]);
            GetComponent<GameOver>().enabled = true;
        }

        if ( transform.position.y < -10.0f)
        {
            //Fallen off killed
            GameObject startGameButton = GameObject.Find("StartGameButton");
            startGameButton.GetComponent<MetricManager>().AddToDeathMetric(1, 0);
            startGameButton.GetComponent<MetricManager>().AddToLevelMetric((int)Time.timeSinceLevelLoad,
                startGameButton.GetComponent<MetricManager>().levelNameToIndex[SceneManager.GetActiveScene().name]);
            GetComponent<GameOver>().enabled = true;
        }

        //Process input
        mXSpeed = 0;
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) //go right
        {
            mXSpeed = XMaxSpeed;
            prevDir = isMovingRight;
            isMovingRight = true;
            if (prevDir != isMovingRight)
            {
                renderer.flipX = !renderer.flipX;
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) //go left
        {
            mXSpeed = -XMaxSpeed;
            prevDir = isMovingRight;
            isMovingRight = false;
            if (prevDir != isMovingRight)
            {
                renderer.flipX = !renderer.flipX;
            }
        }

        if (mSpacePressed == false && (Input.GetKey(KeyCode.Space) 
                || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) )
        {
            if (mInAir == false)
                mYSpeed = YMaxSpeed;
            mInAir = true;
        }

        mSpacePressed = Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);

        //Update
        transform.position = new Vector3(transform.position.x + mXSpeed*Time.deltaTime,
        transform.position.y + mYSpeed*Time.deltaTime, transform.position.z);
        if (mInAir) //inair
        {
            mYSpeed -= 15f * Time.deltaTime;
        }
        else //OnGround
        {
            if (mXSpeed != 0) //running
            {
                //StartCoroutine(FootAudio());
                run = true;
            }
            else //idle
            {
                run = false;
            }
        }

        anim.SetBool("jump", mInAir);
        anim.SetBool("run", run);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // HitDirection hitDirection = HitDirection.None;
        
            if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Platform") {

            float onTop = Vector3.Dot(transform.position - collision.transform.position, transform.up);
            if (onTop < 0)
            {
                //print("Bottom");
                if (mYSpeed < 0)
                    mYSpeed = 0;
            }
            else
            {
                //print("Top");
                mInAir = false;
                mYSpeed = 0;
            }

            
        }
    }

}