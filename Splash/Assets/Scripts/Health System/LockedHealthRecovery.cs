using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedHealthRecovery : MonoBehaviour
{
    [SerializeField] AudioClip regenSound;
    [SerializeField] float healthIncrementAmount;
    public PlayerMovementStateMachine pmsm;
    bool key;

    public void Update()
    {
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
        if (other.tag == "Player" && key == true)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
            PlayerHealth PH = other.GetComponent<PlayerHealth>();        
            PH.ResetHealth();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && key == true)
        {
            FindObjectOfType<AudioManager>().playSound(regenSound);

        }
    }
}
