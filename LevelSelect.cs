using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public SceneFader Fader;

    public Button[] levelBtn;

    int levelReached;

    public AudioSource selectBtn;
    public AudioClip btnclip;

    private void Start()
    {
        levelReached = PlayerPrefs.GetInt("levelReached",1);

        for (int i = 0; i < levelBtn.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                levelBtn[i].interactable = false;
            }

        }

        
    }

    public void Select(string levelName)
    {
        selectBtn.clip = btnclip;
        selectBtn.Play();
        Fader.FadeTo(levelName);
    }

    
}
