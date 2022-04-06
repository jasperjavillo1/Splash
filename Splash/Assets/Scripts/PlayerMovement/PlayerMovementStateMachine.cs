using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//Context of the Player Movement State Machine
public class PlayerMovementStateMachine : MonoBehaviour
{
    //reference variables
    private PlayerInput _playerInput;
    private CharacterController _characterController;

    //player input value variables
    private Vector2 _currentMovementInput;
    private Vector3 _currentMovement;
    private bool _isMovementPressed;

    //getters and setters
    public PlayerInput PlayerInput { get { return _playerInput; } set { _playerInput = value; } }
    public CharacterController CharacterController { get { return _characterController; } }

    public Vector2 CurrentMovementInput { get { return _currentMovementInput; } set { _currentMovementInput = value; } }
    public Vector3 CurrentMovement { get { return _currentMovement; } set { _currentMovement = value; } }
    public bool IsMovementPressed { get { return _isMovementPressed; } set { _isMovementPressed = value; } }

    void Awake()
    {
        _playerInput = new PlayerInput();
        _characterController = GetComponent<CharacterController>();

        _playerInput.CharacterControls.Move.started += onMovementInput;
        _playerInput.CharacterControls.Move.canceled += onMovementInput;

    }

    // Update is called once per frame
    void Update()
    {
        _characterController.Move(_currentMovement * Time.deltaTime);
    }

    private void OnEnable()
    {
        _playerInput.CharacterControls.Enable();
    }
    private void OnDisable()
    {
        _playerInput.CharacterControls.Disable();
    }

    private void onMovementInput(InputAction.CallbackContext context)
    {
        _currentMovementInput = context.ReadValue<Vector2>();
        _currentMovement.x = _currentMovementInput.x;
    }
}
