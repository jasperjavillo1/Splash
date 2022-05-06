using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class ChaserHealth : MonoBehaviour
{
    [SerializeField] AudioClip chaserDamageSound;
    public Transform regenPrefab;
    public Transform spawnPoint;
    [SerializeField] [Range(0, 100)] int _healthDropProbability;

    void DropRegen()
    {
        Instantiate(regenPrefab, spawnPoint.position, spawnPoint.rotation);
    }
    IEnumerator WaitTime()
    {
        //yield on a new YieldInstruction that waits for .05 seconds.
        yield return new WaitForSeconds(.05f);

        transform.parent.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    }

    public int health = 3;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GunProjectile"))
        {
            health--;
            transform.parent.gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
            FindObjectOfType<AudioManager>().PlaySound(chaserDamageSound);
            StartCoroutine(WaitTime());

            if (health == 0)
            {
                int probaility = new Random().Next(0, 100 + 1);
                if (probaility <= _healthDropProbability)
                {
                    DropRegen();
                }
                Destroy(transform.parent.gameObject);
            }
        }

    }
}
