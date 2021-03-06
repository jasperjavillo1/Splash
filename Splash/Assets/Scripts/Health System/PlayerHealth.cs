using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public PlayerLives PL;

    //paramters
    [SerializeField] float _initialHealth;

    //state
    public float _currentHealth;

    public float RemainingHealthFraction { get { return _currentHealth / _initialHealth; } }

    public bool IsInBossFight { get; private set; }

    //cache

    //events

    public delegate void HealthChangeEventHandler();
    public event HealthChangeEventHandler OnHealthChange;

    public delegate void HealthZeroEventHandler();
    public event HealthZeroEventHandler OnHealthZero;

    public GameObject healthBar;

    private void Awake()
    {
        ResetHealth();
        IsInBossFight = false;
    }

    public void ResetHealth()
    {
        _currentHealth = _initialHealth;
        if (OnHealthChange != null) OnHealthChange();
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
        healthBar.GetComponent<SpriteRenderer>().color = Color.cyan;
        StartCoroutine(Blink());

        _currentHealth -= Mathf.Abs(amount);
        if (OnHealthChange != null) OnHealthChange();

        if (_currentHealth <= 0)
        {
            PL.LoseLives();
            if (OnHealthZero != null) OnHealthZero();
        }
    }

    public void IncreaseHealth(float amount)
    {
        healthBar.GetComponent<SpriteRenderer>().color = Color.green;
        StartCoroutine(Blink());

        _currentHealth += Mathf.Abs(amount);
        if (OnHealthChange != null) OnHealthChange();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("EnemyProjectile"))
        {
            if (other.gameObject.GetComponent<EnemyProjectile>())
            {
                DecreaseHealth(other.gameObject.GetComponent<EnemyProjectile>().Damage);
            }

            else if (other.gameObject.GetComponent<BoomerangProjectile>())
            {
                DecreaseHealth(other.gameObject.GetComponent<BoomerangProjectile>().Damage);
            }

            Destroy(other.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DisablePlayerCost"))
        {
            IsInBossFight = true;
        }
    }


    IEnumerator Blink()
    {
        yield return new WaitForSeconds(.1f);
        healthBar.GetComponent<SpriteRenderer>().color = Color.white;
    }
}


