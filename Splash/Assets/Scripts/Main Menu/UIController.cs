using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public Button btnStart;
    public Button btnQuit;
    public Button btnCredits;
    public Slider sliderVolume;

    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        btnStart = root.Q<Button>("startButton");
        btnQuit = root.Q<Button>("quitButton");
        btnCredits = root.Q<Button>("creditsButton");
        sliderVolume = root.Q<Slider>("volume");
        btnStart.clicked += StartButtonPressed;
        btnQuit.clicked += QuitButtonPressed;
        btnCredits.clicked += CreditsButtonPressed;
        AudioListener.volume = (sliderVolume.value/100);

    }

    void StartButtonPressed() 
    {
        SceneManager.LoadScene("Level_Select_Screen");
    }

    void QuitButtonPressed() 
    {
        Application.Quit();
    }

    void CreditsButtonPressed() 
    {
        SceneManager.LoadScene("Credits");
    }

    void Update() 
    {
        AudioListener.volume = (sliderVolume.value / 100);    
    }
}
