using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Squish : MonoBehaviour
{
    public GameObject squishPoint;
    public Boss1 boss1;

    IEnumerator WaitTime()
    {
        //yield on a new YieldInstruction that waits for .5 seconds.
        yield return new WaitForSeconds(.25f);

        squishPoint.GetComponent<SpriteRenderer>().color = Color.yellow;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("GunProjectile"))
        {
            boss1.health--;
            squishPoint.GetComponent<SpriteRenderer>().color = Color.cyan;
            StartCoroutine(WaitTime());

            if (boss1.health == 0)
            {
                transform.parent.gameObject.SetActive(false);

            }
        }
    }
}