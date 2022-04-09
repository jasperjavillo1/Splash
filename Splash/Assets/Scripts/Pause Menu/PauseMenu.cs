using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pMenu;
    public bool paused;


    private void Start() 
    {
        Resume();
    }

    public void Update()
    {
        if (paused == false)
        {
            Pause();
            paused = true;
        }

        else if(paused)
        {
            Resume();
            paused = false;
        }
    }

    public void Pause()
    {
        pMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pMenu.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
