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

    public Transform spawnPoint;                               //�� ���� ����Ʈ

    public float timeBetweenWaves = 5f;                        //�� �����ð� �ֱ�
    public float countdown;                              //ù��° �� �������ð�

    public TextMeshProUGUI waveCountdownText;                  //���̺� ī��Ʈ�ٿ� �ð� �ؽ�Ʈ

    private int waveIndex = 0;                                 //���� ���̺�

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
            //SpawnWave();�� ȣ���ϰ� countdown = timeBetweenWaves �� �ð��� �ʱ�ȭ ���ش�
            

            return;
        }
        

    }

    IEnumerator SpawnWave()                                    //���̺� ���� �ð� ����
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
        //�� ����, start��ġ,ȸ��������
        Instantiate(enemy, spawnPoint.position , spawnPoint.rotation);
    }

   
}
