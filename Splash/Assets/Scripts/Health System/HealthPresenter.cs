using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthPresenter : MonoBehaviour
{
    //todo: link health ui and playerhealth class through this healthpresenter class, USING MVP PATTERN

    //paramters
    [SerializeField] PlayerHealth _playerHealth;
    [SerializeField] TextMeshProUGUI _healthText;

    private void Start() 
    {
        UpdateHealthUI();    
    }
    
    private void OnEnable() 
    {
        _playerHealth.OnHealthChange += UpdateHealthUI;
    }

    private void OnDisable()
    {
        _playerHealth.OnHealthChange -= UpdateHealthUI;
    }

    private void UpdateHealthUI()
    {
        _healthText.text = _playerHealth.GetHealth().ToString();
    }
}

