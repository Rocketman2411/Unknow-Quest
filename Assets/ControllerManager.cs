using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class ControllerManager : MonoBehaviour
{
    [SerializeField] public Camera cam;
    
    private CharacterController _characterController;

    private float speed = 5f;
    private float turnSpeed = 90f;
    
    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertival = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(Horizontal, 0f, Vertival).normalized;

        if (direction.magnitude >= 0.1f)
        {
            if (Gamepad.all.Count > 0)
            {
                if (Gamepad.all[0].leftStick.left.isPressed)
                {
                    _characterController.Move(direction * (speed * Time.deltaTime));
                    //transform.Translate(Vector2.left *(speed * Time.deltaTime));
                }
                if (Gamepad.all[0].leftStick.right.isPressed)
                {
                    //transform.Translate(Vector2.right *(speed * Time.deltaTime));
                }
                if (Gamepad.all[0].leftStick.up.isPressed)
                {
                    //_characterController.Move(transform.forward * Input.GetAxis("Vertical") * (speed * Time.deltaTime));
                }
                if (Gamepad.all[0].rightStick.right.isPressed)
                {
                    //cam.transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * (turnSpeed * Time.deltaTime));
                }
            }
        }
        
    }
}
