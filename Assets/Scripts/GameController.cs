using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject EndGamePanel;
    public TextMeshProUGUI EndGameText;
    public Button EndGameButton;
    public int Money = 0;

    private void Awake()
    {
        Events.OnSetMoney += OnSetMoney;
        Events.OnRequestMoney += OnRequestMoney;
        Events.OnHealthDestroyed += OnHealthDestroyed;

        EndGamePanel.SetActive(false);
        EndGameButton.onClick.AddListener(RestartGame);
    }

    public void Start()
    {
        Events.SetMoney(Money);
    }

    private void OnDestroy()
    {
        Events.OnSetMoney -= OnSetMoney;
        Events.OnRequestMoney -= OnRequestMoney;
        Events.OnHealthDestroyed -= OnHealthDestroyed;
    }

    private void OnSetMoney(int amount)
    {
        //Debug.Log("Money changed: " + amount);
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
            LoseLevel();
        }
        if (camps.Length == 1 && camp != null)
        {
            WinLevel();
        }
    }
    
    void WinLevel()
    {
        Debug.Log("Level Won");
        EndGameText.text = "VICTORY!";
        EndGamePanel.SetActive(true);
    }

    void LoseLevel()
    {
        Debug.Log("Level Lost");
        EndGameText.text = "LOST!";
        EndGamePanel.SetActive(true);
    }

    void RestartGame()
    {
        // TODO change scene name in a better way
        SceneManager.LoadScene("BrandonScene");
    }
}
