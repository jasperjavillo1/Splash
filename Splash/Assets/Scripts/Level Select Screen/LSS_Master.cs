using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LSS_Master : MonoBehaviour
{
    public static int Lvl_1;
    public static int Lvl_2;
    public static int Lvl_3;
    public static int Lvl_4;

    public GameObject LVL1;
    public GameObject LVL2;
    public GameObject LVL3;
    public GameObject LVL4;
    public GameObject Credits;


    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("KeyCount", 0);
        PlayerPrefs.SetInt("Current Checkpoint", 1);

        if (Lvl_1 == 1)
        {
            LVL1.SetActive(false);
        }
        if (Lvl_2 == 1)
        {
            LVL2.SetActive(false);
        }
        if (Lvl_3 == 1)
        {
            LVL3.SetActive(false);
        }
        if (Lvl_4 == 1)
        {
            LVL4.SetActive(false);
        }

        if (Lvl_1 == 1 && Lvl_2 == 1 && Lvl_3 == 1 && Lvl_4 == 1)
        {
            Credits.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToLevel1()
    {
        PlayerPrefs.SetInt("PrevSceneIndex", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(3);
    }
    public void GoToLevel2()
    {
        PlayerPrefs.SetInt("PrevSceneIndex", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(4);
    }
    public void GoToLevel3()
    {
        PlayerPrefs.SetInt("PrevSceneIndex", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(5);
    }
    public void GoToLevel4()
    {
        PlayerPrefs.SetInt("PrevSceneIndex", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(6);
    }
    public void MainMenu()
    {
        PlayerPrefs.SetInt("PrevSceneIndex", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(0);
    }

    public void SetLvl1Complete()
    {
        Lvl_1 = 1;
        PlayerPrefs.SetInt("Lvl_1", Lvl_1 = 1);
    }
    public void SetLvl2Complete()
    {
        Lvl_2 = 1;
        PlayerPrefs.SetInt("Lvl_2", Lvl_2 = 1);
    }
    public void SetLvl3Complete()
    {
        Lvl_3 = 1;
        PlayerPrefs.SetInt("Lvl_3", Lvl_3 = 1);
    }
    public void SetLvl4Complete()
    {
        Lvl_4 = 1;
        PlayerPrefs.SetInt("Lvl_4", Lvl_4 = 1);
    }

}
