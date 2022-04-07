using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour
{
    public float _CurrentLives =3f;
    public float _LivesReset = 3f;
    public GameObject gameOver;
    public UnityEngine.UI.Text LivesCount;
    public bool livesreset;
    
    // Start is called before the first frame update
    void Start()
    {  
        LivesCount = GameObject.Find("LivesCountText").GetComponent<UnityEngine.UI.Text>();
        gameOver.SetActive(false);
        
        _CurrentLives = PlayerPrefs.GetFloat("CurrentLives");
        
        
        

    }
    private void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.P))
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
   
}
