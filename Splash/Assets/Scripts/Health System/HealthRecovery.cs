
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRecovery : MonoBehaviour
{
    [SerializeField] AudioClip regenSound;
    [SerializeField] float healthIncrementAmount;
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerHealth PH = other.GetComponent<PlayerHealth>();

            PH.ResetHealth();
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.CompareTag("Player")) {
            FindObjectOfType<AudioManager>().PlaySound(regenSound);
        }
    }
}
