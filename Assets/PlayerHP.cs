using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour {

    public GameObject player;
    TextMesh t;
	// Use this for initialization
	void Start () {
        t = GetComponent<TextMesh>();
        t.text = player.GetComponent<PlayerMovementAndAnimControl>().HP.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        t.text = player.GetComponent<PlayerMovementAndAnimControl>().HP.ToString();
    }
}
