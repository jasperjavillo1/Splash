using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth :  MonoBehaviour
{
    public PlayerLives PL;
    
    //paramters
    [SerializeField] float _initialHealth;

    //state
    public float _currentHealth;

    public float RemainingHealthFraction{get {return _currentHealth/_initialHealth;}}

    //cache

    //events

    public delegate void HealthChangeEventHandler();
    public event HealthChangeEventHandler OnHealthChange;

    public delegate void HealthZeroEventHandler();
    public event HealthZeroEventHandler OnHealthZero;
 

    private void Awake() 
    {
        ResetHealth();    
    }

    public void ResetHealth()
    {
        _currentHealth = _initialHealth;
        if(OnHealthChange!=null) OnHealthChange();
    }

    public float GetInitialHealth()
    {
        return _initialHealth;
    }
    
    public float GetCurrentHealth()
    {
        return _currentHealth;
    }

    public void DecreaseHealth(float amount)
    {
        _currentHealth -= Mathf.Abs(amount);
        if(OnHealthChange!=null) OnHealthChange();

        if(_currentHealth <= 0)
        {
            PL.LoseLives();
            if (OnHealthZero!=null) OnHealthZero();
        }
    }

    public void IncreaseHealth(float amount)
    {
        _currentHealth += Mathf.Abs(amount);
        if(OnHealthChange != null) OnHealthChange();
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "EnemyProjectile")
        {
            DecreaseHealth(other.gameObject.GetComponent<EnemyProjectile>().Damage);
            Destroy(other.gameObject);
        }    
    }
}
