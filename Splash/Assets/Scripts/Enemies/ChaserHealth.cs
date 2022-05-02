using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserHealth : MonoBehaviour
{
    [SerializeField] AudioClip chaserDamageSound;
    public Transform regenPrefab;
    public Transform spawnPoint;

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
                DropRegen();
                Destroy(transform.parent.gameObject);
            }
        }

    }
}
