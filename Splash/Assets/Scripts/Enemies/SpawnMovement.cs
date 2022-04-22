using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMovement : MonoBehaviour
{
    public float xSpeed;
    private float xDirection;
    public bool moveRight = false;
    public float destroyTime = 10f;
    // Update is called once per frame
    void Update()
    {
        if (destroyTime > 0f)
        {
            destroyTime -= Time.deltaTime;
        } else 
        {
            gameObject.SetActive(false);
        }

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
