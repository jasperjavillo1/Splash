using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerCheckpointManager : MonoBehaviour
{
    //parameters
    [SerializeField] List<GameObject> _checkpoints;

    void OnEnable()
    {
        transform.position = _checkpoints[PlayerPrefs.GetInt("Current Checkpoint") - 1].transform.position;
    }


    public void SetCheckpointToFirst()
    {
    	PlayerPrefs.SetInt("Current Checkpoint", 1);
    }
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "PlayerCheckpoint")
        {
            int playerCheckpointNumber = Convert.ToInt32(new String(other.name.Where(Char.IsDigit).ToArray()));
            PlayerPrefs.SetInt("Current Checkpoint", playerCheckpointNumber);
        }    
    }
}
