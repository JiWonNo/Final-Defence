using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;                                //������ ���� ��ġ
    private Enemy targetEnemy;


    [Header("Ÿ�� Ư��")]
    public float range = 15f;                                //Ÿ�� ���� ����

    [Header("�߻�ü Ư��")]
    public GameObject bulletPrefab;
    public float fireRate = 1f;                              //�����ֱ�
    private float fireCountdown = 0f;                        //���� ī��Ʈ

    [Header("������")]
    public bool useLaser = false;

    public int damageOverTime = 30;
    public float slowAmount = 0.5f;

    public LineRenderer lineRenderer;
    public ParticleSystem impact;

    [Header("���� ���� �ʵ�")]
    public Transform towerRotate;                            //Ÿ�� ȸ��
    public float turnspeed = 10f;                            //ȸ�� �ӵ�

    
    public Transform firePoint;                              //���� ���� ������ġ

    SoundManager soundManager;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        soundManager = GameObject.FindObjectOfType<SoundManager>();
    }


    void UpdateTarget()                                      //������ �� �� ���� ����� ���� ã�� �Լ���
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            //�Ÿ��� ���� ª�� ���� ã�Ƴ���
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

        //���� �ٶ󺸰� ����
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
        //��ü ĳ����
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
        //���ݹ����� �����ϰ�, ������ �ٲ۴�
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
