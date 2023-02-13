using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class ControllerManager : MonoBehaviour
{
    private Vector3 _previousPosition;
    
    private float _speed = 50f;
    private float _rotateSpeed = 10f;

    private float _rotY;
    private float _rotX;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Gamepad.all.Count; i++)
        {
            Debug.Log(Gamepad.all[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        _rotY += Input.GetAxis("Vertical") * _rotateSpeed ;
        _rotX += Input.GetAxis("Horizontal") * _rotateSpeed;
        
        if (Gamepad.all.Count > 0)
        {
            if (Gamepad.all[0].leftStick.left.isPressed)
            {
                transform.Translate(Vector2.left *(_speed * Time.deltaTime));
            }
            if (Gamepad.all[0].leftStick.right.isPressed)
            {
                transform.Translate(Vector2.right *(_speed * Time.deltaTime));
            }
            if (Gamepad.all[0].leftStick.up.isPressed)
            {
                transform.localPosition += Vector3.forward * (_speed * Time.deltaTime);
            }
            if (Gamepad.all[0].leftStick.down.isPressed)
            {
                transform.localPosition += Vector3.back * (_speed * Time.deltaTime);
            }
            
        }
    }
}
