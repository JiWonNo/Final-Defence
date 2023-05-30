using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{

    private Transform target; //목표 : waypoint
    private int wavepointIndex = 0;

    private Enemy enemy;

    
    private void Start()
    {
        enemy = GetComponent<Enemy>();
        //WayPoints에서 static으로 지정한 이유
        target = WayPoints.points[0]; //Enemy의 target으로 waypoint로 지정
        
    }

    private void Update()
    {
        //Vector3는 x,y,z 움직임을 컨트롤해주기 위해 있는 기능이다.
        //여기서는 target에 따라 움직임을 주기 위해 사용한다
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World); //프레임에 따른 스피드 안정화를 위한 코드이다
        transform.LookAt(target);

        //만약 WayPoint에 도달했다면 다음 waypoint로 이동하게 하는 코드
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWayPoint();
        }

        enemy.speed = enemy.startSpeed;
    }

    private void GetNextWayPoint()
    {
        //End Point의 WayPoint 범위보다 큰경우, 오브젝트를 없앰
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
