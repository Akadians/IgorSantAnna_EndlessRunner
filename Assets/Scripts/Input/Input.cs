using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Input : MonoBehaviour
{    
    [SerializeField] private Player player;

    public void Movement(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //physics.SetAxis(context.ReadValue<Vector2>());
        }

        if (context.canceled)
        {
            //physics.SetAxis(Vector2.zero);
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            player.Jump();
        }
    }
}
