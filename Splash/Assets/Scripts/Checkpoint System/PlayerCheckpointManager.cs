using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerCheckpointManager : MonoBehaviour
{
    //parameters
    [SerializeField] GameObject[] _checkpoints;
    

    public void ResetToFirstCheckpoint()
    {
        PlayerPrefs.SetInt("Current Checkpoint", 1);
    }

    private void OnEnable() 
    {
        transform.position = _checkpoints[PlayerPrefs.GetInt("Current Checkpoint") - 1;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "PlayerCheckpoint")
        {
            int checkpointNumber = Convert.ToInt32(other.name.ToCharArray().Where(Char.IsDigit));
            PlayerPrefs.SetInt("Current Checkpoint", checkpointNumber);
        }    
    }
}
