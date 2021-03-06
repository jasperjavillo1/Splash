using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBoss : MonoBehaviour
{
    public int health = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GunProjectile"))
        {
            health--;
            gameObject.SetActive(false);
        }
    }
}
