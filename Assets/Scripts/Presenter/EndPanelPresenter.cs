using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndPanelPresenter : MonoBehaviour
{
    public TextMeshProUGUI EndGameText;
    public Button EndGameButton;
    public AudioClipGroup WinSound;
    //public AudioClipGroup LoseSound;

    private void Awake()
    {
        gameObject.SetActive(false);
        EndGameButton.onClick.AddListener(GotoMenu);

        Events.OnEndLevel += OnEndLevel;
    }

    private void OnDestroy()
    {
        Events.OnEndLevel -= OnEndLevel;
    }

    void OnEndLevel(bool isWin)
    {
        if (isWin)
        {
            WinLevel();
        } else
        {
            LoseLevel();
        }
    }


    void WinLevel()
    {
        EndGameText.text = "VICTORY!";
        gameObject.SetActive(true);
        WinSound.Play();
    }

    void LoseLevel()
    {
        EndGameText.text = "LOST!";
        gameObject.SetActive(true);
        //LoseSound.Play();
    }

    void GotoMenu()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("Menu");
    }
}
