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

    public AudioSource buttonClickedAudio;

    public GameObject backButton;
    public GameObject backText;

    public AudioSource buttonSelectAudio;

    public GameObject alienationText;
    bool mouseOverStart; //leading edge

    
    // Use this for initialization
    void Start () {
        if (this.name == "backButton")
        {
            backText.SetActive(false);
            backButton.SetActive(false);
            controlsImage.GetComponent<SpriteRenderer>().enabled = false;
        }
        mouseOverStart = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        //Debug.Log("Over it");
        //mText.GetComponent<TextMesh>().fontSize = 130;
        if (mouseOverStart == true) {
            mText.transform.localScale += new Vector3(0.1f, 0.15f, 0);
            buttonSelectAudio.Play();
            mouseOverStart = false;
        }
    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        //mText.GetComponent<TextMesh>().fontSize = 100;
        if (mouseOverStart == false)
        {
            mText.transform.localScale += new Vector3(-0.1f, -0.15f, 0);
            mouseOverStart = true;
        }
    }

    void OnMouseDown()
    {
        buttonClickedAudio.Play();
        if (this.gameObject.name == "StartGameButton")
        {
            this.gameObject.GetComponent<Renderer>().enabled = false;
            mText.gameObject.GetComponent<Renderer>().enabled = false;

            mouseOverStart = true;
            mText.transform.localScale += new Vector3(-0.1f, -0.15f, 0);

            UnityEngine.SceneManagement.SceneManager.LoadScene("CrashScene");
        }
        else if (this.gameObject.name == "QuitButton")
        {
            this.gameObject.GetComponent<Renderer>().enabled = false;
            mText.gameObject.GetComponent<Renderer>().enabled = false;

            mouseOverStart = true;
            mText.transform.localScale += new Vector3(-0.1f, -0.15f, 0);

            Application.Quit();
        }
        else if (this.gameObject.name == "ControlsButton")
        {
            alienationText.SetActive(false);
            startGameText.SetActive(false);
            startGameButton.SetActive(false);
            quitText.SetActive(false);
            quitButton.SetActive(false);
   
            backButton.SetActive(true);
            backText.SetActive(true);
            controlsImage.GetComponent<SpriteRenderer>().enabled = true;

            mouseOverStart = true;
            mText.transform.localScale += new Vector3(-0.1f, -0.15f, 0);

            mText.gameObject.SetActive(false);
            this.gameObject.SetActive(false);

        }
        else if (this.gameObject.name == "backButton")
        {
            alienationText.SetActive(true);
            startGameButton.SetActive(true);
            quitButton.SetActive(true);
            startGameText.SetActive(true);
            quitText.SetActive(true);
            controlsButton.SetActive(true);
            controlsText.SetActive(true);
            mText.gameObject.SetActive(false);

            mouseOverStart = true;
            mText.transform.localScale += new Vector3(-0.1f, -0.15f, 0);

            controlsImage.GetComponent<SpriteRenderer>().enabled = false;
            this.gameObject.SetActive(false);
        }
    }
}
