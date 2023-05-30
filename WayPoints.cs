using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    public static Transform[] points;

    private void Awake()
    {
        //WayPoints의 자식을 배열에 담아줌
        points = new Transform[transform.childCount];

        for (int i = 0; i < points.Length; i++)
        {
            //WayPoints의 자식으로 있는 WayPoint의 개수 만큼 값이 들어간다
            points[i] = transform.GetChild(i);
        }
    }



}
