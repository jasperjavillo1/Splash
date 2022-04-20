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
    

    //state
    private float _nextShootTime = 0.2f;

    //events

    public delegate void ObjectHitEventHandler();
    public event ObjectHitEventHandler OnObjectHit;

    public void Shoot()
    {
        Instantiate(_projectilePrefab, new Vector2(_shotSpawnPosition.position.x, _shotSpawnPosition.position.y), Quaternion.identity);
        
        if(OnObjectHit != null) OnObjectHit();
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
