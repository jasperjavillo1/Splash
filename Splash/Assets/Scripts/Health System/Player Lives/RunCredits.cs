using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunCredits : MonoBehaviour
{
    public GameObject Credits;
    private void Start()

    // Credits initially off
    {
        Credits.SetActive(false);
    }
    private void CreditsOn()
    {
        // Credits on
        Credits.SetActive(true);
       
        // Reset lives to 3
        PlayerPrefs.SetFloat("CurrentLives", 3f);
    }
}
