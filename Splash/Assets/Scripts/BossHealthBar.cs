using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class BossHealthBar : MonoBehaviour
{
    public Slider Slider;
    public Color Low;
    public Color High;
    public Vector3 Offset;
    public Boss1 boss1;
    public Boss2 boss2;
    public Boss3 boss3;

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(3))
        {
            if (boss1.isActiveAndEnabled)
            {
                Slider.GetComponentsInChildren<Image>()[0].color = Color.red;
                Slider.GetComponentsInChildren<Image>()[1].color = Color.green;
                transform.GetChild(1).GetComponent<TextMeshProUGUI>().enabled = true;

            }

            Slider.value = boss1.health;
            if (boss1.health == 0)
            {
                Slider.gameObject.SetActive(false);
                transform.GetChild(1).GetComponent<TextMeshProUGUI>().enabled = false;

            }
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(4))
        {
            if (boss3.isActiveAndEnabled)
            {
                Slider.GetComponentsInChildren<Image>()[0].color = Color.red;
                Slider.GetComponentsInChildren<Image>()[1].color = Color.green;
                transform.GetChild(1).GetComponent<TextMeshProUGUI>().enabled = true;

            }

            Slider.value = boss3.health;
            if (boss3.health == 0)
            {
                Slider.gameObject.SetActive(false);
                transform.GetChild(1).GetComponent<TextMeshProUGUI>().enabled = false;

            }
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(5))
        {
            if (boss2.isActiveAndEnabled)
            {
                Slider.GetComponentsInChildren<Image>()[0].color = Color.red;
                Slider.GetComponentsInChildren<Image>()[1].color = Color.green;
                transform.GetChild(1).GetComponent<TextMeshProUGUI>().enabled = true;

            }

            Slider.value = boss2.health;
            if (boss2.health == 0)
            {
                Slider.gameObject.SetActive(false);
                transform.GetChild(1).GetComponent<TextMeshProUGUI>().enabled = false;

            }
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("SampleScene 1"))
        {
            if (boss1.isActiveAndEnabled)
            {
                Slider.GetComponentsInChildren<Image>()[0].color = Color.red;
                Slider.GetComponentsInChildren<Image>()[1].color = Color.green;
                transform.GetChild(1).GetComponent<TextMeshProUGUI>().enabled = true;
                Slider.value = boss1.health;
                if (boss1.health == 0)
                {
                    Slider.gameObject.SetActive(false);
                    transform.GetChild(1).GetComponent<TextMeshProUGUI>().enabled = false;

                }
            }
            else if (boss3.isActiveAndEnabled)
            {
                Slider.GetComponentsInChildren<Image>()[0].color = Color.red;
                Slider.GetComponentsInChildren<Image>()[1].color = Color.green;
                transform.GetChild(1).GetComponent<TextMeshProUGUI>().enabled = true;

                Slider.value = boss3.health;
                if (boss3.health == 0)
                {
                    Slider.gameObject.SetActive(false);
                    transform.GetChild(1).GetComponent<TextMeshProUGUI>().enabled = false;

                }
            }
            else if (boss2.isActiveAndEnabled)
            {
                Slider.GetComponentsInChildren<Image>()[0].color = Color.red;
                Slider.GetComponentsInChildren<Image>()[1].color = Color.green;
                transform.GetChild(1).GetComponent<TextMeshProUGUI>().enabled = true;

                Slider.value = boss2.health;
                if (boss2.health == 0)
                {
                    Slider.gameObject.SetActive(false);
                    transform.GetChild(1).GetComponent<TextMeshProUGUI>().enabled = false;

                }
            }
            else
            {
                //gameObject.SetActive(false);
                Slider.GetComponentsInChildren<Image>()[0].color = Color.clear;
                Slider.GetComponentsInChildren<Image>()[1].color = Color.clear;
                transform.GetChild(1).GetComponent<TextMeshProUGUI>().enabled = false;

            }
        }
    }

    private void Awake()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(3))
        {
            //boss1 = FindObjectOfType<Boss1>();

            if (!boss1.isActiveAndEnabled)
            {
                //gameObject.SetActive(false);
                Slider.GetComponentsInChildren<Image>()[0].color = Color.clear;
                Slider.GetComponentsInChildren<Image>()[1].color = Color.clear;
                transform.GetChild(1).GetComponent<TextMeshProUGUI>().enabled = false;

            }
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(4))
        {
            //boss2 = FindObjectOfType<Boss2>();
            if (!boss3.isActiveAndEnabled)
            {
                //gameObject.SetActive(false);
                Slider.GetComponentsInChildren<Image>()[0].color = Color.clear;
                Slider.GetComponentsInChildren<Image>()[1].color = Color.clear;
                transform.GetChild(1).GetComponent<TextMeshProUGUI>().enabled = false;

            }
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(5))
        {
            if (!boss2.isActiveAndEnabled)
            {
                //gameObject.SetActive(false);
                Slider.GetComponentsInChildren<Image>()[0].color = Color.clear;
                Slider.GetComponentsInChildren<Image>()[1].color = Color.clear;
                transform.GetChild(1).GetComponent<TextMeshProUGUI>().enabled = false;

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
                transform.GetChild(1).GetComponent<TextMeshProUGUI>().enabled = false;
            }
            else if (!boss2.isActiveAndEnabled)
            {
                //gameObject.SetActive(false);
                Slider.GetComponentsInChildren<Image>()[0].color = Color.clear;
                Slider.GetComponentsInChildren<Image>()[1].color = Color.clear;
                transform.GetChild(1).GetComponent<TextMeshProUGUI>().enabled = false;

            }
            else if (!boss3.isActiveAndEnabled)
            {
                //gameObject.SetActive(false);
                Slider.GetComponentsInChildren<Image>()[0].color = Color.clear;
                Slider.GetComponentsInChildren<Image>()[1].color = Color.clear;
                transform.GetChild(1).GetComponent<TextMeshProUGUI>().enabled = false;

            }
        }
    }
}
