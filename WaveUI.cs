using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class WaveUI : MonoBehaviour
{
    public TextMeshProUGUI waveText;

    private int Maxwave;

    public GameObject gamemaster;

    void Start()
    {
        Maxwave = gamemaster.GetComponent<WaveSpawner>().waves.Length;
    }


    void Update()
    {
        waveText.text = PlayerStats.Rounds.ToString() + "/" + Maxwave.ToString();
    }
}
