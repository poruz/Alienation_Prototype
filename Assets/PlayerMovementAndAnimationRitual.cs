using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovementAndAnimationRitual : MonoBehaviour
{
    
    public int HP;
    public AudioSource hurtAudio;
    public GameObject playerHP;

    // Use this for initialization
    void Start()
    {
        HP = 100;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // HitDirection hitDirection = HitDirection.None;
        if (collision.gameObject.tag == "Bullet")
        {
            HP -= 10;
            if (hurtAudio != null)
            {
                hurtAudio.Play();
            }
            this.GetComponent<Rigidbody2D>().AddForce(-transform.right*5, ForceMode2D.Impulse);
        }
    }

}