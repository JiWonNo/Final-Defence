using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompleteLevel : MonoBehaviour
{
    public string menuSceneName = "MainMenu";

    public SceneFader fader;

    public string nextLevel = "LevelSelect";
    public static int levelToLock = 1;

    public void Continue()
    {
        levelToLock++;
        PlayerPrefs.SetInt("levelReached", levelToLock);
        fader.FadeTo(nextLevel);
    }



    public void Menu()
    {
        fader.FadeTo(menuSceneName);
    }


}
