using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool gameisOver;

    public GameObject gameOverUI;

    public GameObject completeLevelUI;

    SoundManager soundManager;

    private void Start()
    {
        gameisOver = false;
        soundManager = GameObject.FindObjectOfType<SoundManager>();
    }

    void Update()
    {
        if (gameisOver) return;



        if (PlayerStats.lifes <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        gameisOver = true;
        gameOverUI.SetActive(true);
        soundManager.MainAudio.Stop();
        soundManager.clips[7].Play();
        if (gameOverUI.activeSelf)
        {
            Time.timeScale = 0f;
        }
    }

    public void WinLevel()
    {
        gameisOver = true;
        completeLevelUI.SetActive(true);
        soundManager.MainAudio.Stop();
        soundManager.clips[6].Play();
    }
}
