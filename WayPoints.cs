using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    public static Transform[] points;

    private void Awake()
    {
        //WayPoints�� �ڽ��� �迭�� �����
        points = new Transform[transform.childCount];

        for (int i = 0; i < points.Length; i++)
        {
            //WayPoints�� �ڽ����� �ִ� WayPoint�� ���� ��ŭ ���� ����
            points[i] = transform.GetChild(i);
        }
    }



}
