using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLooseMass : MonoBehaviour
{
    //paremeters
    [SerializeField] private PlayerHealth _health;

    [SerializeField] float _miniumScale;

    [SerializeField] [Tooltip("The lower the value, the slower the object scales down with health")] float _downScaleTimeFactor;


    private void OnEnable()
    {
        _health.OnHealthDecrease += DecreasePlayerMass;
    }
    private void OnDisable()
    {
        _health.OnHealthDecrease -= DecreasePlayerMass;
    }

    private void DecreasePlayerMass()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(_miniumScale,_miniumScale,_miniumScale), Time.deltaTime * _downScaleTimeFactor);
    }
}
