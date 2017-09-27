using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemAI : MonoBehaviour {

    // Use this for initialization

    public int gemLife;

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
        
        StartCoroutine(MyCoroutine());

    }

    IEnumerator MyCoroutine()
    {
        int indexJump = 0;
        yield return new WaitForSeconds(3f);

        for (int i = 1; i <= 3; i++) //fires three times in some time
        {
            Instantiate(fires[0 + indexJump], transform.position + transform.up, transform.rotation);
            Instantiate(fires[1 + indexJump], transform.position - transform.up, transform.rotation);
            Instantiate(fires[2 + indexJump], transform.position + transform.right + transform.up, transform.rotation);
            Instantiate(fires[3 + indexJump], transform.position + transform.up - transform.right, transform.rotation);
            Instantiate(fires[4 + indexJump], transform.position - transform.up + transform.right, transform.rotation);
            Instantiate(fires[5 + indexJump], transform.position - transform.up - transform.right, transform.rotation);
            Instantiate(fires[6 + indexJump], transform.position + transform.right, transform.rotation);
            Instantiate(fires[7 + indexJump], transform.position - transform.right, transform.rotation);
            yield return new WaitForSeconds(1f);
            indexJump += 8;

        }

        float newX = Random.Range(minX, maxX);
        float newY = Random.Range(minY, maxY);
        Vector2 newPosition = new Vector3(newX, newY, transform.position.z);

        while (Vector3.Distance(transform.position, newPosition) > 0.01f) {
            transform.position = Vector3.MoveTowards(transform.position, newPosition, 5 * Time.deltaTime);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        
        Instantiate(gameObject, newPosition, transform.rotation);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            gemLife--;
        }
    }
}
