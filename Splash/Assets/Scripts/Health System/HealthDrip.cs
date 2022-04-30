using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDrip : MonoBehaviour
{
    [SerializeField] private GameObject _healthPickUp;
    [SerializeField] private float _timeBetweenDrop;
    [SerializeField] private float _initialWait;

    private Coroutine dropDelay;

    // Start is called before the first frame update
    void Start()
    {
        dropDelay = StartCoroutine(DropHealth(_initialWait));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawnHealth()
    {
        Instantiate(_healthPickUp, transform.position, Quaternion.identity);
    }
    private IEnumerator DropHealth(float delay)
    {
        yield return new WaitForSeconds(delay);
        spawnHealth();
        dropDelay = StartCoroutine(DropHealth(_timeBetweenDrop));
    }
}
