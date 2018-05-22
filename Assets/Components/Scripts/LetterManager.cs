using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterManager : MonoBehaviour
{
    public string letter;
    public AudioClip clip;



    public void CheckLetter()
    {

    }

    public void PlaySound()
    {
        SoundManager.instance.PlaySound(PickupManager.instance.source, clip);
    }
	
    public void DestroyLetter()
    {
        PlaySound();
        Destroy(gameObject);
    }

}
