using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public GameObject mText;

    public GameObject startGameButton;
    public GameObject startGameText;

    public GameObject quitButton;
    public GameObject quitText;

    public GameObject controlsButton;
    public GameObject controlsText;

    public GameObject controlsImage;

    public GameObject returnToMainMenuButton;
    public GameObject returnToMainMenuText;

    // Use this for initialization
    void Start () {
        if (this.name == "ReturnToMainMenuButton")
        {
            returnToMainMenuText.SetActive(false);
            returnToMainMenuButton.SetActive(false);
            controlsImage.GetComponent<SpriteRenderer>().enabled = false;
        }
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
        else if (this.gameObject.name == "QuitButton")
        {
            this.gameObject.GetComponent<Renderer>().enabled = false;
            mText.gameObject.GetComponent<Renderer>().enabled = false;
            Application.Quit();
        }
        else if (this.gameObject.name == "ControlsButton")
        {
            startGameText.SetActive(false);
            startGameButton.SetActive(false);
            //GameObject.Find("QuitText").SetActive(false);
            quitButton.SetActive(false);
   
            returnToMainMenuButton.SetActive(true);
            returnToMainMenuText.SetActive(true);
            controlsImage.GetComponent<SpriteRenderer>().enabled = true;

            mText.gameObject.SetActive(false);
            this.gameObject.SetActive(false);

        }
        else if (this.gameObject.name == "ReturnToMainMenuButton")
        {
            startGameButton.SetActive(true);
            quitButton.SetActive(true);
            startGameText.SetActive(true);
            quitText.SetActive(true);
            controlsButton.SetActive(true);
            controlsText.SetActive(true);

            mText.gameObject.SetActive(false);
            controlsImage.GetComponent<SpriteRenderer>().enabled = false;
            this.gameObject.SetActive(false);
        }
    }
}
