using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class StructureCardPresenter : MonoBehaviour
{
    public StructureData StructureData;

    public TextMeshProUGUI CostText;
    // public TextMeshProUGUI ShortcutText;
    public Image IconImage;
    public Button button;


    private void Awake()
    {
        Events.OnSetMoney += OnSetMoney;
    }

    private void OnDestroy()
    {
        Events.OnSetMoney -= OnSetMoney;
    }

    private void Start()
    {
        button = GetComponent<Button>();
        if (StructureData != null)
        {
            CostText.text = StructureData.Cost.ToString();
            // ShortcutText.text = StructureData.Shortcut;
            IconImage.sprite = StructureData.Icon;
        }
        button.onClick.AddListener(Pressed);
    }

    private void OnSetMoney(int value)
    {
        button.interactable = value >= StructureData.Cost;
    }

    private void Update()
    {
        if (button.interactable && Input.GetKeyDown((KeyCode)Enum.Parse(typeof(KeyCode), StructureData.Shortcut)))
        {
            Pressed();
        }
    }
    public void Pressed()
    {
        Events.SelectStructure(StructureData);
    }

}
