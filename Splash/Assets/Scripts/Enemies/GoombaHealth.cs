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

        transform.parent.gameObject.GetComponent<SpriteRenderer>().color = Color.white;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<AudioManager>().playSound(goombaDamageSound);

        if (collision.gameObject.CompareTag("GunProjectile"))
        {
            health--;
            transform.parent.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            StartCoroutine(WaitTime());
            if (health == 0)
            {
                transform.parent.gameObject.SetActive(false);

            }

        }
        if (collision.gameObject.CompareTag("Player"))
        {
            transform.parent.gameObject.SetActive(false);
        }
    }

}
