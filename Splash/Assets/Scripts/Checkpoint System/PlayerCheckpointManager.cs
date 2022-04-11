using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerCheckpointManager : MonoBehaviour
{
    //parameters
    [SerializeField] GameObject[] _checkpoints;
    [SerializeField] AudioClip Checkpoint;


    public void ResetToFirstCheckpoint()
    {
        PlayerPrefs.SetInt("Current Checkpoint", 1);
    }

    private void OnEnable()
    {
        PlayerPrefs.HasKey("Current Checkpoint");
        if(PlayerPrefs.HasKey("Current Checkpoint") == true)
        {
            transform.position = _checkpoints[PlayerPrefs.GetInt("Current Checkpoint") - 1].transform.position;
        }
        //transform.position = _checkpoints[PlayerPrefs.GetInt("Current Checkpoint") - 1].transform.position;
    }
    public void Awake()
    {
        //ResetToFirstCheckpoint();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "PlayerCheckpoint")
        {
            int checkpointNumber = Convert.ToInt32(new String(other.name.Where(Char.IsDigit).ToArray()));
            PlayerPrefs.SetInt("Current Checkpoint", checkpointNumber);

        }
    }
}
