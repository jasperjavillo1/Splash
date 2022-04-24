using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunProjectile : MonoBehaviour
{
    //parameters
    [SerializeField] float _speed;
    [SerializeField] public float Damage;

    //state
    Vector3 _projectileDirection;

    //cache
    Rigidbody2D _rigidbody;

    private void Awake() 
    {
        _rigidbody = GetComponent<Rigidbody2D>();    
    }

    private void Start() 
    {
        _projectileDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        Destroy(gameObject, 5f);
    }

    private void FixedUpdate() 
    {
        _rigidbody.velocity = _projectileDirection * _speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {

        if(other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Squish"))
        {
            Destroy(gameObject);
        }    
    }
}
