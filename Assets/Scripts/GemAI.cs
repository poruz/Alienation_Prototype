using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemAI : MonoBehaviour {

    // Use this for initialization

    public GameObject[] fires;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    void Start () {
		for(int i = 0; i < fires.Length; i++)
        {
            fires[i].GetComponent<FireRotateAndAttack>().gem = this.gameObject;
        }
        //Instantiate all six fires.
        /*
        Instantiate(fires[0], transform.position + transform.up, transform.rotation);
        Instantiate(fires[1], transform.position - transform.up, transform.rotation);
        Instantiate(fires[2], transform.position + transform.right + transform.up, transform.rotation);
        Instantiate(fires[3], transform.position + transform.up - transform.right, transform.rotation);
        Instantiate(fires[4], transform.position - transform.up + transform.right, transform.rotation);
        Instantiate(fires[5], transform.position - transform.up - transform.right, transform.rotation);
        Instantiate(fires[6], transform.position + transform.right, transform.rotation);
        Instantiate(fires[7], transform.position - transform.right, transform.rotation);
        */
        StartCoroutine(MyCoroutine());

    }

    IEnumerator MyCoroutine()
    {
        for(int i = 1; i <=3; i++)
        {
            yield return new WaitForSeconds(3f);

            Instantiate(fires[0], transform.position + transform.up, transform.rotation);
            Instantiate(fires[1], transform.position - transform.up, transform.rotation);
            Instantiate(fires[2], transform.position + transform.right + transform.up, transform.rotation);
            Instantiate(fires[3], transform.position + transform.up - transform.right, transform.rotation);
            Instantiate(fires[4], transform.position - transform.up + transform.right, transform.rotation);
            Instantiate(fires[5], transform.position - transform.up - transform.right, transform.rotation);
            Instantiate(fires[6], transform.position + transform.right, transform.rotation);
            Instantiate(fires[7], transform.position - transform.right, transform.rotation);
        }

        yield return new WaitForSeconds(3f);
        float newX = Random.Range(minX, maxX);
        float newY = Random.Range(minY, maxY);
        Vector2 newPosition = new Vector3(newX, newY, transform.position.z);
        Instantiate(gameObject, newPosition, transform.rotation);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
