using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] float lookAngle;
    [SerializeField] float pivotAngle;
        
    [SerializeField] float cameraLookSpeed = 2f;
    [SerializeField] float cameraPivotSpeed = 2f;

    private InputManager _inputManager;

    [SerializeField] Transform cameraPivot;
    
    public void RotateCamera()
    {
        lookAngle = lookAngle + (_inputManager.horizontalInput * cameraLookSpeed);
        pivotAngle = pivotAngle - (_inputManager.verticalInput * cameraPivotSpeed);
            
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
