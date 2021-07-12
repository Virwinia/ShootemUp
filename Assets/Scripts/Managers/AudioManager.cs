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
