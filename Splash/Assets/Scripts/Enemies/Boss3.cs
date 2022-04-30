using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3 : MonoBehaviour
{
    public float xSpeed, ySpeed;
    private float xStart, xEnd, yStart, yEnd, xDirection, yDirection, xDistance, yDistance;
    public int health = 50;
    [SerializeField] AudioClip bossDamageSound;
    [SerializeField] AudioClip bubbleDamageSound;

    public GameObject squishPoint;

    private void OnEnable()
    {
        xStart = gameObject.transform.position.x;
        yStart = gameObject.transform.position.y;
        xEnd = xStart + 5;
        yEnd = yStart + 2;
    }
    IEnumerator WaitTime()
    {
        //yield on a new YieldInstruction that waits for .05 seconds.
        yield return new WaitForSeconds(.05f);

        squishPoint.GetComponent<SpriteRenderer>().color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        // Sets enemy movement speed
        gameObject.transform.position = new Vector2(transform.position.x + xSpeed * xDirection / 100, transform.position.y + ySpeed * yDirection / 100);

        // Controls direction of movement
        xDistance = gameObject.transform.position.x;
        yDistance = gameObject.transform.position.y;

        // Move Right
        if (xDistance <= xStart)
        {
            xDirection = .1f;
        }
        // Move Left
        if (xDistance >= xEnd)
        {
            xDirection = -.1f;
        }
        // Move Up
        if (yDistance <= yStart)
        {
            yDirection = .1f;
        }
        // Move Down
        if (yDistance >= yEnd)
        {
            yDirection = -.1f;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("GunProjectile"))
        {
            health--;

            squishPoint.GetComponent<SpriteRenderer>().color = Color.cyan;
            FindObjectOfType<AudioManager>().PlaySound(bubbleDamageSound);
            FindObjectOfType<AudioManager>().PlaySound(bossDamageSound);
            StartCoroutine(WaitTime());

            if (health == 0)
            {
                transform.gameObject.SetActive(false);
            }
        }
    }

}
