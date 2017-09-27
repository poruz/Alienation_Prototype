using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemHP : MonoBehaviour {

    public GameObject gem;
    TextMesh t;
    // Use this for initialization
    void Start()
    {
        t = GetComponent<TextMesh>();
        t.text = gem.GetComponent<GemAI>().gemLife.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        t.text = gem.GetComponent<GemAI>().gemLife.ToString();
    }
}
