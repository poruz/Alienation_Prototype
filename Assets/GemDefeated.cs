﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GemDefeated : MonoBehaviour {

    public GameObject gem;
    public GameObject winText;
    public GameObject gemLife;
    public GameObject player;

	// Use this for initialization
	void Start () {
        Destroy(gem.gameObject);
        //gem.GetComponent<SpriteRenderer>().enabled = false;

        gemLife.SetActive(false);
        winText.GetComponent<Text>().enabled = true;
        player.GetComponent<PlayerMovementAndAnimControl>().enabled = false;
        player.GetComponent<BulletShoot>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
