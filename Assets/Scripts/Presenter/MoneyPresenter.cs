using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class MoneyPresenter : MonoBehaviour
{
    public TextMeshProUGUI moneyText;

    private void Awake()
    {
        Events.OnSetMoney += SetMoney;
    }

    private void SetMoney(int value)
    {
        moneyText.text = value.ToString();
    }

    private void OnDestroy()
    {
        Events.OnSetMoney -= SetMoney;
    }
}
