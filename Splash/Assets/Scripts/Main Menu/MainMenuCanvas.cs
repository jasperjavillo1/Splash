using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuCanvas : MonoBehaviour {

    //public GameObject mainMenu;

    //  buttons
    public void Play() {
        SceneManager.LoadScene("Level_Select_Screen");
    }

    public void Options() {
        //SceneManager.LoadScene("OptionsMenu");
    }

    public void Credits() {
        SceneManager.LoadScene("Credits");
    }

    public void Quit() {
        Application.Quit();
    }
}
