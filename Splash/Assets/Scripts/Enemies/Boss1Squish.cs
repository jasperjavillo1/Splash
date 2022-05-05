using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Squish : MonoBehaviour
{
    public GameObject squishPoint;
    public Boss1 boss1;
    [SerializeField] AudioClip bossDamageSound;
    IEnumerator WaitTime()
    {
        boss1.health--;
        //yield on a new YieldInstruction that waits for .1 seconds.
        yield return new WaitForSeconds(.1f);

        squishPoint.GetComponent<SpriteRenderer>().color = Color.red;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("GunProjectile"))
        {
            squishPoint.GetComponent<SpriteRenderer>().color = Color.cyan;
            FindObjectOfType<AudioManager>().PlaySound(bossDamageSound);
            StartCoroutine(WaitTime());

            if (boss1.health == 0)
            {
                //transform.parent.gameObject.SetActive(false);

            }
        }
    }
}
