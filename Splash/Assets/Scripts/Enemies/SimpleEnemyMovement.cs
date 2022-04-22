using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyMovement : MonoBehaviour
{
    public float xSpeed, xDistance;
    private float xDist, xMin, xMax, xDirection;

    private void Start()
    {
        xMin = gameObject.transform.position.x;
        xMax = xMin + xDistance;
    }

    // Update is called once per frame
    void Update()
    {
        // Sets enemy movement speed
        gameObject.transform.position = new Vector2(transform.position.x + (xSpeed * xDirection / 100), transform.position.y);

        // Controls direction of movement
        xDist = gameObject.transform.position.x;

        // Move Right
        if (xDist <= xMin)
        {
            xDirection = .1f;
        }
        // Move Left
        if (xDist >= xMax)
        {
            xDirection = -.1f;
        }

    }
}
