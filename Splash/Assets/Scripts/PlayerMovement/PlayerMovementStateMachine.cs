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
    private Vector3 _currentRunMovement;
    private bool _isMovementPressed;
    private bool _isRunPressed;

    //getters and setters
    public PlayerInput PlayerInput { get { return _playerInput; } set { _playerInput = value; } }
    public CharacterController CharacterController { get { return _characterController; } }

    public Vector2 CurrentMovementInput { get { return _currentMovementInput; } set { _currentMovementInput = value; } }
    public Vector3 CurrentMovement { get { return _currentMovement; } set { _currentMovement = value; } }
    public Vector3 CurrentRunMovement { get { return _currentRunMovement; } set { _currentRunMovement = value; } }
    public bool IsMovementPressed { get { return _isMovementPressed; } set { _isMovementPressed = value; } }
    public bool IsRunPressed { get { return _isRunPressed; } set { _isRunPressed = value; } }

    void Awake()
    {
        _playerInput = new PlayerInput();
        _characterController = GetComponent<CharacterController>();

        _playerInput.CharacterControls.Move.started += _onMovementInput;
        _playerInput.CharacterControls.Move.canceled += _onMovementInput;
        _playerInput.CharacterControls.Run.started += _onRun;
        _playerInput.CharacterControls.Run.canceled += _onRun;

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

    private void _onMovementInput(InputAction.CallbackContext context)
    {
        _currentMovementInput = context.ReadValue<Vector2>();
        _currentMovement.x = _currentMovementInput.x;
        _isMovementPressed = _currentMovementInput.x != 0;
    }

    private void _onRun(InputAction.CallbackContext context)
    {
        _isRunPressed = context.ReadValueAsButton();
    }
}
