using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    Vector2 target;
    float speed;
    float dmg;
    bool moving = false;

    private void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag == "Player")
            FindObjectOfType<PlayerHealth>().DecreaseHealth(dmg);

        Destroy(gameObject);
    }

    public void moveToTarget(Vector2 t, float s, float d) {
        target = t;
        speed = s;
        dmg = d;
        moving = true;
        Destroy(gameObject, 5f);
    }

    private void Update() {
        if(moving)
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
