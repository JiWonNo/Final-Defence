using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    //waypoint�� ���� �������� �ϹǷ�, target�� waypoint�� ����
    //move Speed
    public float startSpeed = 10f;

    [HideInInspector]
    public float speed;
    public float startHealth = 100;
    private float health;
    public int myMoney = 50;

    public GameObject deathEffect;

    [Header("ü�¹�")]
    public Image healthBar;

    private bool isDead = false;

    SoundManager soundManager;
    
    private void Start()
    {
        speed = startSpeed;
        health = startHealth;
        soundManager = GameObject.FindObjectOfType<SoundManager>();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }

    void Die()
    {
        isDead = true;

        PlayerStats.Money += myMoney;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        soundManager.clips[5].Play();
        Destroy(effect, 2f);

        WaveSpawner.EnemiesAlive--;

        Destroy(gameObject);
    }

    



}
