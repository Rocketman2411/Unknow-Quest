using System;
using System.Collections;
using System.Collections.Generic;
using ScriptHichem.PlayerMovement;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private CameraRotation _cameraRotation;
    private Move _move;
    
    public Vector2 _rotationInput;
    
    public float verticalInput;
    public float horizontalInput;

    public bool jumpInput;

    private void Awake()
    {
        _move = FindObjectOfType<Move>();
    }

    private void OnEnable()
    {
        if (_cameraRotation == null)
        {
            _cameraRotation = new CameraRotation();
            _cameraRotation.Rotation.RotateKey.performed += i => _rotationInput = i.ReadValue<Vector2>();
            _cameraRotation.AllPlayerAction.Jump.performed += i => jumpInput = true;
        }
        _cameraRotation.Enable();
    }

    private void OnDisable()
    {
        _cameraRotation.Disable();
    }

    public void HandleAllInput()
    {
        HandleMovementInput();
        HandleJumpingInput();
    }
    private void HandleMovementInput()
    {
        verticalInput = _rotationInput.y;
        horizontalInput = _rotationInput.x;
    }
    private void HandleJumpingInput()
    {
        if (jumpInput)
        {
            jumpInput = false;
            _move.HandleAndJumping();
        }   
    }
}
