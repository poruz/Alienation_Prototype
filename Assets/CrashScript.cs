using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(crashCoroutine());	
	}

    IEnumerator crashCoroutine() {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 9; i++)
        {
            if (i % 2 == 0)
            {
                this.gameObject.GetComponent<Camera>().backgroundColor = Color.white;
            }
            else {
                this.gameObject.GetComponent<Camera>().backgroundColor = Color.black;
            }
            yield return new WaitForSeconds(Random.Range(0.2f, 0.6f));
        }
        this.gameObject.GetComponent<Camera>().backgroundColor = Color.black;
        yield return new WaitForSeconds(2.0f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("RitualLevel");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
