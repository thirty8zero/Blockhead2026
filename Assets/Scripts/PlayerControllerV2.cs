using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerV2 : MonoBehaviour
{

    public float moveSpeed;
    public float spinSpeed;
    private Rigidbody rb;
    public GameObject splat;

    private Vector3 moveInput;
    private Vector3 moveVelocity;


    public float jumpForce;
    private bool isGrounded;

    public float downForce;

    PlayerInput playerInput;
    InputAction moveAction;

    Vector3 move = Vector3.zero;

    //public GameObject buttonCanvas;
    //public bool onOff = false;

    bool jumped;
    public float jumpTime;
    float jumpTimer;

    private void OnEnable()
    {
        moveAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
    }
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");

    }

    void FixedUpdate()
    {

        Vector2 direction = moveAction.ReadValue<Vector2>();

        if (moveAction.IsPressed() && !jumped)
        {
            rb.linearVelocity = new Vector3(direction.x * moveSpeed, rb.linearVelocity.y, rb.linearVelocity.z);
            rb.AddTorque(new Vector3(0, 0, -direction.x * spinSpeed), ForceMode.Force);

            rb.AddForce(new Vector3(0, downForce, 0), ForceMode.Acceleration);
        }

        else

        {
            rb.AddForce(new Vector3(0, downForce, 0), ForceMode.Acceleration);
        }

        if (moveAction.IsPressed() && !jumped)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, rb.linearVelocity.y, direction.y * moveSpeed);
            rb.AddTorque(new Vector3(Input.GetAxis("Vertical") * spinSpeed, 0, 0), ForceMode.Force);

            rb.AddForce(new Vector3(0, downForce, 0), ForceMode.Acceleration);
        }

        else

        {
            rb.AddForce(new Vector3(0, downForce, 0), ForceMode.Acceleration);
        }




        /* if (Input.GetAxis("Horizontal") != 0 && !jumped)
        {
            rb.linearVelocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, rb.linearVelocity.y, rb.linearVelocity.z);
            rb.AddTorque(new Vector3(0, 0, -Input.GetAxis("Horizontal") * spinSpeed), ForceMode.Force);

            rb.AddForce(new Vector3(0, downForce, 0), ForceMode.Acceleration);
        }

        else

        {
            rb.AddForce(new Vector3(0, downForce, 0), ForceMode.Acceleration);
        } */

        /* if (Input.GetAxis("Vertical") != 0 && !jumped)

        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, rb.linearVelocity.y, Input.GetAxis("Vertical") * moveSpeed);
            rb.AddTorque(new Vector3(Input.GetAxis("Vertical") * spinSpeed, 0, 0), ForceMode.Force);

            rb.AddForce(new Vector3(0, downForce, 0), ForceMode.Acceleration);
        }

        else

        {
            rb.AddForce(new Vector3(0, downForce, 0), ForceMode.Acceleration);
        } */
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
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
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
