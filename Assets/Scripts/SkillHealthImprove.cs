using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class SkillHealthImprove : MonoBehaviour
{
    public StructureData structure;
    public SkillsData skillsData;
    public Button button;
    private bool buttonPressed = false;
    void Start()
    {
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
            structure.Health += 5;
            Debug.Log("Health" + structure.Health);
            buttonPressed = false;
        }
    }
}
