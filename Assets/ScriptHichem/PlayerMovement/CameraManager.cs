using System;
using System.Collections;
using System.Collections.Generic;
using ScriptHichem.PlayerMovement;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform _targetTransform; //L'objet que la caméra vas suivre
    private Vector3 _cameraFollowVelocity = Vector3.zero;

    public float _cameraFollowSpeed = 0.2f;
    
    public float lookAngle;
    public float pivotAngle;
        
    public float cameraLookSpeed = 2f;
    public float cameraPivotSpeed = 2f;

    private InputManager _inputManager;

    [SerializeField] Transform cameraPivot;

    private void Awake()
    {
        _inputManager = FindObjectOfType<InputManager>();
        _targetTransform = FindObjectOfType<PlayerManager>().transform;
    }

    public void HandleAllMovement()
    {
        FollowTarget();
        RotateCamera();
    }
    private void FollowTarget()
    {
        Vector3 targetPosition = Vector3.SmoothDamp
        (transform.position, _targetTransform.position,ref _cameraFollowVelocity, _cameraFollowSpeed);

        transform.position = targetPosition;
    }
    private void RotateCamera()
    {
        lookAngle += (_inputManager.horizontalInput * cameraLookSpeed);
        pivotAngle -= (_inputManager.verticalInput * cameraPivotSpeed);
            
        Vector3 rotation = Vector3.zero;
        rotation.y = lookAngle;
        Quaternion targetRotation = Quaternion.Euler(rotation);

        transform.rotation = targetRotation;

        rotation = Vector3.zero;
        rotation.x = pivotAngle;
        targetRotation = Quaternion.Euler(rotation);

        cameraPivot.localRotation = targetRotation;
    }
}
