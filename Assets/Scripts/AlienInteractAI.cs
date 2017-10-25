using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienInteractAI : MonoBehaviour {

    bool mAlreadySpeaking;
    public GameObject player;
    public string[] mMessages;
    public GameObject mText;

	// Use this for initialization
	void Start () {
        mAlreadySpeaking = false;
        mText.GetComponent<TextMesh>().text = "";
        //print(mText.GetComponent<TextMesh>().text.ToString() + " said");
        mText.transform.position = new Vector3(transform.position.x, transform.position.y + 1.5f
            + transform.position.z);
        mText.GetComponent<TextMesh>().color = Color.red;
    }
	
	// Update is called once per frame
	void Update () {
        bool playerIsNear;
        if (Vector3.Distance(transform.position, player.transform.position) < 3.5f)
            playerIsNear = true;
        else
            playerIsNear = false;

        if (playerIsNear && !mAlreadySpeaking)
        {
            StopAllCoroutines();
            StartCoroutine(Speak());
            mAlreadySpeaking = true;
        }
        else if (!playerIsNear && mAlreadySpeaking)
        {
            StopAllCoroutines();
            StartCoroutine(SayBye());
            mAlreadySpeaking = false;
        }

    }

    IEnumerator Speak() {
        mText.GetComponent<TextMesh>().text = "";
        for (int i = 0; i < mMessages.Length; i++)
        {
            //Text Mesh to current message
            for (int j = 0; j < mMessages[i].Length; j++)
            {
                mText.GetComponent<TextMesh>().text += mMessages[i][j];
                yield return new WaitForSeconds(0.05f);
            }
            yield return new WaitForSeconds(1.0f);
            mText.GetComponent<TextMesh>().text = "";
        }
    }

    IEnumerator SayBye()
    {
        mText.GetComponent<TextMesh>().text = "Bye!";
        yield return new WaitForSeconds(1.0f);
        mText.GetComponent<TextMesh>().text = "";
    }
}
