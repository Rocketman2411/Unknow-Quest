using UnityEngine;

namespace ScriptHichem
{
    public class PlayerLocomotion : MonoBehaviour
    {
        private InputManager _inputManager;
    
        private Vector3 _movementDirection;
        private Transform _cameraObject;
        private Rigidbody _playerRigidbody;

        [SerializeField] float movementSpeed = 5f;
        [SerializeField] float rotationSpeed = 10f;

        private void Awake()
        {
            _inputManager = GetComponent<InputManager>();
            _playerRigidbody = GetComponent<Rigidbody>();
            _cameraObject = Camera.main.transform;
        }

        private void HandleMovement()
        {
            _movementDirection = _cameraObject.forward * _inputManager.verticalInput;
            _movementDirection += _cameraObject.right * _inputManager.horizontalInput;
        
            _movementDirection.Normalize();
            _movementDirection.y = 0;

            _movementDirection *= movementSpeed;

            Vector3 movementVelocity = _movementDirection;
            _playerRigidbody.velocity = movementVelocity;

        }

        private void HandleRotation()
        {
            Vector3 targetDirection = Vector3.zero;

            targetDirection = _cameraObject.forward * _inputManager.verticalInput;
            targetDirection += _cameraObject.right * _inputManager.horizontalInput;
        
            targetDirection.Normalize();
            targetDirection.y = 0;

            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            transform.rotation = playerRotation;
        }

        public void HandleAllMomevent()
        {
            HandleMovement();
            HandleRotation();
        }
    }
}
