using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //parameters
    [SerializeField] float _health;

    IEnumerator Blink()
    {
        yield return new WaitForSeconds(.1f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void Update() 
    {
        if(_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("GunProjectile"))
        {
            _health-= other.gameObject.GetComponent<GunProjectile>().Damage;
            Destroy(other.gameObject);
            GetComponent<SpriteRenderer>().color = Color.red;
            StartCoroutine(Blink());

        }    
    }
}
