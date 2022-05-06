using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossHealthBar : MonoBehaviour
{
    public Slider Slider;
    public Color Low;
    public Color High;
    public Vector3 Offset;
    public Boss1 boss1;
    public Boss2 boss2;
    public Boss3 boss3;


    //public GameObject boss;
    
    
    public void Start()
    {
        //boss1 = FindObjectOfType<Boss1>();
        //Debug.Log("Boss Name: " + boss1.name);

        /*if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(3))
        {
            Debug.Log("Testing");
            boss1 = FindObjectOfType<Boss1>();

            if (!boss1.isActiveAndEnabled)
            {
                //gameObject.SetActive(false);
                Slider.GetComponentsInChildren<Image>()[0].color = Color.clear;
                Slider.GetComponentsInChildren<Image>()[1].color = Color.clear;

            }
        }



        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("SampleScene 1"))
        {
            Debug.Log("Testing");
            boss1 = FindObjectOfType<Boss1>();

            if (!boss1.isActiveAndEnabled)
            {
                //gameObject.SetActive(false);
                Slider.GetComponentsInChildren<Image>()[0].color = Color.clear;
                Slider.GetComponentsInChildren<Image>()[1].color = Color.clear;

            }
        }*/
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
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(3))
        {
            if (boss1.isActiveAndEnabled)
            {
                Slider.GetComponentsInChildren<Image>()[0].color = Color.red;
                Slider.GetComponentsInChildren<Image>()[1].color = Color.green;
            }

            Slider.value = boss1.health;
            Debug.Log("Slider value: " + Slider.value + " , Boss Health: " + boss1.health);
            if (boss1.health == 0)
            {
                Slider.gameObject.SetActive(false);
            }
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(4))
        {
            if (boss3.isActiveAndEnabled)
            {
                Slider.GetComponentsInChildren<Image>()[0].color = Color.red;
                Slider.GetComponentsInChildren<Image>()[1].color = Color.green;
            }

            Slider.value = boss3.health;
            Debug.Log("Slider value: " + Slider.value + " , Boss Health: " + boss3.health);
            if (boss3.health == 0)
            {
                Slider.gameObject.SetActive(false);
            }
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(5))
        {
            if (boss2.isActiveAndEnabled)
            {
                Slider.GetComponentsInChildren<Image>()[0].color = Color.red;
                Slider.GetComponentsInChildren<Image>()[1].color = Color.green;
            }

            Slider.value = boss2.health;
            Debug.Log("Slider value: " + Slider.value + " , Boss Health: " + boss2.health);
            if (boss2.health == 0)
            {
                Slider.gameObject.SetActive(false);
            }
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("SampleScene 1"))
        {
            if (boss1.isActiveAndEnabled)
            {
                Slider.GetComponentsInChildren<Image>()[0].color = Color.red;
                Slider.GetComponentsInChildren<Image>()[1].color = Color.green;

                Slider.value = boss1.health;
                Debug.Log("Slider value: " + Slider.value + " , Boss Health: " + boss1.health);
                if (boss1.health == 0)
                {
                    Slider.gameObject.SetActive(false);
                }
            }
            else if (boss3.isActiveAndEnabled)
            {
                Slider.GetComponentsInChildren<Image>()[0].color = Color.red;
                Slider.GetComponentsInChildren<Image>()[1].color = Color.green;

                Slider.value = boss3.health;
                Debug.Log("Slider value: " + Slider.value + " , Boss Health: " + boss3.health);
                if (boss3.health == 0)
                {
                    Slider.gameObject.SetActive(false);
                }
            }
            else if (boss2.isActiveAndEnabled)
            {
                Slider.GetComponentsInChildren<Image>()[0].color = Color.red;
                Slider.GetComponentsInChildren<Image>()[1].color = Color.green;

                Slider.value = boss2.health;
                Debug.Log("Slider value: " + Slider.value + " , Boss Health: " + boss2.health);
                if (boss2.health == 0)
                {
                    Slider.gameObject.SetActive(false);
                }
            }
            else
            {
                //gameObject.SetActive(false);
                Slider.GetComponentsInChildren<Image>()[0].color = Color.clear;
                Slider.GetComponentsInChildren<Image>()[1].color = Color.clear;

            }
        }
        //Slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
    }

    private void Awake()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(3))
        {
            Debug.Log("Testing");
            //boss1 = FindObjectOfType<Boss1>();

            if (!boss1.isActiveAndEnabled)
            {
                //gameObject.SetActive(false);
                Slider.GetComponentsInChildren<Image>()[0].color = Color.clear;
                Slider.GetComponentsInChildren<Image>()[1].color = Color.clear;

            }
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(4))
        {
            //boss2 = FindObjectOfType<Boss2>();
            if (!boss3.isActiveAndEnabled)
            {
                Debug.Log("What's up?");

                //gameObject.SetActive(false);
                Slider.GetComponentsInChildren<Image>()[0].color = Color.clear;
                Slider.GetComponentsInChildren<Image>()[1].color = Color.clear;

            }
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(5))
        {
            if (!boss2.isActiveAndEnabled)
            {
                //gameObject.SetActive(false);
                Slider.GetComponentsInChildren<Image>()[0].color = Color.clear;
                Slider.GetComponentsInChildren<Image>()[1].color = Color.clear;

            }
        }
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("SampleScene 1"))
        {
            //boss1 = FindObjectOfType<Boss1>();

            if (!boss1.isActiveAndEnabled)
            {
                //gameObject.SetActive(false);
                Slider.GetComponentsInChildren<Image>()[0].color = Color.clear;
                Slider.GetComponentsInChildren<Image>()[1].color = Color.clear;

            }
            else if (!boss2.isActiveAndEnabled)
            {
                //gameObject.SetActive(false);
                Slider.GetComponentsInChildren<Image>()[0].color = Color.clear;
                Slider.GetComponentsInChildren<Image>()[1].color = Color.clear;

            }
            else if (!boss3.isActiveAndEnabled)
            {
                //gameObject.SetActive(false);
                Slider.GetComponentsInChildren<Image>()[0].color = Color.clear;
                Slider.GetComponentsInChildren<Image>()[1].color = Color.clear;

            }
        }
    }
}
