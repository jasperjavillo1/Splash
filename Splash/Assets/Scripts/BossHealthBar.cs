using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    public Slider Slider;
    public Color Low;
    public Color High;
    public Vector3 Offset;
    public Boss1 boss1;

    public void Start()
    {
        //boss1 = FindObjectOfType<Boss1>();
        

        if (!boss1.isActiveAndEnabled)
        {
            //gameObject.SetActive(false);
            Slider.GetComponentsInChildren<Image>()[0].color = Color.clear;
            Slider.GetComponentsInChildren<Image>()[1].color = Color.clear;

        }

    }

    /*public void SetHealth(float health, float MaxHealth)
    {
        health = boss1.health;

        Slider.gameObject.SetActive(health < MaxHealth);
        Slider.value = health;
        Slider.maxValue = MaxHealth;

        Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, High, Slider.normalizedValue);
    }*/

    // Update is called once per frame
    void Update()
    {
        if (boss1.isActiveAndEnabled)
        {
            Slider.GetComponentsInChildren<Image>()[0].color = Color.red;
            Slider.GetComponentsInChildren<Image>()[1].color = Color.green;
        }

        Slider.value = boss1.health;
        Debug.Log("Slider value: " + Slider.value + " , Boss Health: " + boss1.health);
        if(boss1.health == 0)
        {
            Slider.gameObject.SetActive(false);
        }
        //Slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
    }

    private void Awake()
    {
        if (!boss1.isActiveAndEnabled)
        {
            //gameObject.SetActive(false);
            Slider.GetComponentsInChildren<Image>()[0].color = Color.clear;
            Slider.GetComponentsInChildren<Image>()[1].color = Color.clear;

        }
    }
}
