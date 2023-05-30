using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 400;

    public static int lifes;
    public int startLifes = 20;

    public static int Rounds;

    private void Start()
    {
        Money = startMoney;
        lifes = startLifes;

        Rounds = 0;
    }




}
