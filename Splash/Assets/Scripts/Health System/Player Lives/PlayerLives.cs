using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerLives : MonoBehaviour
{
    public float _CurrentLives =3f;
    public GameObject gameOver;
    public UnityEngine.UI.Text LivesCount;
    public bool livesreset;

    private PlayerInput _playerInput;
    private bool _isLivesSystemTestPressed;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Test.LoseLife.started += _onLoseLifeTest;
        _playerInput.Test.LoseLife.canceled += _onLoseLifeTest;
    }
    // Start is called before the first frame update
    void Start()
    {  
        LivesCount = GameObject.Find("LivesCountText").GetComponent<UnityEngine.UI.Text>();
        gameOver.SetActive(false);
        
        _CurrentLives = PlayerPrefs.GetFloat("CurrentLives");
    }
    private void Update()
    {
        if (_isLivesSystemTestPressed)
        {
            LoseLives();
        }
        LivesCount.text = _CurrentLives.ToString();
    }
    public void LoseLives()
    {   if(_CurrentLives >=1f)
        {
            _CurrentLives--;
            PlayerPrefs.SetFloat("CurrentLives", _CurrentLives);
        }
        
        //Game Over "if" statement.
        if (_CurrentLives <=0f)
        {

            livesreset = true;
            gameOver.SetActive(true);
            
        }
    }

    private void _onLoseLifeTest(InputAction.CallbackContext context)
    {
        _isLivesSystemTestPressed = context.ReadValueAsButton();
    }
   
}
