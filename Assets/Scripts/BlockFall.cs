using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFall : MonoBehaviour {

    private Rigidbody myRigidbody;

    // Use this for initialization
    void Start ()

    {
        myRigidbody = GetComponent<Rigidbody>();
        Invoke("Fall", 2.4f);
	}
	
	// Update is called once per frame
	void Fall ()

    {
        myRigidbody.isKinematic = false;
	}
}
