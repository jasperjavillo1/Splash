using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{
    public float speed;
    public float xMin, xMax, yMin, yMax;
    //public float yMin, yMax;

    private float xDistance, yDistance, xDirection = -.1f, yDirection = 0;


    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector2(transform.position.x + (speed * xDirection), transform.position.y + (speed * yDirection));
        xDistance = gameObject.transform.position.x;

        if (xDistance <= xMin)
        {
            xDirection = .1f;
            //yDirection = -.1f;
        }
        if (xDistance >= xMax)
        {
            xDirection = -.1f;
            //yDirection = .1f;
        }
    }
}
