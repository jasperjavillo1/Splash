using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class PauseMenu : MonoBehaviour
{
    public GameObject pMenu;
    public bool paused;
    private PlayerInput _playerInput;
    private bool _isPauseButtonPressed = false;
    public bool passedVolume = false;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.PauseMenu.Pause.started += _onPauseButton;
        if (passedVolume)
        {
            AudioListener.volume = pMenu.GetComponentInChildren<Slider>().value;
        }
        else
        {
            pMenu.GetComponentInChildren<Slider>().value = AudioListener.volume;
        }
        passedVolume = true;
    }

    private void Start() 
    {
        Resume();
    }

    public void Update()
    {
        if (passedVolume)
        {
            AudioListener.volume = pMenu.GetComponentInChildren<Slider>().value;            
            Debug.Log("pUpdate 1 Master Volume: " + AudioListener.volume);

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
