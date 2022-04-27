using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlink : MonoBehaviour
{
    private GameObject player;
    IEnumerator WaitTime()
    {
        //yield on a new YieldInstruction that waits for .25 seconds.
        yield return new WaitForSeconds(.15f);

        player.GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject;
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            StartCoroutine(WaitTime());
        }
    }
}
