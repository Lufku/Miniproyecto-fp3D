using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public CharacterController controller;
    public float speed = 8f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    [Header("FPS Camera")]
    public Camera playerCamera;
    public float mouseSensitivity = 150f;
    private float xRotation = 0f;

    [Header("Shooting")]
    public float shootDistance = 100f;

    [Header("Audio")]
    public AudioClip footStepSound;
    public float footStepDelay = 0.5f;

    private float nextFootstep = 0f;

    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HandleMouseLook();
        HandleMovement();
        HandleJump();
        HandleGravity();
        HandleFootsteps();
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    void HandleMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
    }

    void HandleJump()
    {
        isGrounded = Physics.CheckSphere(
            groundCheck.position,
            groundDistance,
            groundMask
        );

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    void HandleGravity()
    {
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void HandleFootsteps()
    {
        bool moving =
            Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.D);

        if (moving && isGrounded)
        {
            nextFootstep -= Time.deltaTime;

            if (nextFootstep <= 0)
            {
                GetComponent<AudioSource>()
                    .PlayOneShot(footStepSound, 0.7f);

                nextFootstep = footStepDelay;
            }
        }
    }
}