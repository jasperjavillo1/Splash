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
    private PlayerHealth _playerHealth;
    private Animator _animator;
    private string _currentAnimatorState;

    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip impactSound;
    [SerializeField] AudioClip Checkpoint;

    bool grounded;
    public int keyCount = 0;

    //player input value variables
    private Vector2 _currentMovementInput;
    private Vector2 _currentMovement;
    private Vector2 _currentWalkMovement;
    private Vector2 _currentRunMovement;
    private Vector2 _appliedMovement;
    private float _currentMaxSpeed;
    private bool _isMovementPressed;
    private bool _isRunPressed;

    //jump variables
    private bool _isJumpPressed;

    //constants
    private float _walkMultipler = 5f;
    private float _runMultiplier = 10f;
    private int _zero = 0;
    [SerializeField]
    private Vector2 _jumpVector = Vector2.up * 1f;

    //state machine variables
    private PlayerMovementBaseState _currentState;
    private PlayerStateFactory _states;

    //getters and setters
    //reference vairables getters and setters
    public PlayerInput PlayerInput { get { return _playerInput; } set { _playerInput = value; } }
    public Rigidbody2D Rigidbody2D { get { return _rigidbody2D; } }
    public CapsuleCollider2D CapsuleCollider2D { get { return _capsuleCollider2D; } }
    public PlayerHealth PlayerHealth { get { return _playerHealth; } }
    public Animator Animator { get { return _animator; } }

    //player input value getters and setters
    public Vector2 CurrentMovementInput { get { return _currentMovementInput; } set { _currentMovementInput = value; } }
    public Vector2 CurrentMovement { get { return _currentMovement; } set { _currentMovement = value; } }
    public Vector2 CurrentWalkMovement { get { return _currentWalkMovement; } set { _currentWalkMovement = value; } }
    public Vector2 CurrentRunMovement { get { return _currentRunMovement; } set { _currentRunMovement = value; } }
    public Vector2 AppliedMovement { get { return _appliedMovement; } set { _appliedMovement = value; } }
    public float CurrentMaxSpeed { get { return _currentMaxSpeed; } set { _currentMaxSpeed = value; } }
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
        _playerHealth = GetComponent<PlayerHealth>();
        _animator = GetComponent<Animator>();
        _currentAnimatorState = "Player_Idle";

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
        _handleMovement();
        _MovementAnimation();
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
        _currentWalkMovement.x = _currentMovementInput.x * _walkMultipler;
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

        if (grounded)
        {
            // Play jump sound
            FindObjectOfType<AudioManager>().playSound(jumpSound);
            grounded = false;
        }
    }

    public bool IsGrounded()
    {
        //Method for determining if player is grounded.
        float halfY = _capsuleCollider2D.size.y / 2;
        Vector2 raycastOriginDown = _rigidbody2D.position - new Vector2(0, (halfY + 0.1f));
        return  Physics2D.Raycast(raycastOriginDown, Vector2.down, 0.1f);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        // Play impact sound
        if (col.gameObject.CompareTag("Ground") || col.gameObject.CompareTag("Untagged"))
        {
            grounded = true;
            FindObjectOfType<AudioManager>().playSound(impactSound);
        }

        // If destructor portion of enemy hit, destroy enemy
        if (col.gameObject.CompareTag("Squish"))
        {
            col.transform.parent.gameObject.SetActive(false);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerCheckpoint"))
        {
            FindObjectOfType<AudioManager>().playSound(Checkpoint);
        }

        if (other.CompareTag("Key"))
        {
            keyCount++;
            other.gameObject.SetActive(false);
        }
    }

    public void _ChangeAnimationState(string newState)
    {
        if (_currentAnimatorState == newState) return;
        _animator.Play(newState);
        _currentAnimatorState = newState;
    }

    private void _MovementAnimation()
    {
        if(_currentState.GetType().Equals(typeof(PlayerGroundedState)))
        {
            if(_appliedMovement.x != _zero)
            {
                _ChangeAnimationState("Player_moving");
            }
            else
            {
                _ChangeAnimationState("Player_idle");
            }
        }
    }

    private void _handleMovement()
    {
        _appliedMovement.x = _currentMovement.x;
        if (Mathf.Abs(_rigidbody2D.velocity.x) <= _currentMaxSpeed)
        {
            _rigidbody2D.AddForce(_appliedMovement, ForceMode2D.Impulse);
        }
    }

    //call when changing between Idle,Walk, and Run for snappy deceleration.
    public void ResetVelocity()
    {
        Vector2 currentVelocity = _rigidbody2D.velocity;
        if(Mathf.Abs(currentVelocity.x) > _currentMaxSpeed)
        {
            if (currentVelocity.x > 0)
            {
                currentVelocity.x = _currentMaxSpeed;
            }
            else if(currentVelocity.x < 0)
            {
                currentVelocity.x = -_currentMaxSpeed;
            }
            else
            {
                currentVelocity.x = 0;
            }
        }
        _rigidbody2D.velocity = currentVelocity;
    }
}