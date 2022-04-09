using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//Context of the Player Movement State Machine
public class PlayerMovementStateMachine : MonoBehaviour
{
    //member variables
    //reference variables
    private PlayerInput _playerInput;
    private Rigidbody2D _rigidbody2D;
    private CapsuleCollider2D _capsuleCollider2D;

    //player input value variables
    private Vector2 _currentMovementInput;
    private Vector2 _currentMovement;
    private Vector2 _currentRunMovement;
    private Vector2 _appliedMovement;
    private bool _isMovementPressed;
    private bool _isRunPressed;

    //jump variables
    private bool _isJumpPressed;

    //constants
    private float _runMultiplier = 3.0f;
    private int _zero = 0;
    private Vector2 _jumpVector = Vector2.up * 5.0f;

    //state machine variables
    private PlayerMovementBaseState _currentState;
    private PlayerStateFactory _states;

    //getters and setters
    //reference vairables getters and setters
    public PlayerInput PlayerInput { get { return _playerInput; } set { _playerInput = value; } }
    public Rigidbody2D Rigidbody2D { get { return _rigidbody2D; } }
    public CapsuleCollider2D CapsuleCollider2D { get { return _capsuleCollider2D; } }

    //player input value getters and setters
    public Vector2 CurrentMovementInput { get { return _currentMovementInput; } set { _currentMovementInput = value; } }
    public Vector2 CurrentMovement { get { return _currentMovement; } set { _currentMovement = value; } }
    public Vector2 CurrentRunMovement { get { return _currentRunMovement; } set { _currentRunMovement = value; } }
    public Vector2 AppliedMovement { get { return _appliedMovement; } set { _appliedMovement = value; } }
    public bool IsMovementPressed { get { return _isMovementPressed; } set { _isMovementPressed = value; } }
    public bool IsRunPressed { get { return _isRunPressed; } set { _isRunPressed = value; } }

    //jump getters and setters
    public bool IsJumpPressed { get { return _isJumpPressed; } set { _isJumpPressed = value; } }

    //constants getters and setters
    public float RunMultiplier { get { return _runMultiplier; } }
    public int Zero { get { return _zero; } }
    public Vector2 JumpVector { get { return _jumpVector; } }


    //state machine getters and setters
    public PlayerMovementBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }
    public PlayerStateFactory States { get { return _states; } }



    void Awake()
    {
        //set reference variables
        _playerInput = new PlayerInput();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _capsuleCollider2D = GetComponent<CapsuleCollider2D>();

        //set player input callbacks
        _playerInput.CharacterControls.Move.started += _onMovementInput;
        _playerInput.CharacterControls.Move.canceled += _onMovementInput;
        _playerInput.CharacterControls.Run.started += _onRun;
        _playerInput.CharacterControls.Run.canceled += _onRun;
        _playerInput.CharacterControls.Jump.started += _onJump;
        _playerInput.CharacterControls.Jump.canceled += _onJump;

        //set up state
        _states = new PlayerStateFactory(this);
        _currentState = _states.Grounded();
        _currentState.EnterState();
    }

    // Update is called once per frame
    void Update()
    {
        _currentState.UpdateStates();
        //_rigidbody2D.
        transform.Translate(_appliedMovement);
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
        _currentRunMovement.x = _currentMovementInput.x * _runMultiplier;
        _isMovementPressed = _currentMovementInput.x != 0;
    }

    private void _onRun(InputAction.CallbackContext context)
    {
        _isRunPressed = context.ReadValueAsButton();
    }
    private void _onJump(InputAction.CallbackContext context)
    {
        _isJumpPressed = context.ReadValueAsButton();
    }

    public bool IsGrounded()
    {
        //Method for determining if player is grounded.
        return Physics2D.Raycast((_rigidbody2D.transform.position - new Vector3(0,0.6f,0)), Vector2.down, 0.1f);
    }
}
