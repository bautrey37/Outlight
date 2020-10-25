using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int Money = 0;

    private void Awake()
    {
        Events.OnSetMoney += OnSetMoney;
        Events.OnRequestMoney += OnRequestMoney;
    }

    public void Start()
    {
        Events.SetMoney(Money);
    }

    private void OnDestroy()
    {
        Events.OnSetMoney -= OnSetMoney;
        Events.OnRequestMoney -= OnRequestMoney;
    }

    private void OnSetMoney(int amount)
    {
        //Debug.Log("Money changed: " + amount);
        Money = amount;
    }

    private int OnRequestMoney()
    {
        return Money;
    }
}
