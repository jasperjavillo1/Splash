using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserHealth : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int health = 3;

    SpriteRenderer render;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GunProjectile"))
        {
            health--;
            render = transform.parent.GetComponent<SpriteRenderer>();

            if (health <= 6)
            {
                render.color = Color.magenta;
            }
            if (health <= 3)
            {
                render.color = Color.blue;
            }
            if (health == 0)
            {
                transform.parent.gameObject.SetActive(false);

            }
        }
    }
}
