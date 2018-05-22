using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource source;
    AudioClip clip;

    public static SoundManager instance;

    private void Start()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySound(AudioSource player, AudioClip sound)
    {
        source = player;
        source.clip = sound;
        source.Play();
    }

    

    
	
}
