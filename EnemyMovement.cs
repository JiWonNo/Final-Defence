using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{

    private Transform target; //��ǥ : waypoint
    private int wavepointIndex = 0;

    private Enemy enemy;

    
    private void Start()
    {
        enemy = GetComponent<Enemy>();
        //WayPoints���� static���� ������ ����
        target = WayPoints.points[0]; //Enemy�� target���� waypoint�� ����
        
    }

    private void Update()
    {
        //Vector3�� x,y,z �������� ��Ʈ�����ֱ� ���� �ִ� ����̴�.
        //���⼭�� target�� ���� �������� �ֱ� ���� ����Ѵ�
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World); //�����ӿ� ���� ���ǵ� ����ȭ�� ���� �ڵ��̴�
        transform.LookAt(target);

        //���� WayPoint�� �����ߴٸ� ���� waypoint�� �̵��ϰ� �ϴ� �ڵ�
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWayPoint();
        }

        enemy.speed = enemy.startSpeed;
    }

    private void GetNextWayPoint()
    {
        //End Point�� WayPoint �������� ū���, ������Ʈ�� ����
        if (wavepointIndex >= WayPoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        wavepointIndex++;
        target = WayPoints.points[wavepointIndex];

    }

    void EndPath()
    {
        PlayerStats.lifes--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }



}
