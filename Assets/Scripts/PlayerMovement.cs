using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float timetoMax = 2.5f;
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
    float decel;
    float forward;

    Vector3 moveDirection;

    Rigidbody rb;

    public TextMeshProUGUI text_speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;

        accel = moveSpeed / timetoMax;
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
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        if (verticalInput != 0)
        {
            forward += verticalInput*accel * Time.deltaTime;
            forward = Mathf.Min(forward, moveSpeed);
        }
        else
        {
            forward += decel * Time.deltaTime;
            forward = Mathf.Max(forward, 0);
        }
      
        // calculate movement direction
        moveDirection = orientation.forward + orientation.right * horizontalInput;

        // on ground
        if (grounded)
        {
            // rb.velocity = moveDirection * forward;
            rb.AddForce(moveDirection.normalized * forward *10f, ForceMode.Force);
        }
        text_speed.SetText("Speed: " + rb.velocity.magnitude);
        // in air
        //else if(!grounded)
        //    rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
        if(text_speed!=null)
            text_speed.SetText("Speed: " + flatVel.magnitude);
        //Debug.Log("Speed: " + flatVel.magnitude);
    }

}