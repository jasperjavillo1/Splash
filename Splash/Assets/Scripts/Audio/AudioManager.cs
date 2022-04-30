using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    [SerializeField] AudioSource effectPlayer, musicPlayer;

    //  all of the AudioClips that are currently playing
    readonly List<AudioClip> playedClips = new List<AudioClip>();
    
    private GameObject[] audioManagers;
    private void Awake() {
        StartCoroutine(RefreshPlaylist());
        
        audioManagers = GameObject.FindGameObjectsWithTag("AudioManager");

        if (audioManagers.Length > 1)
        {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(transform.gameObject);

    }

    //  plays a sound effect
    public void PlaySound(AudioClip clip, bool randomize = true) {
        foreach(var i in playedClips) {
            if(i == clip)
                return;
        }

        if(randomize)
            RandomizePitch();
        effectPlayer.PlayOneShot(clip);
        playedClips.Add(clip);
    }
    //  plays music
    public void PlayMusic(AudioClip clip, bool repeat) {
        if(!repeat)
            effectPlayer.PlayOneShot(clip);
        else
            StartCoroutine(MusicRepeater(clip));
    }

    //  randomizes the pitch of the audio player
    public void RandomizePitch() {
        effectPlayer.pitch = Random.Range(0.6f, 1.25f);
    }

    //  clears all of the playing clips after every frame
    IEnumerator RefreshPlaylist() {
        yield return new WaitForEndOfFrame();

        playedClips.Clear();
        StartCoroutine(RefreshPlaylist());
    }

    //  plays music on repeat
    IEnumerator MusicRepeater(AudioClip clip) {
        musicPlayer.PlayOneShot(clip);

        yield return new WaitForSeconds(clip.length);

        StartCoroutine(MusicRepeater(clip));
    }
}

