using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject startGameButton = GameObject.Find("StartGameButton");
            
            startGameButton.GetComponent<MetricManager>().AddToLevelMetric((int)Time.timeSinceLevelLoad,
                startGameButton.GetComponent<MetricManager>().levelNameToIndex[SceneManager.GetActiveScene().name]);

            string currScene = SceneManager.GetActiveScene().name;
            if (currScene == "RitualLevel")
                UnityEngine.SceneManagement.SceneManager.LoadScene("CaveLevel");
            else if (currScene == "CaveLevel")
                UnityEngine.SceneManagement.SceneManager.LoadScene("VillageLevel");
            else if (currScene == "VillageLevel")
                UnityEngine.SceneManagement.SceneManager.LoadScene("CombatLevel");
            else if (currScene == "CombatLevel")
                UnityEngine.SceneManagement.SceneManager.LoadScene("LastLevel");

        }
    }
}
