using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "LevelSelect";
    public SceneFader sceneFader;

    public AudioClip btnClip;
    public AudioClip bgmClip;

    public AudioSource MainAudio;
    

    private void Start()
    {
        MainAudio = GetComponent<AudioSource>();
        MainAudio.clip = bgmClip;
        MainAudio.Play();
    }


    public void Play()
    {
        MainAudio.clip = btnClip;
        MainAudio.Play();
        sceneFader.FadeTo(levelToLoad);
    }

    public void Quit()
    {
        MainAudio.clip = btnClip;
        MainAudio.Play();
        Debug.Log("Exciting....");
        Application.Quit();
    }

  
}
