using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GunShoot : MonoBehaviour
{
    //parameters
    [SerializeField] Transform _shotSpawnPosition;
    [SerializeField] GameObject _projectilePrefab;
    [SerializeField] private float _shootInterval = 0.2f;
    [SerializeField] private int _healthCost;
    [SerializeField] private AudioClip _gunShootSound;

    //state
    private float _nextShootTime = 0.2f;

    //cache
    private PlayerHealth _playerHealth;
    private AudioSource _audioSource;

    //events

    public delegate void ObjectHitEventHandler();
    public event ObjectHitEventHandler OnObjectHit;

    private void Start()
    {
        _playerHealth = GetComponentInParent<PlayerHealth>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void Shoot()
    {
        Instantiate(_projectilePrefab, new Vector2(_shotSpawnPosition.position.x, _shotSpawnPosition.position.y), Quaternion.identity);
        _audioSource.volume = FindObjectOfType<AudioManager>().GetComponents<AudioSource>()[0].volume;
        _audioSource.PlayOneShot(_gunShootSound);


        if (OnObjectHit != null) OnObjectHit();
    }

    private void Update() 
    {
        if((Input.GetButton("Fire1") || Input.GetButton("Fire2")) && Time.time > _nextShootTime)
        {
            Shoot();
            _nextShootTime = Time.time + _shootInterval;
        }
    }


}
