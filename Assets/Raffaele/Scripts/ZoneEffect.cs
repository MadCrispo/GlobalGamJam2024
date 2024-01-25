using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneEffect : MonoBehaviour
{
    private Rigidbody rb;

    public float decelerationOrtofrutta = 0.05f;
    public float accelerationSurgelati = 3f;

    public Zone zona = Zone.Surgelati;
    
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("stay");
        rb = other.GetComponentInParent<Rigidbody>();

        switch ((int)zona)
        {
            case (int)Zone.Surgelati:
                rb.velocity += accelerationSurgelati * rb.velocity;
                break;
            case (int)Zone.Ortofrutta:
                rb.velocity -= decelerationOrtofrutta * rb.velocity;
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
        rb = other.GetComponentInParent<Rigidbody>();
        switch ((int)zona)
        {
            case (int)Zone.Surgelati:
                rb.velocity += accelerationSurgelati * rb.velocity;
                break;
            case (int)Zone.Ortofrutta:
                rb.velocity -= decelerationOrtofrutta * rb.velocity;
                break;
        }
    }
}
public enum Zone { Surgelati=0,Ortofrutta=1 }