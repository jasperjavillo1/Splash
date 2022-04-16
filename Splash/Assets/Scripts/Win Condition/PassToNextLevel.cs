using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassToNextLevel : MonoBehaviour
{
    public LSS_Master lss;

    public void PassToNext()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3) 
        {
            lss.SetLvl1Complete();
        }
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            lss.SetLvl2Complete();
        }
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            lss.SetLvl3Complete();
        }
        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            lss.SetLvl4Complete();
        }
        if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            lss.SetLvl5Complete();
        }
        SceneManager.LoadScene("Level_Select_Screen");
    }


}
