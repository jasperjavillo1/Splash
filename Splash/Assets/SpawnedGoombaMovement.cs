using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedGoombaMovement : MonoBehaviour
{
    public float xSpeed, xDistance;
    public float xDist, xPos, xDirection;
    public bool moveLeft;
    private void Start()
    {
        xPos = gameObject.transform.position.x;

    }

    // Update is called once per frame
    void Update()
    {
        // Sets enemy movement speed
        gameObject.transform.position = new Vector2(transform.position.x + (xSpeed * xDirection / 500), transform.position.y);

        // Controls direction of movement
        //xDist = gameObject.transform.position.x;

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

        if (gameObject.transform.position.x == xPos - 2)
        {
            Destroy(gameObject);
        }

    }
}
