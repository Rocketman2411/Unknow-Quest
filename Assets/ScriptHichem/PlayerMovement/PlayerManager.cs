using UnityEngine;

namespace ScriptHichem.PlayerMovement
{
    public class PlayerManager : MonoBehaviour
    {
        private InputManager _inputManager;
        private Move _move;
        private CameraManager _cameraManager;

        private void Awake()
        {
            _inputManager = FindObjectOfType<InputManager>();
            _move = FindObjectOfType<Move>();
            _cameraManager = FindObjectOfType<CameraManager>();
        }

        private void Update()
        {
            _inputManager.HandleAllInput();
            _move.HandleAllTypeOfMovement();
        }

        private void LateUpdate()
        {
            _cameraManager.HandleAllMovement();
        }
    }
}
