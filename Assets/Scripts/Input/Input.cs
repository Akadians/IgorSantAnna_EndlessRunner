using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Input : MonoBehaviour
{

    public void Movement(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton())
        {
            //physics.SetAxis(context.ReadValue<Vector2>());
        }

        if (context.canceled)
        {
            //physics.SetAxis(Vector2.zero);
        }
    }
}
