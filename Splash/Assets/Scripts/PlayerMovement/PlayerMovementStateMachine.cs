using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//Context of the Player Movement State Machine
public class PlayerMovementStateMachine : MonoBehaviour
{
    //member variables
    //reference variables
    private SpriteRenderer _spriteRenderer;
    private PlayerInput _playerInput;
    private Rigidbody2D _rigidbody2D;
    private CircleCollider2D _circleCollider2D;
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
    private bool _jumpAvailable = true;
    [SerializeField] private float _maxJumpTime = 1;
    [SerializeField] private LayerMask _groundLayer;

    //constants
    [SerializeField]private float _walkMultipler = 5f;
    [SerializeField]private float _runMultiplier = 10f;
    private int _zero = 0;
    [SerializeField] private Vector2 _jumpVector = new Vector2(0,7);
    [SerializeField] private float _maxWalkSpeed = 3f;
    [SerializeField] private float _maxRunSpeed = 6f;

    //state machine variables
    private PlayerMovementBaseState _currentState;
    private PlayerStateFactory _states;

    //getters and setters
    //reference vairables getters and setters
    public SpriteRenderer SpriteRenderer { get { return _spriteRenderer; } }
    public PlayerInput PlayerInput { get { return _playerInput; } set { _playerInput = value; } }
    public Rigidbody2D Rigidbody2D { get { return _rigidbody2D; } }
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
    public bool JumpAvailable { get { return _jumpAvailable; } set { _jumpAvailable = value; } }
    public float MaxJumpTime { get { return _maxJumpTime; } }

    //constants getters and setters
    public float RunMultiplier { get { return _runMultiplier; } }
    public int Zero { get { return _zero; } }
    public Vector2 JumpVector { get { return _jumpVector; } }
    public float MaxWalkSpeed { get { return _maxWalkSpeed; } }
    public float MaxRunSpeed { get { return _maxRunSpeed; } }

    //state machine getters and setters
    public PlayerMovementBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }
    public PlayerStateFactory States { get { return _states; } }

    void Awake()
    {
        //set reference variables
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerInput = new PlayerInput();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _circleCollider2D = GetComponent<CircleCollider2D>();
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
        _currentState = _states.Falling();
        _currentState.EnterState();
    }

    // Update is called once per frame
    void Update()
    {
        _currentState.UpdateStates();
        _MovementAnimation();
    }

    private void FixedUpdate()
    {
        _handleMovement();
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
            FindObjectOfType<AudioManager>().PlaySound(jumpSound);
            grounded = false;
        }
    }

    public bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector3 direction = Vector3.down;
        float distance = 0.8f;
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, _groundLayer);
        if (hit.collider == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        // Play impact sound
        if (col.gameObject.CompareTag("Ground") || col.gameObject.CompareTag("Untagged"))
        {
            grounded = true;
            //_jumpAvailable = true;
            FindObjectOfType<AudioManager>().PlaySound(impactSound);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerCheckpoint"))
        {
            FindObjectOfType<AudioManager>().PlaySound(Checkpoint);
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
        if(_appliedMovement.x < _zero)
        {
            _spriteRenderer.flipX = false;
        }
        else if(_appliedMovement.x > _zero)
        {
            _spriteRenderer.flipX = true;
        }
    }

    private void _handleMovement()
    {
        _appliedMovement = _currentMovement;
        if(Mathf.Abs(_rigidbody2D.velocity.x) < _currentMaxSpeed)
        {
            _rigidbody2D.AddForce(_appliedMovement, ForceMode2D.Impulse);
        }
        if(_rigidbody2D.velocity.x > _currentMaxSpeed && _rigidbody2D.velocity.x >= 0)
        {
            _rigidbody2D.velocity = new Vector2(_currentMaxSpeed, _rigidbody2D.velocity.y);
        }
        if(Mathf.Abs(_rigidbody2D.velocity.x) > _currentMaxSpeed && _rigidbody2D.velocity.x <= 0)
        {
            _rigidbody2D.velocity = new Vector2(-_currentMaxSpeed, _rigidbody2D.velocity.y);
        }
    }

    public void ResetVelocity()
    {
        Vector2 currentVelocity = _rigidbody2D.velocity;
        currentVelocity.x = 0;
        _rigidbody2D.velocity = currentVelocity;
    }
}