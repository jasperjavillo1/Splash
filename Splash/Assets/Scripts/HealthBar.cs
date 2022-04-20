using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    //state
    private float _startingHealth;
    private float _startingHealthBarScale;

    //cached comp refs
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _startingHealth = GetComponentInParent<PlayerHealth>().GetCurrentHealth();
        _startingHealthBarScale = transform.localScale.x;

        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //formula derived to scale
        float healthToStartingHealthRatio = GetComponentInParent<PlayerHealth>().GetCurrentHealth() / _startingHealth;
        float newScale = healthToStartingHealthRatio * _startingHealthBarScale;
        
        transform.localScale = new Vector3(newScale, newScale, transform.localScale.z);
    }
}
