using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunProjectile : MonoBehaviour
{
    //parameters
    [SerializeField] float _speed = 200;
    [SerializeField] public float Damage;
    [SerializeField] AudioClip bubblePopSound;
    [SerializeField] float _shootCost = 50;

    //state
    Vector2 _projectileDirection;

    //cache
    Rigidbody2D _rigidbody;
    PlayerHealth _playerHealth;
    
    private void Start() 
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerHealth = FindObjectOfType<PlayerHealth>();

        if(!_playerHealth.IsInBossFight)
        {
            _playerHealth.DecreaseHealth(_shootCost);
        }

        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

        Vector2 projectilePosition = new Vector2(transform.position.x, transform.position.y);

        Vector2 projectileDirection = (mousePosition - projectilePosition);
        float projectileDirectionMagnitude = Mathf.Sqrt(projectileDirection.x * projectileDirection.x + projectileDirection.y * projectileDirection.y);
        Vector2 normalizedProjectileDirection = projectileDirection / projectileDirectionMagnitude;

        _projectileDirection = normalizedProjectileDirection;

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
            FindObjectOfType<AudioManager>().PlaySound(bubblePopSound);
            Destroy(gameObject);
        }    
    }

}
