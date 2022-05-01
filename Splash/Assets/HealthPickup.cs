
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
        if (col.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().PlaySound(regenSound);
            PlayerHealth PH = col.gameObject.GetComponent<PlayerHealth>();
            PH.IncreaseHealth(healthIncreaseAmount);
            Destroy(gameObject);
        }
    }
}
