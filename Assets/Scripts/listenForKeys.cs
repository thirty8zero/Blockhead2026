using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class listenForKeys : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Vertical") != 0)
        {
            Debug.Log("Vert: " + Input.GetAxis("Vertical"));
        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            Debug.Log("Horiz: " + Input.GetAxis("Horizontal"));
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Space Pressed");
        }
    }
}
