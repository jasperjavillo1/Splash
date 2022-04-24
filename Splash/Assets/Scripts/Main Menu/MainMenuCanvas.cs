using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuCanvas : MonoBehaviour {


    //  buttons
    public void play() {
        SceneManager.LoadScene("Level_Select_Screen");
    }

    public void options() {
        //  does nothing so far
    }

    public void credits() {
        SceneManager.LoadScene("Credits");
    }

    public void quit() {
        Application.Quit();
    }
}
