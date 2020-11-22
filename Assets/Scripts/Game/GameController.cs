using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int Money = 0;
    public AudioClipGroup BackgroundMusic;

    private bool endLevel = false;

    private void Awake()
    {
        Events.OnSetMoney += OnSetMoney;
        Events.OnRequestMoney += OnRequestMoney;
        Events.OnHealthDestroyed += OnHealthDestroyed;
        Events.SetMoney(Money);
       
    }

    public void Start()
    {
        BackgroundMusic.PlayBackground();
    }

    private void OnDestroy()
    {
        Events.OnSetMoney -= OnSetMoney;
        Events.OnRequestMoney -= OnRequestMoney;
        Events.OnHealthDestroyed -= OnHealthDestroyed;
    }

    private void OnSetMoney(int amount)
    {
        Money = amount;
    }

    private int OnRequestMoney()
    {
        return Money;
    }

    void OnHealthDestroyed(GameObject go)
    {
        Structure[] structures = FindObjectsOfType<Structure>();
        Camp[] camps = FindObjectsOfType<Camp>();

        Camp camp = go.GetComponent<Camp>();
        Structure structure = go.GetComponent<Structure>();

        if (!endLevel && structures.Length == 1 && structure != null)
        {
            endLevel = true;
            Events.EndLevel(false);
        }
        if (!endLevel && camps.Length == 1 && camp != null)
        {
            endLevel = true;
            Events.EndLevel(true);
        }
    }

}
