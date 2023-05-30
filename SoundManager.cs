using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource MainAudio;
    public AudioSource[] clips; 


    void Start()
    {
        MainAudio.Play();
    }

    
    public void Mute()
    {
        MainAudio.mute = true;
    }

    
}
