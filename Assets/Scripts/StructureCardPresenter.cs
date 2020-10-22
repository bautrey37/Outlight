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
    public TextMeshProUGUI ShortcutText;
    public Image IconImage;

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        if (button!=null)
        {
            button.onClick.AddListener(Pressed);
        }

        if (StructureData != null)
        {
            CostText.text = StructureData.Cost.ToString();
            ShortcutText.text = StructureData.Shortcut;
            IconImage.sprite = StructureData.Icon;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown((KeyCode)Enum.Parse(typeof(KeyCode), StructureData.Shortcut)))
        {
            Pressed();
        }
    }
    public void Pressed()
    {
        Events.SelectStructure(StructureData);
    }

}
