using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedHealthRecovery : MonoBehaviour
{
    [SerializeField] AudioClip regenSound;
    [SerializeField] float healthIncrementAmount;
    public PlayerMovementStateMachine pmsm;
    bool key;
    bool sound = false;

    public void Update()
    {
        // Determines if player has any "keys" to cleanse fountains
        if (pmsm.keyCount > 0)
        {
            key = true;
        }
        else
        {
            key = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        // If player has a key and makes contact with the fountain
        if (other.CompareTag("Player") && key == true)
        {
            // Changes fountain animation
            GetComponent<Animator>().Play("CleansedFountain");

            // Enables and plays initial regen sound
            if (sound == false)
            {
                FindObjectOfType<AudioManager>().PlaySound(regenSound);
            }
            sound = true;

            // Performs health regen
            PlayerHealth PH = other.GetComponent<PlayerHealth>();        
            PH.ResetHealth();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // Plays health regen sound
        if (col.CompareTag("Player") && sound == true)
        {
            FindObjectOfType<AudioManager>().PlaySound(regenSound);
        }
    }
}
