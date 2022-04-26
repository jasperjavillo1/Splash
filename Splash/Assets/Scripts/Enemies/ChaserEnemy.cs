using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserEnemy : MonoBehaviour
{
    public GameObject player;
    public float speed, distanceBetween;
    private float distance, xStart, yStart;
    //private Vector3 startPos;
    //public GameObject startPosition;

    /*private void Start()
    {
        xStart = gameObject.transform.position.x;
        yStart = gameObject.transform.position.y;
        startPosition.transform.position = new Vector3(xStart, yStart, 0);
    }*/

    // Update is called once per frame
    void Update()
    {
        // Compares distance and direction between player and enemy
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Moves toward player when within specified distance
        if (distance <= distanceBetween)
        {
            transform.SetPositionAndRotation(Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime), Quaternion.Euler(Vector3.forward * angle));
        }
        /*if (distance > distanceBetween)
        {
            //startPos.x = xStart;
            //startPos.y = yStart;
            //position = gameObject.transform.position;
            transform.SetPositionAndRotation(Vector2.MoveTowards(this.transform.position, startPosition.transform.position, speed * Time.deltaTime), Quaternion.Euler(Vector3.forward * angle));
        }*/
    }

}
