using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject enemySpawnPoint;
    public bool start = false, stop = false;

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(.1f);
        if (start)
        {
            GetComponent<SpriteRenderer>().color = Color.green;

        }
        if (stop)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (start)
            {
                enemySpawnPoint.SetActive(true);
                GetComponent<SpriteRenderer>().color = Color.black;
                StartCoroutine(WaitTime());

            }
            if (stop)
            {
                enemySpawnPoint.SetActive(false);
                GetComponent<SpriteRenderer>().color = Color.black;
                StartCoroutine(WaitTime());
            }
        }
    }

}
