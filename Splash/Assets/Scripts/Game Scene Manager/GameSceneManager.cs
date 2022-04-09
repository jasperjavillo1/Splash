using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    //parameters
    [SerializeField] PlayerHealth _playerHealth;
    [SerializeField] PlayerLives _playerLives;
    private void OnEnable() 
    {
        
        _playerHealth.OnHealthZero += ReloadLevel;    
    }

    private void OnDisable()
    {
        
        _playerHealth.OnHealthZero -= ReloadLevel;
    }

    private void ReloadLevel()
    {
        if(_playerHealth._currentHealth <= 0f && _playerLives._CurrentLives >= 1f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
