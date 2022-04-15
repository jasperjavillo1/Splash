using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{
    public float xSpeed, ySpeed;
    public float xMin, xMax, yMin, yMax, xDirection, yDirection;

    private float xDistance, yDistance;

    // Update is called once per frame
    void Update()
    {
        // Sets enemy movement speed and direction loop
        gameObject.transform.position = new Vector2(transform.position.x + (xSpeed * xDirection), transform.position.y + (ySpeed * yDirection));
        xDistance = gameObject.transform.position.x;
        yDistance = gameObject.transform.position.y;

        if (xDistance <= xMin)
        {
            // Move Right
            xDirection = .1f;
        }
        if (xDistance >= xMax)
        {
            // Move Left
            xDirection = -.1f;
        }

        if (yDistance <= yMin)
        {
            // Move Up
            yDirection = .1f;
        }
        if (yDistance >= yMax)
        {
            // Move Down
            yDirection = -.1f;
        }
    }
}
