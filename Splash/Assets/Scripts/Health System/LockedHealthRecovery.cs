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
    float increaseAmount;


    //cache
    [SerializeField] private PlayerLives _playerLives;
    [SerializeField] private PauseMenu _pauseMenu;

    private void OnEnable()
    {
        _playerLives.OnGameOver += UncleanseFountain;
        _pauseMenu.OnLeaveScene += UncleanseFountain;
    }

    private void OnDisable()
    {
        _playerLives.OnGameOver -= UncleanseFountain;
        _pauseMenu.OnLeaveScene -= UncleanseFountain;
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt(gameObject.name) == 1)
        {
            GetComponent<Animator>().Play("CleansedFountain");
            key = true;
        }
    }

    private void UncleanseFountain()
    {
        PlayerPrefs.SetInt(gameObject.name, 0);
    }


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
            PlayerPrefs.SetInt(gameObject.name, 1);

            // Enables and plays initial regen sound
            if (sound == false)
            {
                FindObjectOfType<AudioManager>().PlaySound(regenSound);
            }
            sound = true;

            // Performs health regen
            PlayerHealth PH = other.GetComponent<PlayerHealth>();

            if (PH.GetCurrentHealth() < PH.GetInitialHealth())
            {
                increaseAmount = PH.GetInitialHealth() - PH.GetCurrentHealth();
                PH.IncreaseHealth(increaseAmount);
            }    

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
