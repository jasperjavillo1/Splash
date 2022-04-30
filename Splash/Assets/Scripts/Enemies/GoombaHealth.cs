using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaHealth : MonoBehaviour
{
    [SerializeField] AudioClip goombaDamageSound;
    public int health = 10;

    IEnumerator WaitTime()
    {
        //yield on a new YieldInstruction that waits for .05 seconds.
        yield return new WaitForSeconds(.05f);

        transform.parent.GetComponent<SpriteRenderer>().color = Color.white;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("GunProjectile"))
        {
            health--;
            FindObjectOfType<AudioManager>().PlaySound(goombaDamageSound);
            transform.parent.GetComponent<SpriteRenderer>().color = Color.red;
            StartCoroutine(WaitTime());
            if (health == 0)
            {
                Destroy(transform.parent.gameObject);
            }

        }
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().PlaySound(goombaDamageSound);
            Destroy(transform.parent.gameObject);
        }
    }

}
