using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Tutorial : MonoBehaviour
{
    private TextMeshProUGUI[] texts;

    private int index = 0;


    private void Awake()
    {
        texts = GetComponentsInChildren<TextMeshProUGUI>();
    }
    void Start()
    {
        foreach(TextMeshProUGUI text in texts)
        {
            text.gameObject.SetActive(false);
        }
        texts[0].gameObject.SetActive(true);
        Events.OnStructureBuilt += Events_OnStructureBuilt;
    }

    private void Events_OnStructureBuilt()
    {
        texts[index].gameObject.SetActive(false);
        if (++index < texts.Length)
        {
            texts[index].gameObject.SetActive(true);
        } else
        {
            Events.OnStructureBuilt -= Events_OnStructureBuilt;
        }
    }

    private void OnDestroy()
    {
        Events.OnStructureBuilt -= Events_OnStructureBuilt;
    }
}
