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
    public bool passedVolume = false;

    void Update()
    {
        if (passedVolume)
        {
            AudioListener.volume = masterVolume.value;
            pauseMenu.GetComponentInChildren<Slider>().value = AudioListener.volume;
            
            FindObjectOfType<AudioManager>().GetComponents<AudioSource>()[1].volume = musicVolume.value;
            FindObjectOfType<AudioManager>().GetComponents<AudioSource>()[0].volume = effectsVolume.value;

            //PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        }
    }


    private void OnEnable()
    {
        if (passedVolume)
        {
            AudioListener.volume = masterVolume.GetComponentInChildren<Slider>().value;

            FindObjectOfType<AudioManager>().GetComponents<AudioSource>()[1].volume = musicVolume.value;
            FindObjectOfType<AudioManager>().GetComponents<AudioSource>()[0].volume = effectsVolume.value;

        }
        else
        {
            masterVolume.GetComponentInChildren<Slider>().value = AudioListener.volume;

            musicVolume.value = FindObjectOfType<AudioManager>().GetComponents<AudioSource>()[1].volume;
            effectsVolume.value = FindObjectOfType<AudioManager>().GetComponents<AudioSource>()[0].volume;

        }
        passedVolume = true;
    }
}
