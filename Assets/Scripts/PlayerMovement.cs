using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float timetoMax = 2.5f;
    public float timetobreak = 2.5f;
    public float timetoZero = 2.5f;

    public float groundDrag;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [HideInInspector] public float walkSpeed;
    [HideInInspector] public float sprintSpeed;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    float accel;
    float breaking;
    float decel;
    float forward;

    Vector3 moveDirection;
    Vector2 axis;
    Rigidbody rb;

    public TextMeshProUGUI text_speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;

        accel = moveSpeed / timetoMax;
        breaking = moveSpeed / timetobreak;
        decel = -moveSpeed / timetoZero;

        forward = 0f;
    }

    private void Update()
    {
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();
        SpeedControl();

        // handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }
    
    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = axis.x;
        verticalInput = axis.y;
    }

    private void MovePlayer()
    {
        if (verticalInput > 0)
        {
            forward += verticalInput * accel * Time.deltaTime;
            forward = Mathf.Min(forward, moveSpeed);
        }
        else if (verticalInput < 0)
        {
            forward += verticalInput * breaking * Time.deltaTime;
            forward = Mathf.Max(forward, 0);
        }
        forward += decel * Time.deltaTime;
        forward = Mathf.Max(forward, 0);

        //Debug.LogError(verticalInput);
        // calculate movement direction
        moveDirection = orientation.forward + orientation.right * horizontalInput;

        // on ground
        if (grounded)
        {
            //rb.velocity = moveDirection * forward;
            rb.AddForce(moveDirection.normalized * forward * 10f, ForceMode.Force);
        }
        // in air
        //else if(!grounded)
        //    rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }
    public void SetMovement(InputAction.CallbackContext context)
    {
        axis = context.ReadValue<Vector2>();
    }
    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
        if (text_speed != null)
            text_speed.SetText("Speed: " + flatVel.magnitude);
        //Debug.Log("Speed: " + flatVel.magnitude);
    }

    
}