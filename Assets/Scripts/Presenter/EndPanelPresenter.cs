using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndPanelPresenter : MonoBehaviour
{
    public TextMeshProUGUI EndGameText;
    public Button Button;
    public AudioClipGroup WinSound;
    public AudioClipGroup LoseSound;

    private SceneLoader sceneLoader;

    private void Awake()
    {
        gameObject.SetActive(false);
        

        Events.OnEndLevel += OnEndLevel;
        Events.OnEndGame += OnEndGame;
    }

    private void OnDestroy()
    {
        Events.OnEndLevel -= OnEndLevel;
        Events.OnEndLevel -= OnEndGame;
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
        EndGameText.text = "Level Won";
        SetNextLevelButton();
        Button.onClick.AddListener(NextLevelAction);
        gameObject.SetActive(true);
        WinSound.StopBackground();
        WinSound.PlayBackground();
    }

    void LoseLevel()
    {
        EndGameText.text = "Level Lost";
        SetBackToMenuButton();
        Button.onClick.AddListener(GotoMenuAction);
        gameObject.SetActive(true);
        WinSound.StopBackground();
        LoseSound.PlayBackground();
     
    }

    void OnEndGame(bool isWin)
    {
        if (isWin)
        {
            WinGame();
        }
        else
        {
            LoseGame();
        }
    }

    void WinGame()
    {
        EndGameText.text = "VICTORY!";
        SetBackToMenuButton();
        Button.onClick.AddListener(GotoMenuAction);
        gameObject.SetActive(true);
        WinSound.StopBackground();
        WinSound.PlayBackground();
    }

    void LoseGame()
    {
        EndGameText.text = "LOST!";
        SetBackToMenuButton();
        Button.onClick.AddListener(GotoMenuAction);
        gameObject.SetActive(true);
        WinSound.StopBackground();
        LoseSound.PlayBackground();

    }

    void SetBackToMenuButton()
    {
        Button.GetComponentInChildren<Text>().text = "Back to Menu";
    }

    void SetNextLevelButton()
    {
        Button.GetComponentInChildren<Text>().text = "Next Level";
    }

    void GotoMenuAction()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("Menu");
    }

    void NextLevelAction()
    {
        gameObject.SetActive(false);
        sceneLoader.LoadNextLevel();
    }
}
