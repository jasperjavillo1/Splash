using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBlocker : MonoBehaviour
{
    public GameObject Fountain1;
    public GameObject Fountain2;
    public GameObject Fountain3;
    public GameObject Blocker;
    public GameObject BossWarning;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!Fountain1.activeInHierarchy && !Fountain2.activeInHierarchy && !Fountain3.activeInHierarchy)
        {
            Blocker.transform.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BossWarning.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        BossWarning.SetActive(false);
    }
}
