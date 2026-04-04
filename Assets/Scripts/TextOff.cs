using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextOff : MonoBehaviour {

    public GameObject blockhead;
    public GameObject fadeIn;

	// Use this for initialization
	void Start () {
        if (!GetComponent<GameController>().testingLevel)

        {
            Invoke("TurnOff", 1f);
        }

        else

        {
            TurnOff();
            fadeIn.SetActive(false);
        }
    }
	
    void TurnOff()

    {
        blockhead.SetActive(false);
    }
}
