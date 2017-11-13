using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienInteractAI : MonoBehaviour {

    bool mAlreadySpeaking;
    public GameObject player;
    public string[] mMessages;
    public GameObject mText;
    public GameObject mTextBox;
    public AudioSource mBlipAudio;
    public GameObject playerHP;
    public GameObject portal;
    Animator anim;
	// Use this for initialization
	void Start () {
        anim = player.GetComponent<Animator>();
        portal.SetActive(false);
        mTextBox.SetActive(false);
        mAlreadySpeaking = false;
        mText.GetComponent<TextMesh>().text = "";
        //print(mText.GetComponent<TextMesh>().text.ToString() + " said");
        //mText.transform.position = new Vector3(transform.position.x, transform.position.y + 1.5f
          //  + transform.position.z);
        mText.GetComponent<TextMesh>().color = Color.white;
    }
	
	// Update is called once per frame
	void Update () {
        bool playerIsNear;
        if (Vector3.Distance(transform.position, player.transform.position) < 3.5f)
            playerIsNear = true;
        else
            playerIsNear = false;

        if (playerIsNear && !mAlreadySpeaking && (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.Return)))
        {
            mTextBox.SetActive(true);
            StopAllCoroutines();
            StartCoroutine(Speak());
            mAlreadySpeaking = true;
        }/*
        else if (!playerIsNear && mAlreadySpeaking)
        {
            StopAllCoroutines();
            mAlreadySpeaking = false;
        }*/

    }

    IEnumerator Speak() {
        player.GetComponent<PlayerMovementAndAnimControlVillage>().enabled = false;
        anim.SetBool("jump", false);
        anim.SetBool("run", false);
        mText.GetComponent<TextMesh>().text = "";
        bool flag = true;
        for (int i = 0; i < mMessages.Length; i++)
        {
            flag = true;
            string str = "";
            //Text Mesh to current message
            for (int j = 0; j < mMessages[i].Length && flag; j++)
            {
                mText.GetComponent<TextMesh>().text += mMessages[i][j];
                if (mBlipAudio != null)
                {
                    ///Debug.Log("Playing");
                    if(mMessages[i] != " ")
                        mBlipAudio.Play();
                }
                yield return new WaitForSeconds(0.05f);
                if (this.name == "Antler")
                {
                    if (i == 4)
                    {
                        playerHP.SetActive(true);
                    }
                    else if (i == 6)
                    {
                        portal.SetActive(true);
                    }
                }

                if ((Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.E)) && (j!=0 || i!=0) ) {
                    flag = false;
                    str = mMessages[i];
                }

            }

            if (flag == false)
            {
                mText.GetComponent<TextMesh>().text = str;
            }
            yield return new WaitForSeconds(1.0f);
            mText.GetComponent<TextMesh>().text = "";
        }
        mTextBox.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        player.GetComponent<PlayerMovementAndAnimControlVillage>().enabled = true;
        mAlreadySpeaking = false;
    }
    
}
