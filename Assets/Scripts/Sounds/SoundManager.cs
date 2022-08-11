using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip clip;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);    
    }

    private void Start()
    {
        if (audioSource.isPlaying) Play(clip);
    }

    private void Play(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
