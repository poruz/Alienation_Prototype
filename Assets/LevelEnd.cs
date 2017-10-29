using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour {

    public string[] mMessages;
    public GameObject mText;
    public AudioSource mAudio;
    public GameObject stayHere;
    public GameObject boardShip;
    public GameObject stayHereText;
    public GameObject boardShipText;
    // Use this for initialization
    void Start () {
        stayHere.SetActive(false);
        boardShip.SetActive(false);
        stayHereText.SetActive(false);
        boardShipText.SetActive(false);
        StartCoroutine(TextCoroutine());
    }

    IEnumerator TextCoroutine()
    {
        mText.GetComponent<TextMesh>().text = "";
        yield return new WaitForSeconds(1.0f);
        for (int i = 0; i < mMessages.Length;)
        {
            //Text Mesh to current message
            for (int j = 0; j < mMessages[i].Length; j++)
            {
                mText.GetComponent<TextMesh>().text += mMessages[i][j];
                if (mAudio != null)
                {
                    ///Debug.Log("Playing");
                    if (mMessages[i] != " ")
                        mAudio.Play();
                }
                yield return new WaitForSeconds(0.05f);

            }
            i++;
            mText.GetComponent<TextMesh>().text += '\n';
            //Text Mesh to current message
            for (int j = 0; j < mMessages[i].Length; j++)
            {
                mText.GetComponent<TextMesh>().text += mMessages[i][j];
                if (mAudio != null)
                {
                    ///Debug.Log("Playing");
                    if (mMessages[i] != " ")
                        mAudio.Play();
                }
                yield return new WaitForSeconds(0.05f);

            }
            yield return new WaitForSeconds(1.0f);
            if (i != mMessages.Length - 1)
                mText.GetComponent<TextMesh>().text = "";
            else
            {
                stayHere.SetActive(true);
                boardShip.SetActive(true);
                stayHereText.SetActive(true);
                boardShipText.SetActive(true);
            }
            i++;
        }

    }

    // Update is called once per frame
    void Update () {
		
	}
}
