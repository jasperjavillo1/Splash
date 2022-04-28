using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject enemySpawnPoint;
    public bool start = false, stop = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (start)
            {
                enemySpawnPoint.SetActive(true);

            }
            if (stop)
            {
                enemySpawnPoint.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (start)
            {
                enemySpawnPoint.SetActive(true);

            }
            if (stop)
            {
                enemySpawnPoint.SetActive(false);
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
