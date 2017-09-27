using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookAI : MonoBehaviour {

    public GameObject player;
    public GameObject bookText;
    bool flag;

	// Use this for initialization
	void Start () {
        bookText.GetComponent<MeshRenderer>().enabled = false;
        flag = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(player.transform.position, this.transform.position) < 3f && flag) {
        
            StartCoroutine(jump());
            flag = false;
        }
        if (Input.GetKey(KeyCode.Return))
        {
            bookText.GetComponent<MeshRenderer>().enabled = true;
            player.GetComponent<PlayerMovementAndAnimControl>().enabled = false;
            player.GetComponent<BulletShoot>().enabled = false;
            StartCoroutine(reading());
        }
    }

    IEnumerator jump() {

        while (true)
        {
            GetComponent<Rigidbody>().AddForce(transform.up * 4f, ForceMode.Impulse);
            yield return new WaitForSeconds(2.0f);
        }
    
    }

    IEnumerator reading()
    {
        yield return new WaitForSeconds(20f);
        player.GetComponent<PlayerMovementAndAnimControl>().enabled = true;
        player.GetComponent<BulletShoot>().enabled = true;
        Destroy(bookText.gameObject);
        Destroy(gameObject);
    }
}
