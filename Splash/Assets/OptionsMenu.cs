using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class OptionsMenu : MonoBehaviour
{
    public Slider masterVolume;

    public void MainMenu()
    {
        SceneManager.LoadScene(0);

    }
    void Update()
    {
        AudioListener.volume = masterVolume.value;
    }
}
