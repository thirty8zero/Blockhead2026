using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public float spinSpeed;
    private Rigidbody myRigidbody;
    public GameObject splat;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    public float jumpForce;
    //private bool isGrounded;
    public bool isGrounded;


    public float downForce;

    //public GameObject buttonCanvas;
    //public bool onOff = false;

    bool jumped;
    public float jumpTime;
    float jumpTimer;

    void Start()
    {

        myRigidbody = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {

        if (Input.GetAxis("Horizontal") != 0 && !jumped)
        {
            myRigidbody.linearVelocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, myRigidbody.linearVelocity.y, myRigidbody.linearVelocity.z);
            myRigidbody.AddTorque(new Vector3(0, 0, -Input.GetAxis("Horizontal") * spinSpeed), ForceMode.Force);

            myRigidbody.AddForce(new Vector3(0, downForce, 0), ForceMode.Acceleration);
        }

        else

        {
            myRigidbody.AddForce(new Vector3(0, downForce, 0), ForceMode.Acceleration);
        }

        if (Input.GetAxis("Vertical") != 0 && !jumped)

        {
            myRigidbody.linearVelocity = new Vector3(myRigidbody.linearVelocity.x, myRigidbody.linearVelocity.y, Input.GetAxis("Vertical") * moveSpeed);
            myRigidbody.AddTorque(new Vector3(Input.GetAxis("Vertical") * spinSpeed, 0, 0), ForceMode.Force);

            myRigidbody.AddForce(new Vector3(0, downForce, 0), ForceMode.Acceleration);
        }

        else

        {
            myRigidbody.AddForce(new Vector3(0, downForce, 0), ForceMode.Acceleration);
        }
    }

    void Update()

    {
        if (jumped)
        {
            jumpTimer += Time.deltaTime;
        }

        if (jumpTimer >= jumpTime)
        {
            jumped = false;
        }
        if (Input.GetButtonDown("Jump"))
        {

            if (isGrounded == true)

            {
                GetComponent<AudioSource>().Play();
                myRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                jumped = true;
                jumpTimer = 0;
            }

        }

    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Cube")

        {
            //splat.GetComponent<AudioSource>().Play();
            isGrounded = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        isGrounded = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cube")

        {
            //splat.GetComponent<AudioSource>().Play();
            isGrounded = true;
        }

    }

    void OnCollisionEnter(Collision other)
    {
        splat.GetComponent<AudioSource>().Play();
    }
}
