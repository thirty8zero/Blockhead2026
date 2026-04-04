using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle : MonoBehaviour {

    public bool onOff = true;
    public GameObject canvas;

	// Use this for initialization
	void Start () {
		
	}
	
	

	void Update () {

        if (Input.GetButtonDown("Toggle"))

    {
            onOff = !onOff;
    }

        if (onOff == true)
        {
            canvas.gameObject.SetActive(true);
        }

        if (onOff == false)
        {
            canvas.gameObject.SetActive(false);
        }

    }
    }
