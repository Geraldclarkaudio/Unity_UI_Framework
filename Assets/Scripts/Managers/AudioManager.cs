using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager Instance
    {
        get
        {
            if(instance == null)
            {
                Debug.LogError("AudioManager is null");
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] private AudioSource _musicAudioSource1;
    [SerializeField] private AudioSource _musicAudioSource2;
    [SerializeField] private AudioSource _sfxAudioSource1;
    [SerializeField] private AudioSource _sfxAudioSource2;

    public void PlaySwordSwingSFX(AudioClip clip)
    {
        _sfxAudioSource1.clip = clip;
        _sfxAudioSource1.Play();
    }
}
