using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class SkillDamageIncrease : MonoBehaviour
{
    public Bullet BulletPrefab;
    public SkillsData skillsData;
    public Button button;
    private bool buttonPressed = false;
    public Tower tower;
    void Start()
    {
        BulletPrefab.Damage = 1;
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
            BulletPrefab.Damage += 10;
            Debug.Log("Damage" + BulletPrefab.Damage);
            buttonPressed = false;
        }
    }
}

