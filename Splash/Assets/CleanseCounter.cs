using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CleanseCounter : MonoBehaviour
{
    public TextMeshProUGUI cleanseCounter;
    public int toxicFountains = 3;
    bool cleansed = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (cleansed)
        {
            toxicFountains--;
            cleanseCounter.text = "Toxic Fountains: " + toxicFountains;
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
