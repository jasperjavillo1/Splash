using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserHealth : MonoBehaviour
{
    IEnumerator WaitTime()
    {
        //yield on a new YieldInstruction that waits for .25 seconds.
        yield return new WaitForSeconds(.25f);

        transform.parent.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    }

    public int health = 3;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GunProjectile"))
        {
            health--;
            transform.parent.gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
            StartCoroutine(WaitTime());

            if (health == 0)
            {
                transform.parent.gameObject.SetActive(false);

            }
        }

    }
}
