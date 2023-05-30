using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class WaveSpawner : MonoBehaviour
{

    public static int EnemiesAlive;

    public Wave[] waves;

    public Transform spawnPoint;                               //적 생성 포인트

    public float timeBetweenWaves = 5f;                        //적 생성시간 주기
    public float countdown;                              //첫번째 적 생성대기시간

    public TextMeshProUGUI waveCountdownText;                  //웨이브 카운트다운 시간 텍스트

    private int waveIndex = 0;                                 //현재 웨이브

    public GameManager gameManager;

  

    private void Awake()
    {
        
        countdown = 15f;
        EnemiesAlive = 0;

    }


    private void Update()
    {
        if (EnemiesAlive == 1)
        {
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countdown);

        if (EnemiesAlive > 0)
        {
            return;
        }
        

        if (waveIndex == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

        if (countdown <= 0f)
        {
            StartCoroutine("SpawnWave");
            //SpawnWave();를 호출하고 countdown = timeBetweenWaves 로 시간을 초기화 해준다
            

            return;
        }
        

    }

    IEnumerator SpawnWave()                                    //웨이브 시작 시간 설정
    {
        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];

        EnemiesAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        waveIndex++;

        
    }

    private void SpawnEnemy(GameObject enemy)
    {
        //적 생성, start위치,회전값으로
        Instantiate(enemy, spawnPoint.position , spawnPoint.rotation);
    }

   
}
