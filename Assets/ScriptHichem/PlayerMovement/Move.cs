using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ScriptHichem.PlayerMovement
{
    public class Move : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] float speed;
        [SerializeField] float rotationSmoothTime;

        //[Header("Gravity")]
        //[SerializeField] float gravity = 9.8f;
        //[SerializeField] float gravityMultiplier = 2;
        //[SerializeField] float groundedGravity = -0.5f;
        //[SerializeField] float jumpHeight = 3f;

        [Header("Movement")] 
        [SerializeField] private bool isJumping;
        float velocityY;

        CharacterController controller;
        Camera cam;

        float currentAngle;
        float currentAngleVelocity;

        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void Awake()
        {
            //getting reference for components on the Player
            controller = GetComponent<CharacterController>();
            controller.height = 0f;
            controller.radius = 0f;
            cam = Camera.main;
        }
        
        public void HandleAllTypeOfMovement()
        {
            HandleMovement();
            HandleAndJumping();
        }
        private void HandleMovement()
        {
            //capturing Input from Player
            Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

            if (movement.magnitude >= 0.1f)
            {
                _animator.SetBool("IsMoving", true);
                //compute rotation
                float targetAngle = Mathf.Atan2(movement.x,movement.z ) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
                currentAngle = Mathf.SmoothDampAngle(currentAngle, targetAngle, ref currentAngleVelocity, rotationSmoothTime);
                transform.rotation = Quaternion.Euler(0, currentAngle, 0);

                //move in direction of rotation
                Vector3 rotatedMovement = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
                controller.Move(rotatedMovement * (speed * Time.deltaTime));
            }
            else
            {
                _animator.SetBool("IsMoving", false);
            }
        }

        public void HandleAndJumping()
        {
            
        }
    }
}
