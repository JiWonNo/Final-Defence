using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;                                //공격할 적의 위치
    private Enemy targetEnemy;


    [Header("타워 특성")]
    public float range = 15f;                                //타워 공격 범위

    [Header("발사체 특성")]
    public GameObject bulletPrefab;
    public float fireRate = 1f;                              //공격주기
    private float fireCountdown = 0f;                        //공격 카운트

    [Header("레이저")]
    public bool useLaser = false;

    public int damageOverTime = 30;
    public float slowAmount = 0.5f;

    public LineRenderer lineRenderer;
    public ParticleSystem impact;

    [Header("통합 설정 필드")]
    public Transform towerRotate;                            //타워 회전
    public float turnspeed = 10f;                            //회전 속도

    
    public Transform firePoint;                              //공격 무기 생성위치

    SoundManager soundManager;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        soundManager = GameObject.FindObjectOfType<SoundManager>();
    }


    void UpdateTarget()                                      //지정한 적 중 가장 가까운 적을 찾는 함수다
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            //거리가 가장 짧은 적을 찾아낸다
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
    }

    private void Update()
    {
        if (target == null)
        {
            if (useLaser)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    soundManager.clips[2].Stop();
                    impact.Stop();
                }
            }


            return;
        }

        //적을 바라보고 고정
        LockOnTarget();

        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }

        
    }

    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(towerRotate.rotation, lookRotation, Time.deltaTime * turnspeed).eulerAngles;
        towerRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Laser()
    {
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(slowAmount);

        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            soundManager.clips[2].Play();
            impact.Play();
        }

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;
        impact.transform.position = target.position + dir.normalized;
        impact.transform.rotation = Quaternion.LookRotation(dir);
    }

    void Shoot()
    {
        //객체 캐스팅
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if (this.gameObject.tag == "FireBall")
        {
            
            soundManager.clips[4].Play();
            
        }

        if (this.gameObject.tag == "Arrow")
        {
            
            soundManager.clips[3].Play();
            
        }

        if (bullet != null)
        {
            bullet.Seek(target);
        }

        
    }

    private void OnDrawGizmosSelected()
    {
        //공격범위를 지정하고, 색깔을 바꾼다
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
