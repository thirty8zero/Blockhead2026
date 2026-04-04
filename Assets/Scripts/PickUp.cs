using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public GameObject crystal;
    public GameObject crystalUi;
    public GameObject endTrigger;

    void OnCollisionEnter(Collision other)

    {

        if (GameObject.FindWithTag("Player"))

        {
            crystal.SetActive(false);
            crystalUi.SetActive(true);
            endTrigger.GetComponent<EndLevel>().hasKey = true;
        }
    }

}
