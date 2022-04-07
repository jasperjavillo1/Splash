using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunCredits : MonoBehaviour
{
    public GameObject Credits;
    private void Start()
    {
        Credits.SetActive(false);
    }
    private void CreditsOn()
    {
        Credits.SetActive(true);
       
        PlayerPrefs.SetFloat("CurrentLives", 3f);
    }
}
