using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class EnemyHealth : MonoBehaviour
{
    //parameters
    [SerializeField] float _health;
    [SerializeField] AudioClip broDamageSound;
    [SerializeField] GameObject _healthPickup;
    [SerializeField] [Range(0,100)] int _healthDropProbability;

    IEnumerator Blink()
    {
        yield return new WaitForSeconds(.1f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void Update() 
    {
        if(_health <= 0)
        {
            int probaility = new Random().Next(0, 100 + 1);
            if (probaility <= _healthDropProbability)
            {
                Instantiate(_healthPickup, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("GunProjectile"))
        {
            _health-= other.gameObject.GetComponent<GunProjectile>().Damage;
            Destroy(other.gameObject);
            FindObjectOfType<AudioManager>().PlaySound(broDamageSound);
            GetComponent<SpriteRenderer>().color = Color.blue;
            StartCoroutine(Blink());

        }    
    }
}
