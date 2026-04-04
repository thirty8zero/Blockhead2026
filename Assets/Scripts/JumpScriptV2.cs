using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpScriptV2 : MonoBehaviour
{

    public float jumpForce;
    private bool isGrounded;

    private Rigidbody myRigidbody;

    [SerializeField] InputAction jump;

    void Start()
    {

        myRigidbody = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {

        if (isGrounded == true)
        {

            /* if (Input.GetKeyDown(KeyCode.Space))

            {
                myRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            } */

            if (jump.IsPressed())

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
