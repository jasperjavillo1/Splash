using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class creditsToMenu : MonoBehaviour
{
    void ReturnToMenu()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }

}
