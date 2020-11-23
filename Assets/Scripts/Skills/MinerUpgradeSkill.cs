using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class MinerUpgradeSkill : MonoBehaviour
{
    public SkillsData skillsData;
    public Button button;
    private bool buttonPressed = false;
    public Miner miner;
    void Start()
    {
        
    }
    public void Awake()
    {
        miner.TimeBetweenCoin = 3f;
        button.onClick.AddListener(Pressed);
    }
    void Pressed()
    {
        buttonPressed = true;
    }
    void Update()
    {
        if (button.interactable && Input.GetKeyDown((KeyCode)Enum.Parse(typeof(KeyCode), skillsData.Shortcut)) || buttonPressed)
        {
            miner.TimeBetweenCoin -= 0.5f;
            Debug.Log("TimeBetweenCoin" + miner.TimeBetweenCoin);
            buttonPressed = false;
        }
    }
}
