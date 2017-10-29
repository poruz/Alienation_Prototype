using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheEndButton : MonoBehaviour {

    public GameObject mText;
    public GameObject mScreenText;
    public GameObject stayHere;
    public GameObject boardShip;
    public GameObject stayHereText;
    public GameObject boardShipText;

    // Use this for initialization
    void Start () {
		
	}
	


	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        mText.GetComponent<TextMesh>().fontSize = 170;
    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        mText.GetComponent<TextMesh>().fontSize = 150;
    }

    void OnMouseDown()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LastLevel");
    }

}
