
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] AudioClip regenSound;
    [SerializeField] float healthIncreaseAmount = 500;

    private void OnEnable()
    {
        Destroy(gameObject, 5);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().PlaySound(regenSound);
            PlayerHealth PH = col.gameObject.GetComponent<PlayerHealth>();
            if (PH.GetCurrentHealth() < PH.GetInitialHealth())
            {
                PH.IncreaseHealth(healthIncreaseAmount);
            }
            Destroy(gameObject);

        }
    }
}
