using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class SkillPresenter : MonoBehaviour
{

    public SkillsData SkillsData;

    public TextMeshProUGUI CostText;
    // public TextMeshProUGUI ShortcutText;
    public Image IconImage;

    public Button button;



    private void Start()
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
        Events.OnSetMoney += OnSetMoney;
    }

    private void OnSetMoney(int value)
    {
        button.interactable = value >= SkillsData.Cost;
    }


    private void Update()
    {
        if (button.interactable && Input.GetKeyDown((KeyCode)Enum.Parse(typeof(KeyCode), SkillsData.Shortcut)))
        {
            Pressed();


        }
    }
    public void Pressed()
    {

        Events.SelectSkill(SkillsData);
        Events.RemoveMoney(SkillsData.Cost);
        Debug.Log("Pressed");
    }

}
