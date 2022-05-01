using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class PauseMenu : MonoBehaviour
{
    public GameObject pMenu;
    public GameObject oMenu;
    public bool paused;
    private PlayerInput _playerInput;
    private bool _isPauseButtonPressed = false;
    public bool menuOpened = false;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.PauseMenu.Pause.started += _onPauseButton;
        if (menuOpened)
        {
            AudioListener.volume = pMenu.GetComponentInChildren<Slider>().value;
        }
        else
        {
            pMenu.GetComponentInChildren<Slider>().value = AudioListener.volume;
            Debug.Log("Awake PMSL: " + AudioListener.volume);

        }
        menuOpened = true;
    }

    private void Start() 
    {
        Resume();
    }

    public void Update()
    {
        if (menuOpened)
        {
            AudioListener.volume = pMenu.GetComponentInChildren<Slider>().value;
            oMenu.GetComponentInChildren<Slider>().value = AudioListener.volume;

        }
        if (_isPauseButtonPressed && paused == false)
        {
            Pause();
            _isPauseButtonPressed = false;
            paused = true;
        }

        else if(_isPauseButtonPressed && paused)
        {
            Resume();
            _isPauseButtonPressed = false;
            paused = false;
        }
    }

    private void OnEnable()
    {
        _playerInput.PauseMenu.Enable();

    }
    private void OnDisable()
    {
        _playerInput.PauseMenu.Disable();
    }

    private void _onPauseButton(InputAction.CallbackContext _context)
    {
        _isPauseButtonPressed = _context.ReadValueAsButton();
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
