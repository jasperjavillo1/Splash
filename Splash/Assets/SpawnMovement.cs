using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMovement : MonoBehaviour
{
    public float xSpeed;
    private float xDirection;
    public bool moveRight = false;

    // Update is called once per frame
    void Update()
    {
        // Sets enemy movement speed
        gameObject.transform.position = new Vector2(transform.position.x + (xSpeed * xDirection / 100), transform.position.y);

        // Move Right
        if (moveRight == true)
        {
            xDirection = .1f;
        }
        // Move Left
        else
        {
            xDirection = -.1f;
        }

    }
}
