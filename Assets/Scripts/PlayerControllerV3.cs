using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerV3 : MonoBehaviour
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

    public float acceleration = 10f;
    public float lDamp = 0.5f;
    public float aDamp = 0.05f;

    bool jumped;
    public float jumpTime;
    float jumpTimer;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
    }

    private void OnEnable()
    {
        moveAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
    }


    void FixedUpdate()
    {

        Vector2 direction = moveAction.ReadValue<Vector2>();

        if (!jumped)
        {

            if (Mathf.Abs(direction.x) > 0.01f)
            {
                // rb.linearVelocity = new Vector3(direction.x * moveSpeed, rb.linearVelocity.y, rb.linearVelocity.z);
                // rb.AddTorque(new Vector3(0, 0, -direction.x * spinSpeed), ForceMode.Force);
                // // rb.AddForce(new Vector3(0, downForce / 2, 0), ForceMode.Acceleration);

                // Vector3 targetVelocity = new Vector3(direction.x * moveSpeed, rb.linearVelocity.y, rb.linearVelocity.z);
                // rb.linearVelocity = Vector3.Lerp(rb.linearVelocity, targetVelocity, Time.fixedDeltaTime * acceleration);

                // rb.AddTorque(new Vector3(0, 0, -direction.x * spinSpeed), ForceMode.Force);

                rb.linearVelocity = new Vector3(direction.x * moveSpeed, rb.linearVelocity.y, rb.linearVelocity.z);
                rb.AddTorque(new Vector3(0, 0, -direction.x * spinSpeed), ForceMode.Force);
            }

            if (Mathf.Abs(direction.y) > 0.01f)
            {
                // rb.linearVelocity = new Vector3(rb.linearVelocity.x, rb.linearVelocity.y, direction.y * moveSpeed);
                // rb.AddTorque(new Vector3(Input.GetAxis("Vertical") * spinSpeed, 0, 0), ForceMode.Force);
                // // rb.AddForce(new Vector3(0, downForce / 2, 0), ForceMode.Acceleration);

                // Vector3 targetVelocity = new Vector3(rb.linearVelocity.x, rb.linearVelocity.y, direction.y * moveSpeed);
                // rb.linearVelocity = Vector3.Lerp(rb.linearVelocity, targetVelocity, Time.fixedDeltaTime * acceleration);

                // rb.AddTorque(new Vector3(direction.y * spinSpeed, 0, 0), ForceMode.Force);

                rb.linearVelocity = new Vector3(rb.linearVelocity.x, rb.linearVelocity.y, direction.y * moveSpeed);
                rb.AddTorque(new Vector3(direction.y * spinSpeed, 0, 0), ForceMode.Force);
            }

            rb.AddForce(new Vector3(0, downForce, 0), ForceMode.Acceleration);
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
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                jumped = true;
                jumpTimer = 0;
            }

        }

        rb.linearDamping = lDamp;
        rb.angularDamping = aDamp;

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
