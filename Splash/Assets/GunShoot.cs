using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GunShoot : MonoBehaviour
{
    //parameters
    [SerializeField] Transform _shotSpawnPosition;
    [SerializeField] GameObject _gunMuzzleParticles;
    [SerializeField] GameObject _objectHitParticles;

    //events

    public delegate void ObjectHitEventHandler();
    public event ObjectHitEventHandler OnObjectHit;

    public void Shoot()
    {
        RaycastHit2D hit = Physics2D.Raycast(_shotSpawnPosition.position, (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized);
        if(hit == true)
        {
            Instantiate(_gunMuzzleParticles, new Vector2(_shotSpawnPosition.position.x, _shotSpawnPosition.position.y), Quaternion.identity);
            Instantiate(_objectHitParticles, new Vector2(hit.point.x, hit.point.y), Quaternion.identity);
            
            if(OnObjectHit != null) OnObjectHit();
        }
        
    }

    private void Update() 
    {
        if(Time.time > 1f && Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }


}
