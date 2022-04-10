using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassToNextLevel : MonoBehaviour
{

   public void PassToNext()
    {
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }


}
