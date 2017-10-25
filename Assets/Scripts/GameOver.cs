using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    public GameObject gameOverText;
    public GameObject player;
    public GameObject playerHP;


    // Use this for initialization
    void Start () {
        playerHP.GetComponent<PlayerHP>().enabled = false;
        playerHP.GetComponent<TextMesh>().text = "";
        player.GetComponent<SpriteRenderer>().enabled = false;
        player.GetComponent<BoxCollider2D>().enabled = false;
        gameOverText.GetComponent<Text>().enabled = true;
        //GetComponent<GemAI>().enabled = false;
        GetComponent<PlayerMovementAndAnimControl>().enabled = false;
        GetComponent<BulletShoot>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.R))
        {
            Scene loadedLevel = SceneManager.GetActiveScene();
            SceneManager.LoadScene(loadedLevel.buildIndex);
        }
	}
}
