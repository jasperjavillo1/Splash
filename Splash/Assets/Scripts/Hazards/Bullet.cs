using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    Vector2 target;
    float speed;
    bool moving = false;
    Hazard parent;
    private GameObject player;

    IEnumerator WaitTime()
    {
        //yield on a new YieldInstruction that waits for .25 seconds.
        yield return new WaitForSeconds(.05f);

        player.GetComponent<SpriteRenderer>().color = Color.white;
        Destroy(gameObject);

    }

    private void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.CompareTag("Player")) {
            parent.dealDamageToPlayer();
            player = col.gameObject;

            if (col.gameObject.GetComponent<SpriteRenderer>().color == Color.white)
            {
                col.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                StartCoroutine(WaitTime());
            }
            else
            {
                Destroy(gameObject);
            }

        }
        if (col.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

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
