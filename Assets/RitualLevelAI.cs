using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RitualLevelAI : MonoBehaviour {

    public GameObject capeBunnyText;
    public GameObject capeBunnyBox;
    public GameObject sadBunnyText;
    public GameObject sadBunnyBox;
    public GameObject riceText;
    public GameObject riceBox;
    public GameObject dissolverText;
    public GameObject dissolverBox;
    public GameObject slenderText;
    public GameObject slenderBox;
    public GameObject antennaText;
    public GameObject antennaBox;

    public AudioSource capeBunnyAudio;
    public AudioSource sadBunnyAudio;
    public AudioSource riceAudio;
    public AudioSource dissolverAudio;
    public AudioSource slenderAudio;
    public AudioSource antennaAudio;

    public GameObject capeBunny;
    public GameObject sadBunny;
    public GameObject rice;
    public GameObject slender;
    public GameObject antenna;
    public GameObject dissolver;
    bool alreadyStarted;
    bool startGettingClose;
    bool startLeaving;
    bool alreadyStartedGettingClose;
    bool alreadyAttacking;
    bool startAttack;

    public GameObject bulletPrefab;

    // Use this for initialization
    void Start () {
        alreadyStarted = false;
        startLeaving = false;
        alreadyStartedGettingClose = false;
        StartCoroutine(Speak());
        alreadyAttacking = false;
        startAttack = false;
	}

    IEnumerator Speak() {
        yield return new WaitForSeconds(1.0f);

        //Cape bunny
        capeBunnyText.SetActive(true);
        capeBunnyBox.SetActive(true);
        string message = "...";
        bool flag = true;
        
        for (int i = 0; i < message.Length && flag; i++)
        {
            capeBunnyText.GetComponent<TextMesh>().text += message[i];
            if (capeBunnyAudio != null)
            {
                ///Debug.Log("Playing");
                if (message[i] != ' ')
                    capeBunnyAudio.Play();
            }
            yield return new WaitForSeconds(0.1f);

            if ((Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.E)) && (i != 0))
            {
                flag = false;
                //str = message;
            }
        }
        if (flag == false) {
            capeBunnyText.GetComponent<TextMesh>().text = message;
        }

        yield return new WaitForSeconds(1.0f);

        capeBunnyText.SetActive(false);
        capeBunnyBox.SetActive(false);
        
        //Sad bunny
        sadBunnyText.SetActive(true);
        sadBunnyBox.SetActive(true);
        message = "...";
        flag = true;

        for (int i = 0; i < message.Length && flag; i++)
        {
            sadBunnyText.GetComponent<TextMesh>().text += message[i];
            if (sadBunnyAudio != null)
            {
                ///Debug.Log("Playing");
                if (message[i] != ' ')
                    sadBunnyAudio.Play();
            }
            yield return new WaitForSeconds(0.1f);

            if ((Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.E)) && (i != 0))
            {
                flag = false;
                //str = message;
            }
        }
        if (flag == false)
        {
            sadBunnyText.GetComponent<TextMesh>().text = message;
        }

        yield return new WaitForSeconds(1.0f);

        sadBunnyText.SetActive(false);
        sadBunnyBox.SetActive(false);

        //slender
        slenderText.SetActive(true);
        slenderBox.SetActive(true);
        message = "THE RITUAL...";
        flag = true;

        for (int i = 0; i < message.Length && flag; i++)
        {
            slenderText.GetComponent<TextMesh>().text += message[i];
            if (slenderAudio != null)
            {
                ///Debug.Log("Playing");
                if (message[i] != ' ')
                    slenderAudio.Play();
            }
            yield return new WaitForSeconds(0.1f);

            if ((Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.E)) && (i != 0))
            {
                flag = false;
                //str = message;
            }
        }
        if (flag == false)
        {
            slenderText.GetComponent<TextMesh>().text = message;
        }

        yield return new WaitForSeconds(1.0f);

        slenderText.SetActive(false);
        slenderBox.SetActive(false);

        //antenna
        antennaText.SetActive(true);
        antennaBox.SetActive(true);
        message = "OUR RITUAL...!";
        flag = true;

        for (int i = 0; i < message.Length && flag; i++)
        {
            antennaText.GetComponent<TextMesh>().text += message[i];
            if (antennaAudio != null)
            {
                ///Debug.Log("Playing");
                if (message[i] != ' ')
                    antennaAudio.Play();
            }
            yield return new WaitForSeconds(0.1f);

            if ((Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.E)) && (i != 0))
            {
                flag = false;
                //str = message;
            }
        }
        if (flag == false)
        {
            antennaText.GetComponent<TextMesh>().text = message;
        }

        yield return new WaitForSeconds(1.0f);

        antennaText.SetActive(false);
        antennaBox.SetActive(false);

        //Rice
        riceText.SetActive(true);
        riceBox.SetActive(true);
        message = "HOW ...";
        flag = true;

        for (int i = 0; i < message.Length && flag; i++)
        {
            riceText.GetComponent<TextMesh>().text += message[i];
            if (riceAudio != null)
            {
                ///Debug.Log("Playing");
                if (message[i] != ' ')
                    riceAudio.Play();
            }
            yield return new WaitForSeconds(0.1f);

            if ((Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.E)) && (i != 0))
            {
                flag = false;
                //str = message;
            }
        }
        if (flag == false)
        {
            riceText.GetComponent<TextMesh>().text = message;
        }

        yield return new WaitForSeconds(1.0f);

        riceText.SetActive(false);
        riceBox.SetActive(false);

        //Dissolver
        dissolverText.SetActive(true);
        dissolverBox.SetActive(true);
        message = "HOW COULD YOU DO THIS...!";
        flag = true;

        for (int i = 0; i < message.Length && flag; i++)
        {
            dissolverText.GetComponent<TextMesh>().text += message[i];
            if (dissolverAudio != null)
            {
                ///Debug.Log("Playing");
                if (message[i] != ' ')
                    dissolverAudio.Play();
            }
            yield return new WaitForSeconds(0.1f);

            if ((Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.E)) && (i != 0))
            {
                flag = false;
                //str = message;
            }
        }
        if (flag == false)
        {
            dissolverText.GetComponent<TextMesh>().text = message;
        }

        yield return new WaitForSeconds(1.0f);

        dissolverText.SetActive(false);
        dissolverBox.SetActive(false);

        //Call Leave Coroutine
        //rice, bunnies, and slender leave
        rice.GetComponent<SpriteRenderer>().flipX = !rice.GetComponent<SpriteRenderer>().flipX;
        sadBunny.GetComponent<SpriteRenderer>().flipX = !sadBunny.GetComponent<SpriteRenderer>().flipX;
        capeBunny.GetComponent<SpriteRenderer>().flipX = !capeBunny.GetComponent<SpriteRenderer>().flipX;
        startLeaving = true;

    }

    IEnumerator leaveTime() {
        alreadyStarted = true;
        yield return new WaitForSeconds(4.0f);
        startLeaving = false;
        startGettingClose = true;
    }

    IEnumerator getCloseTime()
    {
        alreadyStartedGettingClose = true;
        yield return new WaitForSeconds(2.0f);
        startGettingClose = false;
        startAttack = true;
    }

    IEnumerator attackCoroutine()
    {
        startAttack = false;
        alreadyAttacking = true;
        while (true)
        {
            Vector3 newPos = dissolver.transform.position;
            bulletPrefab.GetComponent<BulletMoveRitual>().player = dissolver.gameObject;
            Instantiate(bulletPrefab, newPos, dissolver.transform.rotation);
            yield return new WaitForSeconds(1.0f);
            newPos = antenna.transform.position;
            bulletPrefab.GetComponent<BulletMoveRitual>().player = antenna.gameObject;
            Instantiate(bulletPrefab, newPos, transform.rotation);
            yield return new WaitForSeconds(1.0f);
        }

    }

    // Update is called once per frame
    void Update () {
        if (startLeaving == true) {
            if (!alreadyStarted)
            {
                StartCoroutine(leaveTime());
            }
            capeBunny.transform.position = new Vector3(capeBunny.transform.position.x + 5 * Time.deltaTime,
                capeBunny.transform.position.y , capeBunny.transform.position.z);
            sadBunny.transform.position = new Vector3(sadBunny.transform.position.x + 5 * Time.deltaTime,
                sadBunny.transform.position.y, sadBunny.transform.position.z);
            slender.transform.position = new Vector3(slender.transform.position.x + 5 * Time.deltaTime,
                slender.transform.position.y, slender.transform.position.z);
            rice.transform.position = new Vector3(rice.transform.position.x + 5 * Time.deltaTime,
                rice.transform.position.y, rice.transform.position.z);
        }

        if (startGettingClose == true) {
            if (!alreadyStartedGettingClose) {
                StartCoroutine(getCloseTime());
            }
            dissolver.transform.position = new Vector3(dissolver.transform.position.x - 5 * Time.deltaTime,
                dissolver.transform.position.y, dissolver.transform.position.z);
            antenna.transform.position = new Vector3(antenna.transform.position.x - 4 * Time.deltaTime,
                antenna.transform.position.y, antenna.transform.position.z);
        }

        if (startAttack == true) {
            if (!alreadyAttacking) {
                StartCoroutine(attackCoroutine());
            }
        }
	}
}
