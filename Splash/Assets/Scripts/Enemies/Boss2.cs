using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour
{
    public float xSpeed, ySpeed;
    public float xStart, xEnd, yStart, yEnd;
    private float xDistance, yDistance, xDirection, yDirection;

    private void Start()
    {
        xStart = gameObject.transform.position.x;
        yStart = gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        // Sets enemy movement speed
        gameObject.transform.position = new Vector2(transform.position.x + (xSpeed * xDirection / 100), transform.position.y + (ySpeed * yDirection));

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
}
