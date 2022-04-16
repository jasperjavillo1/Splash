using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    Vector2 target;
    float speed;
    bool moving = false;
    Hazard parent;

    private void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Player") {
            parent.dealDamageToPlayer();
        }

        Destroy(gameObject);
    }

    public void moveToTarget(Hazard p, Vector2 t, float s) {
        parent = p;
        target = t;
        speed = s;
        moving = true;
        Destroy(gameObject, 5f);
    }

    private void Update() {
        if(moving)
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
