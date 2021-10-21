using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Input : MonoBehaviour
{    
    [SerializeField] private Player _player;
    private Main_Input _inputActions;

    private void Awake()
    {
        Subscribe();
    }

    public void Left(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _player.ChangeLine("Left");
        }
    }

    public void Right(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _player.ChangeLine("Right");
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _player.Jump();
        }
    }

    private void OnDisable()
    {
        Unsubscribe();
    }

    private void Subscribe()
    {
        _inputActions = new Main_Input();
        _inputActions.Enable();
        _inputActions.Gameplay.Jump.performed += Jump;
        _inputActions.Gameplay.Left.performed += Left;
        _inputActions.Gameplay.Right.performed += Right;        
    }

    private void Unsubscribe()
    {
        _inputActions.Gameplay.Left.performed -= Left;
        _inputActions.Gameplay.Right.performed -= Right;
        _inputActions.Gameplay.Jump.performed -= Jump;
        _inputActions.Disable();
    }
}
