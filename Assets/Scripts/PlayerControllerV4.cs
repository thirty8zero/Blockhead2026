using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerV4 : MonoBehaviour
{
    public float moveSpeed;
    public float spinSpeed;
    private Rigidbody myRigidbody;
    public GameObject splat;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    public float jumpForce;
    public bool isGrounded;


    public float downForce;

    private PlayerInput playerInput;
    private InputAction moveAction;

    bool jumped;
    public float jumpTime;
    float jumpTimer;

    private Vector2 smoothedInput = Vector2.zero;
    public float inputSmoothing = 7f; // tune: higher = faster response, lower = smoother

    void Start()
    {

        myRigidbody = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
        if (moveAction != null)
            moveAction.Enable();
        else
            Debug.LogError("Move action not found!");

    }

    // private void OnEnable() { moveAction.Enable(); }
    // private void OnDisable() { moveAction.Disable(); }

    // void FixedUpdate() // Feels pretty close on controller, not so much keyboard
    // {

    //     Vector2 input = moveAction.ReadValue<Vector2>();

    //     // Equivalent to Input.GetAxis("Horizontal") 
    //     if (Mathf.Abs(input.x) > 0.01f && !jumped)
    //     {
    //         myRigidbody.linearVelocity = new Vector3(input.x * moveSpeed, myRigidbody.linearVelocity.y, myRigidbody.linearVelocity.z);
    //         myRigidbody.AddTorque(new Vector3(0, 0, -input.x * spinSpeed), ForceMode.Force);

    //         myRigidbody.AddForce(new Vector3(0, downForce, 0), ForceMode.Acceleration);
    //     }
    //     else
    //     {
    //         myRigidbody.AddForce(new Vector3(0, downForce, 0), ForceMode.Acceleration);
    //     }

    //     // Equivalent to Input.GetAxis("Vertical") 
    //     if (Mathf.Abs(input.y) > 0.01f && !jumped)
    //     {
    //         myRigidbody.linearVelocity = new Vector3(myRigidbody.linearVelocity.x, myRigidbody.linearVelocity.y, input.y * moveSpeed);
    //         myRigidbody.AddTorque(new Vector3(input.y * spinSpeed, 0, 0), ForceMode.Force);

    //         myRigidbody.AddForce(new Vector3(0, downForce, 0), ForceMode.Acceleration);
    //     }
    //     else
    //     {
    //         myRigidbody.AddForce(new Vector3(0, downForce, 0), ForceMode.Acceleration);
    //     }

    // }

    void FixedUpdate()
    {

        Vector2 rawInput = moveAction.ReadValue<Vector2>();

        // Smooth towards raw input
        smoothedInput = Vector2.MoveTowards(smoothedInput, rawInput, Time.fixedDeltaTime * inputSmoothing);

        // Use smoothedInput instead of rawInput below:
        if (Mathf.Abs(smoothedInput.x) > 0.01f && !jumped)
        {
            myRigidbody.linearVelocity = new Vector3(smoothedInput.x * moveSpeed, myRigidbody.linearVelocity.y, myRigidbody.linearVelocity.z);
            myRigidbody.AddTorque(new Vector3(0, 0, -smoothedInput.x * spinSpeed), ForceMode.Force);
            myRigidbody.AddForce(new Vector3(0, downForce, 0), ForceMode.Acceleration);
        }
        else
        {
            myRigidbody.AddForce(new Vector3(0, downForce, 0), ForceMode.Acceleration);
        }

        if (Mathf.Abs(smoothedInput.y) > 0.01f && !jumped)
        {
            myRigidbody.linearVelocity = new Vector3(myRigidbody.linearVelocity.x, myRigidbody.linearVelocity.y, smoothedInput.y * moveSpeed);
            myRigidbody.AddTorque(new Vector3(smoothedInput.y * spinSpeed, 0, 0), ForceMode.Force);
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
