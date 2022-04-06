using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    //parameters
    [SerializeField] PlayerHealth _playerHealth;

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);        
    }
}
