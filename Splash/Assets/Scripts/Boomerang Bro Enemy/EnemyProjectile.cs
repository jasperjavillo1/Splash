using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    //parameters
    [SerializeField] float _speed;
    public float Damage;


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
        Vector3 rawProjectileDirection = (GameObject.FindWithTag("Player").transform.position - transform.position).normalized;
        _projectileDirection = new Vector3(rawProjectileDirection.x, 0f, 0f);
    }

    private void FixedUpdate() 
    {
        _rigidbody.velocity = _projectileDirection * _speed * Time.deltaTime;
    }
}
