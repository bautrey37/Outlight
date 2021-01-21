using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class ShootDelayDecreaseSkill : MonoBehaviour
{
    public SkillsData skillsData;
    public Button button;
    private bool buttonPressed = false;
    public Tower tower;
    void Start()
    {
        tower.ShootDelay = 1f;
        button.onClick.AddListener(Pressed);
    }

    void Pressed()
    {
        buttonPressed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (button.interactable && Input.GetKeyDown((KeyCode)Enum.Parse(typeof(KeyCode), skillsData.Shortcut)) || buttonPressed)
        {
            tower.ShootDelay -= 0.05f;
            Debug.Log("Delay" + tower.ShootDelay);
            buttonPressed = false;
        }
    }
}
