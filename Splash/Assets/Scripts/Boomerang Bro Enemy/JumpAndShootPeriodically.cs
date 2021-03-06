using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAndShootPeriodically : MonoBehaviour
{   
    //parameters
    [SerializeField] float _jumpInterval;
    [SerializeField] float _jumpPower;

    [SerializeField] GameObject _enemyProjectile;

    //cache
    Rigidbody2D _rigidbody;

    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        StartCoroutine(Jump());
    }

    private IEnumerator Jump()
    {
        while(_jumpInterval > 0f)
        {
            Instantiate(_enemyProjectile, transform.position, Quaternion.identity);
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpPower * Time.deltaTime);
            yield return new WaitForSeconds(_jumpInterval);
        }
    }

    private void Update() 
    {
        FacePlayer();    
    }

    private void FacePlayer()
    {
        if(GameObject.FindWithTag("Player").transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.y);
        }
        else
        {
            transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.y);
        }
    }
}
