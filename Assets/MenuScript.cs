using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public GameObject mText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        mText.GetComponent<TextMesh>().fontSize = 130;
    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        mText.GetComponent<TextMesh>().fontSize = 100;
    }

    void OnMouseDown()
    {
        if (this.gameObject.name == "StartGameButton")
        {
            this.gameObject.GetComponent<Renderer>().enabled = false;
            mText.gameObject.GetComponent<Renderer>().enabled = false;
            UnityEngine.SceneManagement.SceneManager.LoadScene("RitualLevel");
        }
    }
}
