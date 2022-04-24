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
    public static int Lvl_5;

    public GameObject LVL1;
    public GameObject LVL2;
    public GameObject LVL3;
    public GameObject LVL4;
    public GameObject LVL5;
    public GameObject Credits;


    // Start is called before the first frame update
    void Start()
    {


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
        if (Lvl_5 == 1)
        {
            LVL5.SetActive(false);
        }
        if (Lvl_1 == 1 && Lvl_2 == 1 && Lvl_3 == 1 && Lvl_4 == 1 && Lvl_5 == 1)
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
        SceneManager.LoadScene(3);
    }
    public void GoToLevel2()
    {
        SceneManager.LoadScene(4);
    }
    public void GoToLevel3()
    {
        SceneManager.LoadScene(5);
    }
    public void GoToLevel4()
    {
        SceneManager.LoadScene(6);
    }
    public void GoToLevel5()
    {
        SceneManager.LoadScene(7);
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
    public void SetLvl5Complete()
    {
        Lvl_4 = 1;
        PlayerPrefs.SetInt("Lvl_5", Lvl_5 = 1);
    }




}
