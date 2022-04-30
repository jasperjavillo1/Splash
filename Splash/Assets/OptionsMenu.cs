using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class OptionsMenu : MonoBehaviour
{
    public Slider masterVolume;
    public Slider musicVolume;
    public Slider effectsVolume;
    public GameObject pauseMenu;
    private void Start()
    {
        AudioListener.volume = .5f;
        //AudioListener.volume = masterVolume.value;
        //FindObjectOfType<AudioManager>().GetComponents<AudioSource>()[1].volume = musicVolume.value;
        //FindObjectOfType<AudioManager>().GetComponents<AudioSource>()[0].volume = effectsVolume.value;
        if (pauseMenu.GetComponentInChildren<Slider>().value != .5f)
        {
            AudioListener.volume = pauseMenu.GetComponentInChildren<Slider>().value;
            masterVolume.value = pauseMenu.GetComponentInChildren<Slider>().value;
        }
        else
        {
            AudioListener.volume = masterVolume.value;
            FindObjectOfType<AudioManager>().GetComponents<AudioSource>()[1].volume = musicVolume.value;
            FindObjectOfType<AudioManager>().GetComponents<AudioSource>()[0].volume = effectsVolume.value;
        }
    }
 
    public void MainMenu()
    {
        //SceneManager.LoadScene(0);

    }
    void Update()
    {
        AudioListener.volume = masterVolume.value;
        FindObjectOfType<AudioManager>().GetComponents<AudioSource>()[1].volume = musicVolume.value;
        FindObjectOfType<AudioManager>().GetComponents<AudioSource>()[0].volume = effectsVolume.value;

        pauseMenu.GetComponentInChildren<Slider>().value = AudioListener.volume;
    }
}
