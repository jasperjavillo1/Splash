using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedGoombaMovement : MonoBehaviour
{
    public float xSpeed = 1, xDistance = 5;
    public float xDist, xPos, xDirection;
    public bool moveLeft, exitBlink = false;
    private GameObject player;

    private void Start()
    {
        xPos = gameObject.transform.position.x;

    }

    // Update is called once per frame
    void Update()
    {
        // Sets enemy movement speed
        gameObject.transform.position = new Vector2(transform.position.x + (xSpeed * xDirection / 500), transform.position.y);

        // Move Right
        if (moveLeft == false)
        {
            xDirection = 1f;
        }
        // Move Left
        else
        {
            xDirection = -1f;
        }

        if (gameObject.transform.position.x < xPos - xDistance)
        {
            Destroy(gameObject);
        }

    }
    IEnumerator WaitTime()
    {
        while (exitBlink == false)
        {
            //yield on a new YieldInstruction that waits for .1 seconds.
            yield return new WaitForSeconds(.1f);

            player.GetComponent<SpriteRenderer>().color = Color.white;

            yield return new WaitForSeconds(.1f);

            player.GetComponent<SpriteRenderer>().color = Color.red;

            yield return new WaitForSeconds(.1f);

            player.GetComponent<SpriteRenderer>().color = Color.white;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject;
            player.GetComponent<SpriteRenderer>().color = Color.red;
            StartCoroutine(WaitTime());
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<SpriteRenderer>().color = Color.white;
            exitBlink = true;
            StopCoroutine(WaitTime());
        }

    }
}
