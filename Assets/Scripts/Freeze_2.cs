using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze_2 : MonoBehaviour {

    public bool paused = false;
    public GameObject text;
    public GameObject selfDestruct;

    // Use this for initialization
    void Start()
    {

        paused = false;
        Time.timeScale = 1;
        selfDestruct.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Blue") && Time.timeScale == 0 && paused == true)

        {
            if (Time.timeScale == 0)
            text.SetActive(false);
            selfDestruct.SetActive(false);
            Time.timeScale = 1;
            paused = false;
        }

    }

    void OnTriggerEnter(Collider other)

    {

        if (GameObject.FindWithTag("Player"))

        {
            text.SetActive(true);
            Time.timeScale = 0;
            paused = true;
        }

    }
}
