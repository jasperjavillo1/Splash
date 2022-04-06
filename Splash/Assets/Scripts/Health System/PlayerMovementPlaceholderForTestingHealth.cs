using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementPlaceholderForTestingHealth : MonoBehaviour
{
    //parameters
    [SerializeField] private PlayerHealth _health;
    [SerializeField] private float _healthDecreaseAmount;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpPower;

    //state
    bool _hasPressedJump;

    //cache
    Rigidbody2D _rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        DecreaseHealth();
    }

    void FixedUpdate()
    {
        HorizontalMovement();
        Jump();
    }

    private void Jump()
    {
        if (_rigidbody.IsTouchingLayers(LayerMask.GetMask("Ground")) && Input.GetAxis("Jump") > Mathf.Epsilon)
        {
            float jump = Input.GetAxis("Jump") * Time.deltaTime * _jumpPower;
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jump);
        }
    }

    private void HorizontalMovement()
    {
        float speedX = Input.GetAxis("Horizontal") * Time.deltaTime * _speed;
        _rigidbody.velocity = new Vector2(speedX, _rigidbody.velocity.y);
    }
    
    private void DecreaseHealth()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > Mathf.Epsilon || Mathf.Abs(Input.GetAxis("Jump")) > Mathf.Epsilon)
        {
            _health.DecreaseHealth(_healthDecreaseAmount);
        }
    }
}
