using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze_1 : MonoBehaviour {

    public bool paused = false;
    public GameObject text;
    public GameObject selfDestruct;

    // Use this for initialization
    void Start () {

        paused = false;
        Time.timeScale = 1;
        selfDestruct.SetActive(true);

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Green") && paused == true)

        {
            Time.timeScale = 1;
            text.SetActive(false);
            selfDestruct.SetActive(false);
            
            paused = false;
        }

    }

    void OnTriggerEnter(Collider other)

    {

        if (GameObject.FindWithTag("Player"))

        {
            //GetComponent<AudioSource>().Play();
            text.SetActive(true);
            Time.timeScale = 0;
            paused = true;
        }

    }
}
