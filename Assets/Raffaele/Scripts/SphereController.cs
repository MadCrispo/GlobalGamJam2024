using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class SphereController : MonoBehaviour
{
    private Rigidbody rb;

    public float speed = 5f;
    private Vector3 direction;
    private bool isOrtofrutta = false;
    private bool isSurgelati = false;
    public float initialSpeed = 5f;

    
    private float decelerationOrtofrutta = 0.05f;

    private float accelerationSurgelati = 3f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        CheckZone();
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);
        direction = transform.TransformDirection(movement).normalized;

        if (!isSurgelati)
        {
            rb.AddForce(direction * speed);
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ortofrutta"))
        {
            isOrtofrutta = true;
            isSurgelati = false;

        } else if (other.gameObject.CompareTag("Surgelati"))
        {
            isSurgelati = true;
            isOrtofrutta = false;
        } else
        {
            isSurgelati = false;
            isOrtofrutta = false;
            speed = initialSpeed;
        }
    }

    private void CheckZone()
    {
        if (isOrtofrutta)
        {
            rb.velocity -= decelerationOrtofrutta * rb.velocity;

        } else if(isSurgelati)
        {
            // rb.velocity += accelerationSurgelati * rb.velocity;
            speed += accelerationSurgelati;
        }

    }

   

}
