using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CleanseCounter : MonoBehaviour
{
    public TextMeshProUGUI cleanseCounter;
    private int toxicFountains = 0;
    bool cleansed = false;
    private GameObject[] keys;
    private int playerPrefKey;

    // Start is called before the first frame update
    void Start()
    {
        keys = GameObject.FindGameObjectsWithTag("Key");
        foreach(GameObject fountainKey in keys)
        {
            toxicFountains++;

            playerPrefKey = PlayerPrefs.GetInt("KeyCount");
        }

        toxicFountains = playerPrefKey;
        cleanseCounter.text = toxicFountains.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        //playerPrefKey = PlayerPrefs.GetInt("KeyCount");

        if (cleansed)
        {
            toxicFountains--;
            toxicFountains -= playerPrefKey;
            cleanseCounter.text = toxicFountains.ToString();
            cleansed = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Key"))
        {
            cleansed = true;
        }
    }
}
