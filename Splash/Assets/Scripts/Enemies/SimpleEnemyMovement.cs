using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyMovement : MonoBehaviour
{
    public float xSpeed, ySpeed;
    public float xEnd, xDirection, xStart;
    private float xDistance;

    private void Start()
    {
        xStart = gameObject.transform.position.x;

    }

    // Update is called once per frame
    void Update()
    {

        // Sets enemy movement speed
        gameObject.transform.position = new Vector2(transform.position.x + (xSpeed * xDirection), transform.position.y);

        // Controls direction of movement
        xDistance = xStart + gameObject.transform.position.x;

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

    }
}
