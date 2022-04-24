using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Gun : MonoBehaviour
{
    public Boss1 boss1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GunProjectile"))
        {
            boss1.health--;
            if (boss1.health == 0)
            {
                transform.parent.gameObject.SetActive(false);

            }
        }
    }
}
