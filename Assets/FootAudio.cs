using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootAudio : MonoBehaviour {

    AudioSource audio;
    public bool flag;

    // Use this for initialization
    void Start () {
        flag = false;
        audio = GetComponent<AudioSource>();
        audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnEnable()
    {
        if (flag == true)
        {
            Start();
        }
    }

}
