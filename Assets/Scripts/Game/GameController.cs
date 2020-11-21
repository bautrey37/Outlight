using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int Money = 0;
    public AudioClipGroup BackgroundMusic;
    private bool EndLevel = false;

    private void Awake()
    {
        Events.OnSetMoney += OnSetMoney;
        Events.OnRequestMoney += OnRequestMoney;
        Events.OnHealthDestroyed += OnHealthDestroyed;
        Events.SetMoney(Money);
       
    }

    public void Start()
    {
        BackgroundMusic.Play();
    }
    public void Update()
    {
      
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

        if (structures.Length == 1 && structure != null)
        {
            Events.EndLevel(false);
        }
        if (camps.Length == 1 && camp != null)
        {
            Events.EndLevel(true);
        }
    }

}
