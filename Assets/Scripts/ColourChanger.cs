using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using UnityEngine;


public class ColourChanger : MonoBehaviour
{

    public Material[] material;
    public int playMatNumber = 1;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.material = material[0];
    }

    void Update()
    {
        if (Input.GetButtonDown("Blue"))
        {
            rend.material = material[0];
            playMatNumber = 1;
        }

        if (Input.GetButtonDown("Green"))
        {
            rend.material = material[1];
            playMatNumber = 2;
        }

        if (Input.GetButtonDown("Yellow"))
        {
            rend.material = material[2];
            playMatNumber = 3;
        }

        if (Input.GetButtonDown("Red"))
        {
            rend.material = material[3];
            playMatNumber = 4;

        }

    }

}
