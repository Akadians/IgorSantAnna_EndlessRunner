using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Input : MonoBehaviour
{    
    [SerializeField] private Player _player;

    private Main_Input _inputActions;   
    public void Initializations()
    {
        Subscribe();
    }
    public void Left(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _player.ChangeLine(MoveType.LEFT);
        }
    }

    public void Right(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _player.ChangeLine(MoveType.RIGHT);
        }
    }

    public void TouchDirection(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if(context.ReadValue<float>() > 0)
            {
                _player.ChangeLine(MoveType.RIGHT);
            }
            else if (context.ReadValue<float>() < 0)
            {
                _player.ChangeLine(MoveType.LEFT);
            }
        }
    }

    public void TouchPress(InputAction.CallbackContext context)
    {
        if (context.performed)
        {

        }
    }

    private void Awake()
    {
        Initializations();
    }
    private void OnDisable()
    {
        Unsubscribe();
    }

    private void Subscribe()
    {
        _inputActions = new Main_Input();
        _inputActions.Enable();        
        _inputActions.Gameplay.Left.performed += Left;
        _inputActions.Gameplay.Right.performed += Right;
        _inputActions.Gameplay.TouchDirection.performed += TouchDirection;
        _inputActions.Gameplay.TouchPress.performed += TouchPress;
    }

    private void Unsubscribe()
    {
        _inputActions.Gameplay.Left.performed -= Left;
        _inputActions.Gameplay.Right.performed -= Right;
        _inputActions.Gameplay.TouchDirection.performed -= TouchDirection;
        _inputActions.Gameplay.TouchPress.performed -= TouchPress;
        _inputActions.Disable();
    }
}
