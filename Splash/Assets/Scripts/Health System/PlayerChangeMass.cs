using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChangeMass : MonoBehaviour
{
    //paremeters
    [SerializeField] private PlayerHealth _health;


    private void OnEnable()
    {
        _health.OnHealthChange += UpdatePlayerMass;
    }
    private void OnDisable()
    {
        _health.OnHealthChange += UpdatePlayerMass;
    }
    

    private void UpdatePlayerMass()
    {
        // Vector3 newScale = Mathf.Abs(_health.GetCurrentHealth()/_health.GetInitialHealth()) * new Vector3(1f,1f,1f);
        // transform.localScale = newScale;
    }

}
