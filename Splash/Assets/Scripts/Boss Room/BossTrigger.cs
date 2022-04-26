using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _boss;
    [SerializeField] private GameObject _bossEnterDoor;
    // Start is called before the first frame update
    void Start()
    {
        _boss.SetActive(false);
        _bossEnterDoor.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _boss.SetActive(true);
            _bossEnterDoor.SetActive(true);
        }
    }
}
