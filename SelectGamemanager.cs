using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectGamemanager : MonoBehaviour
{
    public static SelectGamemanager instance;

    public AudioSource MainAudio;

    public AudioClip bgmclip;
    public AudioClip btnclip;

    public SceneFader fader;
    public string menuSceneName = "MainMenu";

    void Start()
    {
        MainAudio = GetComponent<AudioSource>();
        MainAudio.clip = bgmclip;
        MainAudio.Play();
    }

    public void Menu()
    {
        MainAudio.clip = btnclip;
        MainAudio.Play();
        fader.FadeTo(menuSceneName);
    }


    void Update()
    {
        
    }
}
