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
        playerPrefKey = PlayerPrefs.GetInt("KeyCount");

        keys = GameObject.FindGameObjectsWithTag("Key");
        foreach(GameObject fountainKey in keys)
        {
            toxicFountains++;

        }

        if (playerPrefKey == 3)
        {
            if (keys[0].activeInHierarchy)
            {
                keys[0].SetActive(false);

            }
            if (keys[1].activeInHierarchy)
            {
                keys[1].SetActive(false);

            }
            if (keys[2].activeInHierarchy)
            {
                keys[2].SetActive(false);

            }

            toxicFountains = 0;

        }else if (playerPrefKey == 2)
        {
            if (keys[0].activeInHierarchy)
            {
                keys[0].SetActive(false);

            }
            else if (keys[1].activeInHierarchy)
            {
                keys[1].SetActive(false);
            }
            else if (keys[2].activeInHierarchy)
            {
                keys[2].SetActive(false);
            }

            toxicFountains = 1;
        }
        else if (playerPrefKey == 1)
        {
            if (keys[0].activeInHierarchy)
            {
                keys[0].SetActive(false);

            }
            else if (keys[1].activeInHierarchy)
            {
                keys[1].SetActive(false);
            }
            else if (keys[2].activeInHierarchy)
            {
                keys[2].SetActive(false);
            }
            toxicFountains = 2;

        }


        Debug.Log(PlayerPrefs.GetInt("KeyCount"));
        Debug.Log("Fountains: "+toxicFountains);



        //toxicFountains -= PlayerPrefs.GetInt("KeyCount");
        cleanseCounter.text = toxicFountains.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        //playerPrefKey = PlayerPrefs.GetInt("KeyCount");

        if (cleansed)
        {
            //toxicFountains-= PlayerPrefs.GetInt("KeyCount");
            //toxicFountains -= playerPrefKey;
            cleanseCounter.text = toxicFountains.ToString();
            cleansed = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Key"))
        {
            toxicFountains--; 
            //PlayerPrefs.GetInt("KeyCount");

            //toxicFountains -= PlayerPrefs.GetInt("KeyCount");
            Debug.Log(PlayerPrefs.GetInt("KeyCount"));
            Debug.Log("Fountains: " + toxicFountains);
            cleansed = true;
        }
    }
}
