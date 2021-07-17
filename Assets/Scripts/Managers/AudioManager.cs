/* 
--- Audio List ---
0. reload - to use when starting the game or ship respawns
1. laser shot
2. explosion/hit
3. explosion/death
4. game over
5. collect coin
6. collect powerup
7. shield up
8. shield down

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager audioManagerInstance;

    public AudioSource audioSource;
    [SerializeField] AudioClip[] clips;

    private void Awake()
    {
        audioManagerInstance = this;
    }

    public void PlaySound(int n)
    {
        if (audioSource != null)
        {
            audioSource.clip = clips[n];
            audioSource.pitch = Random.Range(0.9f, 1.1f);
            float volume = Random.Range(0.8f, 1f);
            audioSource.PlayOneShot(clips[n], volume);
        }

    }

    // public void PlayRandomSoundFromlist(AudioClip[] sounds)
    // {
    //     int n = Random.Range(0, sounds.Length);
    //     audioSource.clip = sounds[n];
    //     audioSource.volume = Random.Range(0.8f, 1f);
    //     audioSource.pitch = Random.Range(0.9f, 1.1f);
    //     audioSource.PlayOneShot(sounds[n]);

    // }

    // void PlayThisSound(AudioClip sound)
    // {
    //     audioSource.clip = sound;
    //     audioSource.volume = Random.Range(0.8f, 1f);
    //     audioSource.pitch = Random.Range(0.9f, 1.1f);
    //     audioSource.Play();
    // }

    // void StopThisSound(AudioClip sound)
    // {
    //     audioSource.clip = sound;
    //     audioSource.Stop();
    // }
}
