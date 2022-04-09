using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRecovery : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayerHealth PH = other.GetComponent<PlayerHealth>();
            PH.ResetHealth();
        }
    }
}
