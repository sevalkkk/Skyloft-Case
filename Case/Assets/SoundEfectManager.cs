using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEfectManager : MonoBehaviour
{
    public static SoundEfectManager instance;
    public AudioSource audioSource;
    public AudioClip[] clips;
    public bool isSoundOff;
   
    public bool isMusicOff;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        audioSource = GetComponent<AudioSource>();
    


    }


    public void PlayAudioClip(AudioClip audio)
    {
        
        AudioClip clip = audioSource.GetComponent<AudioClip>();
        clip = audio;
        if (!isSoundOff) audioSource.PlayOneShot(clip);
      
    }
}
