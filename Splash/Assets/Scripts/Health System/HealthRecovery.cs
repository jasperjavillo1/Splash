using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRecovery : MonoBehaviour
{
    private PlayerHealth PH;


    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            PH.ResetHealth();
        }
    }
}
