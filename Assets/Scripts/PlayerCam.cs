using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCam : MonoBehaviour
{
    
    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;
    Vector2 axis;
    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }
    public void SetCameraMovement(InputAction.CallbackContext context)
    {
        axis = context.ReadValue<Vector2>();
    }
    private void Update()
    {
        // get mouse input
        float mouseX = axis.x * Time.deltaTime * sensX;
        float mouseY = axis.y * Time.deltaTime * sensY;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -35f, 45f);

        // rotate cam and orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}