using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioClip themeSong;
    [SerializeField] AudioClip battleMusic;
    [SerializeField] AudioClip victoryClip;

    private bool battleMusicStart = false;
    private GameObject boss;
    private bool hasBoss = false;
    private bool boss1, boss2, boss3, bossT;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<AudioManager>().GetComponents<AudioSource>()[1].isPlaying == false && hasBoss == false)
        {
            FindObjectOfType<AudioManager>().GetComponents<AudioSource>()[1].clip = themeSong;
            FindObjectOfType<AudioManager>().GetComponents<AudioSource>()[1].Play();
            Debug.Log("Main Music Restarted");

        }

        if (hasBoss && boss1)
        {
            
            if(FindObjectOfType<AudioManager>().GetComponents<AudioSource>()[1].isPlaying == false)
            {
                FindObjectOfType<AudioManager>().GetComponents<AudioSource>()[1].Play();
                Debug.Log("Boss Music Restarted");

            }

            if (boss.GetComponent<Boss1>().health <= 0)
            {
                FindObjectOfType<AudioManager>().GetComponents<AudioSource>()[1].Stop();
                FindObjectOfType<AudioManager>().GetComponents<AudioSource>()[1].clip = victoryClip;
                FindObjectOfType<AudioManager>().GetComponents<AudioSource>()[1].Play();

                //FindObjectOfType<AudioManager>().PlayMusic(themeSong, true);
                hasBoss = false;
            }
        }
        if (hasBoss && boss2)
        {
            if (boss.GetComponent<Boss2>().health <= 0)
            {
                FindObjectOfType<AudioManager>().GetComponents<AudioSource>()[1].Stop();
                FindObjectOfType<AudioManager>().GetComponents<AudioSource>()[1].clip = victoryClip;
                FindObjectOfType<AudioManager>().GetComponents<AudioSource>()[1].Play();

                //FindObjectOfType<AudioManager>().PlayMusic(themeSong, true);
                hasBoss = false;
            }
        }
        if (hasBoss && boss3)
        {
            if (boss.GetComponent<Boss3>().health <= 0)
            {
                FindObjectOfType<AudioManager>().GetComponents<AudioSource>()[1].Stop();
                FindObjectOfType<AudioManager>().GetComponents<AudioSource>()[1].clip = victoryClip;
                FindObjectOfType<AudioManager>().GetComponents<AudioSource>()[1].Play();

                //FindObjectOfType<AudioManager>().PlayMusic(themeSong, true);
                hasBoss = false;
            }
        }
        if (hasBoss && bossT)
        {
            if (boss.GetComponent<TutorialBoss>().health <= 0)
            {
                FindObjectOfType<AudioManager>().GetComponents<AudioSource>()[1].Stop();
                FindObjectOfType<AudioManager>().GetComponents<AudioSource>()[1].clip = victoryClip;
                FindObjectOfType<AudioManager>().GetComponents<AudioSource>()[1].Play();

                //FindObjectOfType<AudioManager>().PlayMusic(themeSong, true);
                hasBoss = false;
            }
        }
    }

    private void Awake()
    {
        //FindObjectOfType<AudioManager>().PlayMusic(themeSong, true);

        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            boss = FindObjectOfType<Boss1>().gameObject;
            hasBoss = true;
            boss1 = true;
        }
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            boss = FindObjectOfType<Boss3>().gameObject;
            hasBoss = true;
            boss3 = true;
        }
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            boss = FindObjectOfType<Boss2>().gameObject;
            hasBoss = true;
            boss2 = true;
        }
        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            boss = FindObjectOfType<TutorialBoss>().gameObject;
            hasBoss = true;
            bossT = true;
        }
        if (SceneManager.GetActiveScene().buildIndex < 3 || SceneManager.GetActiveScene().buildIndex > 6)
        {
            boss = gameObject;
            hasBoss = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("DisablePlayerCost") && hasBoss)
        {
            if (battleMusicStart == false)
            {
                FindObjectOfType<AudioManager>().GetComponents<AudioSource>()[1].Stop();
                //FindObjectOfType<AudioManager>().PlayMusic(battleMusic, true);
                FindObjectOfType<AudioManager>().GetComponents<AudioSource>()[1].clip = battleMusic;
                FindObjectOfType<AudioManager>().GetComponents<AudioSource>()[1].Play();

                battleMusicStart = true;
            }

        }
    }
}
