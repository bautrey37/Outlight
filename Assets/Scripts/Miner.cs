using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miner : MonoBehaviour
{
    public float TimeBetweenCoin = 10f;
    private float NextCoinTime = 0;

    private void Update()
    {
        if (Time.time >= NextCoinTime)
        {
            NextCoinTime = Time.time + TimeBetweenCoin;
            Events.AddMoney(1);
        }
    }
}
