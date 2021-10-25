using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Input : MonoBehaviour
{    
    [SerializeField] private Player _player;

    private Main_Input _inputActions;    

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

    private void Awake()
    {
        Subscribe();
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
    }

    private void Unsubscribe()
    {
        _inputActions.Gameplay.Left.performed -= Left;
        _inputActions.Gameplay.Right.performed -= Right;       
        _inputActions.Disable();
    }
}
