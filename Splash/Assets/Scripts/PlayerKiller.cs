using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKiller : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            PlayerHealth playerHealth = GameObject.FindObjectOfType<PlayerHealth>();
            {
                playerHealth.DecreaseHealth(playerHealth.GetCurrentHealth() + 1);
            }
        }    
    }
}
