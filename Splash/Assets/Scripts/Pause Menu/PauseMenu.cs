using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject pMenu;
    public bool paused;
    private PlayerInput _playerInput;
    private bool _isPauseButtonPressed;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.PauseMenu.Pause.started += _onPauseButton;
        _playerInput.PauseMenu.Pause.canceled += _onPauseButton;
    }

    private void Start() 
    {
        Resume();
    }

    public void Update()
    {
        if (_isPauseButtonPressed && paused == false)
        {
            Pause();
            paused = true;
        }

        else if(_isPauseButtonPressed && paused)
        {
            Resume();
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
