using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static Manager_InputSystem InputsController { get; private set; }
    // Start is called before the first frame update
    void Awake()
    {
        InputsController = new Manager_InputSystem();
    }
    private void OnEnable()
    {
        InputsController.EnableInputSystem();
    }
    private void OnDisable()
    {
        InputsController.DisableInputSystem();
    }
    public static bool OnInputTrigger(string inputActionName)
    {
       return InputsController.OnInputTrigger(inputActionName);
    }
    public static  bool OnInputPressed(string inputActionName)
    {
       return InputsController.OnInputPressed(inputActionName);
    }

    public static T GetInputValue<T>(string inputActionName) where T : struct
    {
       return  InputsController.GetInputValue<T>(inputActionName);
    }

}
