using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBoss : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GunProjectile"))
        {
            gameObject.SetActive(false);
        }
    }
}
