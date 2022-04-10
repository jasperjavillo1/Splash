using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    [SerializeField] AudioSource effectPlayer, musicPlayer;

    //  all of the AudioClips that are currently playing
    List<AudioClip> playedClips = new List<AudioClip>();


    private void Awake() {
        StartCoroutine(refreshPlaylist());
    }

    //  plays a sound effect
    public void playSound(AudioClip clip, bool randomize = true) {
        foreach(var i in playedClips) {
            if(i == clip)
                return;
        }

        if(randomize)
            randomizePitch();
        effectPlayer.PlayOneShot(clip);
        playedClips.Add(clip);
    }
    //  plays music
    public void playMusic(AudioClip clip, bool repeat) {
        if(!repeat)
            effectPlayer.PlayOneShot(clip);
        else
            StartCoroutine(musicRepeater(clip));
    }

    //  randomizes the pitch of the audio player
    public void randomizePitch() {
        effectPlayer.pitch = Random.Range(0.6f, 1.25f);
    }

    //  clears all of the playing clips after every frame
    IEnumerator refreshPlaylist() {
        yield return new WaitForEndOfFrame();

        playedClips.Clear();
        StartCoroutine(refreshPlaylist());
    }

    //  plays music on repeat
    IEnumerator musicRepeater(AudioClip clip) {
        musicPlayer.PlayOneShot(clip);

        yield return new WaitForSeconds(clip.length);

        StartCoroutine(musicRepeater(clip));
    }
}
