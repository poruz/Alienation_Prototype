using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GemAI : MonoBehaviour {

    // Use this for initialization

    public int oldIndex;

    public GameObject[] endPlatforms;

    public int gemLife;
    public GameObject winText;

    public AudioSource fireAudio;
	public AudioSource gemDestroyAudio;

    public GameObject[] fires;

    public float[] xPositions;
    public float[] yPositions;

    void Start () {
        //oldIndex = -1;
        winText.GetComponent<Text>().enabled = false;

        for (int i = 0; i < fires.Length; i++)
        {
            fires[i].GetComponent<FireRotateAndAttack>().gem = this.gameObject;
        }

        for (int i = 0; i < endPlatforms.Length; i++)
        {
            endPlatforms[i].SetActive(false);
        }

        StartCoroutine(MyCoroutine());

    }

    IEnumerator MyCoroutine()
    {
        int indexJump = 0;
        yield return new WaitForSeconds(3f);

        fireAudio.Play();
        Instantiate(fires[0 + indexJump], transform.position + 3 * transform.up, transform.rotation);
        Instantiate(fires[1 + indexJump], transform.position - 3 * transform.up, transform.rotation);
        Instantiate(fires[2 + indexJump], transform.position + 3 * transform.right + 3 * transform.up, transform.rotation);
        Instantiate(fires[3 + indexJump], transform.position + 3 * transform.up - 3 * transform.right, transform.rotation);
        Instantiate(fires[4 + indexJump], transform.position - 3 * transform.up + 3 * transform.right, transform.rotation);
        Instantiate(fires[5 + indexJump], transform.position - 3 * transform.up - 3 * transform.right, transform.rotation);
        Instantiate(fires[6 + indexJump], transform.position + 3 * transform.right, transform.rotation);
        Instantiate(fires[7 + indexJump], transform.position - 3 * transform.right, transform.rotation);
        yield return new WaitForSeconds(1f);
        indexJump += 8;

        fireAudio.Play();
        Instantiate(fires[0 + indexJump], transform.position + 3 * transform.up + 0.5f * transform.right, transform.rotation);
        Instantiate(fires[1 + indexJump], transform.position - 3 * transform.up - 0.5f * transform.right, transform.rotation);
        Instantiate(fires[2 + indexJump], transform.position + 3.5f * transform.right + 2.5f * transform.up, transform.rotation);
        Instantiate(fires[3 + indexJump], transform.position + 3.5f * transform.up - 2.5f * transform.right, transform.rotation);
        Instantiate(fires[4 + indexJump], transform.position - 3.5f * transform.up + 2.5f * transform.right, transform.rotation);
        Instantiate(fires[5 + indexJump], transform.position - 2.5f * transform.up - 3.5f * transform.right, transform.rotation);
        Instantiate(fires[6 + indexJump], transform.position + 3 * transform.right - 0.5f * transform.up, transform.rotation);
        Instantiate(fires[7 + indexJump], transform.position - 3 * transform.right + 0.5f * transform.up, transform.rotation);
        yield return new WaitForSeconds(1f);
        indexJump += 8;

        fireAudio.Play();
        Instantiate(fires[0 + indexJump], transform.position + 3 * transform.up + 1f * transform.right, transform.rotation);
        Instantiate(fires[1 + indexJump], transform.position - 3 * transform.up - 1f * transform.right, transform.rotation);
        Instantiate(fires[2 + indexJump], transform.position + 4f * transform.right + 2f * transform.up, transform.rotation);
        Instantiate(fires[3 + indexJump], transform.position + 4f * transform.up - 2f * transform.right, transform.rotation);
        Instantiate(fires[4 + indexJump], transform.position - 4f * transform.up + 2f * transform.right, transform.rotation);
        Instantiate(fires[5 + indexJump], transform.position - 2f * transform.up - 4f * transform.right, transform.rotation);
        Instantiate(fires[6 + indexJump], transform.position + 3 * transform.right - 1f * transform.up, transform.rotation);
        Instantiate(fires[7 + indexJump], transform.position - 3 * transform.right + 1f * transform.up, transform.rotation);
        yield return new WaitForSeconds(1f);
        indexJump += 8;


        int newIndex;
        do
        {
            newIndex = Random.Range(0, 7); //7 exclusive
            //Debug.Log("OldIndex: " + oldIndex + " NewIndex: " + newIndex);
        }while(newIndex == oldIndex); //The loop sures the gem does not stay at the same index after attacking
     
        Vector2 newPosition = new Vector3(xPositions[newIndex], yPositions[newIndex], transform.position.z);

        oldIndex = newIndex;

        while (Vector3.Distance(transform.position, newPosition) > 0.01f) {
            transform.position = Vector3.MoveTowards(transform.position, newPosition, 10 * Time.deltaTime);
            yield return new WaitForSeconds(Time.deltaTime);
        }

        StartCoroutine(MyCoroutine());
        //Instantiate(gameObject, newPosition, transform.rotation);
        //Destroy(gameObject);
    }

    // Update is called once per frame
    void Update () {
        if (gemLife <= 0)
        {
			gemDestroyAudio.Play ();
            for (int i = 0; i < endPlatforms.Length; i++)
            {
                endPlatforms[i].SetActive(true);
            }
            GetComponent<GemDefeated>().enabled = true;
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet" 
                && Vector3.Distance(transform.position, collision.gameObject.transform.position) > 2f )
        {
            gemLife-=20;
        }
    }
}
