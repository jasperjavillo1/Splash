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

    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        btnStart = root.Q<Button>("startButton");
        btnQuit = root.Q<Button>("quitButton");
        btnCredits = root.Q<Button>("creditsButton");
        btnStart.clicked += StartButtonPressed;
        btnQuit.clicked += QuitButtonPressed;
        btnCredits.clicked += CreditsButtonPressed;
    }

    void StartButtonPressed() {
        SceneManager.LoadScene("SampleScene");
    }

    void QuitButtonPressed() {
        Application.Quit();
    }

    void CreditsButtonPressed() {
        SceneManager.LoadScene("Credits");
    }
}
