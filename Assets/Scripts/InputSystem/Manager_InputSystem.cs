using System.Collections.Generic;
using System.Linq;
using UnityEngine.InputSystem;
using UnityEngine;
public class Manager_InputSystem
{
    private InputSystemAsset playerInputs;
    private Dictionary<string, InputAction> inputs;

    public Manager_InputSystem()
    {
        playerInputs = new InputSystemAsset();
        InputSystem.settings.maxEventBytesPerUpdate = 0;

        inputs = playerInputs.asset.actionMaps
            .SelectMany(am => am.actions)
            .ToDictionary(a => a.name, a => a);

    }

    public void EnableInputSystem()
    {
        playerInputs.Enable();
    }

    public void DisableInputSystem()
    {
        playerInputs.Disable();
    }

    public bool OnInputTrigger(string inputActionName)
    {
        return GetInputAction(inputActionName)?.triggered ?? false;
    }

    public bool OnInputPressed(string inputActionName)
    {
        return GetInputAction(inputActionName)?.IsPressed() ?? false;
    }

    public T GetInputValue<T>(string inputActionName) where T : struct
    {
        return GetInputAction(inputActionName)?.ReadValue<T>() ?? default;
    }

    private InputAction GetInputAction(string inputActionName)
    {
        if (inputs.TryGetValue(inputActionName, out var inputAction))
        {
            return inputAction;
        }
        else
        {
            Debug.LogWarning($"Input action '{inputActionName}' not found.");
            return null;
        }
    }
}