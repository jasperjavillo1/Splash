using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangProjectile : MonoBehaviour
{
    //parameters
    [SerializeField] private float _force;
    public float Damage;


    //state
    private Vector3 _projectileDirection;
    private bool _hasPassedPlayer;
    int _passCount;


    //cache
    Rigidbody2D _rigidbody;

    private void Awake() 
    {
        _hasPassedPlayer = false;
        _passCount = 0;
        
        _rigidbody = GetComponent<Rigidbody2D>();    
    }

    private void Start() 
    {
        Vector3 rawProjectileDirection = (GameObject.FindWithTag("Player").transform.position - transform.position).normalized;
        _projectileDirection = new Vector3(rawProjectileDirection.x, 0f, 0f);
        Destroy(gameObject, 5f);
    }

    private void FixedUpdate() 
    {
        if(Mathf.Abs(GameObject.FindWithTag("Player").transform.position.x - transform.position.x) <= 0.125f)
        {
            _hasPassedPlayer = true;
        }
        
        if(_hasPassedPlayer)
        {
            _rigidbody.AddForce(_projectileDirection * -_force * Time.deltaTime);
        }
        else
        {
            _rigidbody.AddForce(_projectileDirection * _force * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }    
    }
}
