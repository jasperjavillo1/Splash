using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLooseMass : MonoBehaviour
{
    //paremeters
    [SerializeField] private PlayerHealth _health;

    [SerializeField] [Tooltip("The lower the value, the slower the object scales down with health")] float _scaleTimeFactor;


    private void OnEnable()
    {
        _health.OnHealthDecrease += DecreasePlayerMass;
        _health.OnHealthIncrease += IncreasePlayerMass;
        _health.OnHealthReset += IncreasePlayerMass;
    }
    private void OnDisable()
    {
        _health.OnHealthDecrease -= DecreasePlayerMass;
        _health.OnHealthIncrease -= IncreasePlayerMass;
        _health.OnHealthReset -= IncreasePlayerMass;
    }
    

    private void DecreasePlayerMass()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, transform.localScale * Mathf.Abs(_health.GetCurrentHealth()/_health.GetInitialHealth()), Time.deltaTime * _scaleTimeFactor);
    }

    private void IncreasePlayerMass()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1f,1f,1f), Time.deltaTime * _scaleTimeFactor);
    }
}
