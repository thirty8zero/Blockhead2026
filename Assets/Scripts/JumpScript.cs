using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour {

    public float jumpForce;
    private bool isGrounded;

    private Rigidbody myRigidbody;

    void Start()
    {

        myRigidbody = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {

        if (isGrounded == true)
        {

            if (Input.GetKeyDown(KeyCode.Space))

            {
                myRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }

        }

    }

        void OnTriggerStay(Collider collisionInfo)
    {
        isGrounded = true;
    }

    void OnTriggerExit(Collider collisionInfo)
    {
        isGrounded = false;
    }

    void OnTriggerEnter(Collider collisionInfo)
    {
        isGrounded = true;
    }
}
