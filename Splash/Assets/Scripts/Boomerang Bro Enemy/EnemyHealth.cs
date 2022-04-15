using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //parameters
    [SerializeField] float _health;

    private void Update() 
    {
        if(_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "GunProjectile")
        {
            _health-= other.gameObject.GetComponent<GunProjectile>().Damage;
            Destroy(other.gameObject);
        }    
    }
}
