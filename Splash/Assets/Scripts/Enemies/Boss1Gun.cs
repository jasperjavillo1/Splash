using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Gun : MonoBehaviour
{
    public GameObject squishPoint;
    [SerializeField] AudioClip bossDamageSound;
    public Boss1 boss1;
    IEnumerator WaitTime()
    {
        //yield on a new YieldInstruction that waits for .25 seconds.
        yield return new WaitForSeconds(.25f);

        squishPoint.GetComponent<SpriteRenderer>().color = Color.red;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GunProjectile"))
        {
            boss1.health--;
            squishPoint.GetComponent<SpriteRenderer>().color = Color.cyan;
            FindObjectOfType<AudioManager>().playSound(bossDamageSound);
            StartCoroutine(WaitTime());

            if (boss1.health == 0)
            {
                transform.parent.gameObject.SetActive(false);

            }
        }
    }
}
