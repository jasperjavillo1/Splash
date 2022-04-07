using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public Button btnStart;
    public Button btnQuit;

    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        btnStart = root.Q<Button>("startButton");
        btnQuit = root.Q<Button>("quitButton");

        btnStart.clicked += StartButtonPressed;
    }

    void StartButtonPressed() {
        SceneManager.LoadScene("SampleScene");
    }

    void QuitButtonPressed() {
        Application.Quit();
    }
}
