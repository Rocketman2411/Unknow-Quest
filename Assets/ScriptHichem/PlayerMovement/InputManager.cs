using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private CameraRotation _cameraRotation;
    
    public Vector2 _rotationInput;
    
    public float verticalInput;
    public float horizontalInput;

    private void OnEnable()
    {
        if (_cameraRotation == null)
        {
            _cameraRotation = new CameraRotation();
            _cameraRotation.Rotation.RotateKey.performed += i => _rotationInput = i.ReadValue<Vector2>();
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
    }
    private void HandleMovementInput()
    {
        verticalInput = _rotationInput.y;
        horizontalInput = _rotationInput.x;
    }
}
