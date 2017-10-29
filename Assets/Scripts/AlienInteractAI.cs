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
        }
        else if (!playerIsNear && mAlreadySpeaking)
        {
            StopAllCoroutines();
            //StartCoroutine(SayBye());
            mAlreadySpeaking = false;
        }

    }

    IEnumerator Speak() {
        player.GetComponent<PlayerMovementAndAnimControlVillage>().enabled = false;
        anim.SetBool("jump", false);
        anim.SetBool("run", false);
        mText.GetComponent<TextMesh>().text = "";
        for (int i = 0; i < mMessages.Length; i++)
        {
            //Text Mesh to current message
            for (int j = 0; j < mMessages[i].Length; j++)
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
            }
            yield return new WaitForSeconds(1.0f);
            mText.GetComponent<TextMesh>().text = "";
        }
        mTextBox.SetActive(false);
        player.GetComponent<PlayerMovementAndAnimControlVillage>().enabled = true;
    }

    /*
    IEnumerator SayBye()
    {
        //mText.GetComponent<TextMesh>().text = "Bye!";
        yield return new WaitForSeconds(1.0f);
        mText.GetComponent<TextMesh>().text = "";
        mTextBox.SetActive(false);
    } */
}
