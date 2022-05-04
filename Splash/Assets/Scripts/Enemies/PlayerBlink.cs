using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlink : MonoBehaviour
{
    [SerializeField] AudioClip playerHurtSound;

    IEnumerator WaitTime()
    {
        //yield on a new YieldInstruction that waits for .1 seconds.
        yield return new WaitForSeconds(.1f);

        GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyProjectile"))
        {
            FindObjectOfType<AudioManager>().PlaySound(playerHurtSound);
            GetComponent<SpriteRenderer>().color = Color.red;
            StartCoroutine(WaitTime());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            FindObjectOfType<AudioManager>().PlaySound(playerHurtSound);
            GetComponent<SpriteRenderer>().color = Color.red;
            StartCoroutine(WaitTime());
        }
    }
}
