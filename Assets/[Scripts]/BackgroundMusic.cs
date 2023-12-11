using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioClip defaultBackgroundMusic; 
    public AudioClip gameOverBackgroundMusic;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.clip = defaultBackgroundMusic;
        audioSource.Play(); 
    }

    public void PlayGameOverMusic()
    {
        audioSource.clip = gameOverBackgroundMusic; 
        audioSource.Play();
    }
}
