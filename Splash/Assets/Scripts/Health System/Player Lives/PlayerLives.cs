using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour
{
    public float _CurrentLives;
    public GameObject gameOver;
    public UnityEngine.UI.Text LivesCount;

    // Start is called before the first frame update
    void Start()
    {
        LivesCount = GameObject.Find("LivesCountText").GetComponent<UnityEngine.UI.Text>();
        gameOver.SetActive(false);
        
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
    {
        _CurrentLives--;

        //Game Over "if" statement.
        if (_CurrentLives < 1 && _CurrentLives == 0)
        {
            gameOver.SetActive(true);
        }
    }
   
}
