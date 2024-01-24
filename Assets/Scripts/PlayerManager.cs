using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private CharacterControllerInput m_controller;

    // Update is called once per frame
    void Update()
    {
        m_controller.HandleMovementInput(InputManager.GetInputValue<Vector2>("PlayerMovement") );
    }
}
