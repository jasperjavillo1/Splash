using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomExit : MonoBehaviour
{
    [SerializeField] private GameObject _boss;
    [SerializeField] private GameObject _enterDoor;
    [SerializeField] private GameObject _exitDoor;
    [SerializeField] private BossTrigger _bossTrigger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!_boss.activeInHierarchy && _enterDoor.activeInHierarchy)
        {
            _bossTrigger.gameObject.SetActive(false);
            _exitDoor.SetActive(false);
        }
    }
}
