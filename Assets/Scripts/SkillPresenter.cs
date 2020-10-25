using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class SkillPresenter : MonoBehaviour { 

public SkillsData SkillsData;

public TextMeshProUGUI CostText;
// public TextMeshProUGUI ShortcutText;
public Image IconImage;

private Button button;

private void Awake()
{
    button = GetComponent<Button>();
    if (button != null)
    {
        button.onClick.AddListener(Pressed);
    }

    if (SkillsData != null)
    {
        CostText.text = SkillsData.Cost.ToString();
        // ShortcutText.text = StructureData.Shortcut;
        IconImage.sprite = SkillsData.Icon;
    }
}

private void Update()
{
    if (Input.GetKeyDown((KeyCode)Enum.Parse(typeof(KeyCode), SkillsData.Shortcut)))
    {
        Pressed();
    }
}
public void Pressed()
{
     Debug.Log("Pressed");
     Events.SelectSkill(SkillsData);
}

}
