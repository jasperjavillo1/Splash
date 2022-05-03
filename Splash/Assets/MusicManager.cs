using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioClip themeSong;

    //string currentScene = currentScene.name;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().PlayMusic(themeSong, true);
    }


    // Update is called once per frame
    void Update()
    {

    }
}
