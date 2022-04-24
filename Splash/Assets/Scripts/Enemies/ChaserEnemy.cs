using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserEnemy : MonoBehaviour
{
    public GameObject player;
    public float speed, distanceBetween;
    private float distance;
    public int health = 3;
    // Update is called once per frame
    void Update()
    {
        // Compares distance and direction between player and enemy
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Moves toward player when within specified distance
        if (distance < distanceBetween)
        {
            transform.SetPositionAndRotation(Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime), Quaternion.Euler(Vector3.forward * angle));
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GunProjectile"))
        {
            health--;
            if (health == 0)
            {
                transform.gameObject.SetActive(false);

            }
        }
    }
}
