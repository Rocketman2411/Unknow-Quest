using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerControls;
    
    private Vector2 movementInput;
    public float verticalInput;
    public float horizontalInput;
    
    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerInput();
            playerControls.PlayerMovement.Movement.performed += i 
                => movementInput = i.ReadValue<Vector2>();
        }
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;
    }

    public void HandleAllInputs()
    {
        HandleMovementInput();
        //À ajouter :
        // -->HandleJump();
        //-->HandleAction();
    }
}
