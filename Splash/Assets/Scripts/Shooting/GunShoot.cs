using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GunShoot : MonoBehaviour
{
    //parameters
    [SerializeField] Transform _shotSpawnPosition;
    [SerializeField] GameObject _projectilePrefab;
    

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
        if(Time.time > 2f && Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }


}
