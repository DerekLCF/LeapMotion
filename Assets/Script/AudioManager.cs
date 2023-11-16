using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioClip[] SFX;
    public AudioSource BGM_Source;
    public AudioSource SFX_Source;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }

    }

    public void PlayMusic(int ID) {
        SFX_Source.PlayOneShot(SFX[ID]);

    }

    public void SetMusic( float vol)
    {
        BGM_Source.volume = vol;
        SFX_Source.volume = vol;
    }

}
