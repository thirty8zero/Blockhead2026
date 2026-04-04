using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Notification : MonoBehaviour {

    public GameObject text;
    public GameObject selfDestruct;

    public float delay = 3f;

    void OnTriggerEnter(Collider other)

    {

        if (GameObject.FindWithTag("Player"))

        {
            text.SetActive(true);
            Invoke("Destroy", delay);
        }
    }

    void Destroy()
    {
        text.SetActive(false);
        selfDestruct.SetActive(false);
    }
}
