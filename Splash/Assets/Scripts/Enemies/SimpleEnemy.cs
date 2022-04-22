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
        // Sets enemy movement speed
        gameObject.transform.position = new Vector2(transform.position.x + (xSpeed * xDirection /100), transform.position.y + (ySpeed * yDirection));

        // Controls direction of movement
        xDistance = gameObject.transform.position.x;
        yDistance = gameObject.transform.position.y;
        
        // Move Right
        if (xDistance <= xMin)
        {
            xDirection = .1f;
        }
        // Move Left
        if (xDistance >= xMax)
        {
            xDirection = -.1f;
        }
        // Move Up
        if (yDistance <= yMin)
        {
            yDirection = .1f;
        }
        // Move Down
        if (yDistance >= yMax)
        {
            yDirection = -.1f;
        }
    }
}
