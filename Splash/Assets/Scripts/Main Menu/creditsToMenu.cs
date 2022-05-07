using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class creditsToMenu : MonoBehaviour
{
    public GameObject mainMenu;
    void ReturnToMenu()
    {
        //SceneManager.LoadScene(0);
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByBuildIndex(0))
        {
            SceneManager.LoadScene(0);

        }
        else
        {
            mainMenu.SetActive(true);
            gameObject.SetActive(false);

        }

    }

}
