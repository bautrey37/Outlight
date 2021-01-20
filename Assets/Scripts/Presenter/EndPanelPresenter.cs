using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EndPanelPresenter : MonoBehaviour
{
    public TextMeshProUGUI EndText;
    public Button Button;
    public AudioClipGroup WinSound;
    public AudioClipGroup LoseSound;

    private SceneLoader sceneLoader;

    private void Awake()
    {
        gameObject.SetActive(false);

        Events.OnEndLevel += OnEndLevel;
    }

    private void Start()
    {
        sceneLoader = gameObject.GetComponent<SceneLoader>();
    }

    private void OnDestroy()
    {
        Events.OnEndLevel -= OnEndLevel;
    }

    void OnEndLevel(bool isWin)
    {
        if (gameObject.activeSelf) return;

        if (isWin)
        {
            sceneLoader = gameObject.GetComponent<SceneLoader>();
            // if last level is won, win game
            if (sceneLoader.IsLastLevel())
            {
                WinGame();
            }
            else
            {
                WinLevel();
            }
        }
        else
        {
            LoseLevel();
        }
    }

    void WinLevel()
    {
        EndText.text = "Level Won";
        SetNextLevelButton();
        Button.onClick.AddListener(NextLevelAction);
        gameObject.SetActive(true);

        WinSound.StopBackground();
        WinSound.Play();
    }

    void LoseLevel()
    {
        EndText.text = "Level Lost";
        SetBackToMenuButton();
        Button.onClick.AddListener(GotoMenuAction);
        gameObject.SetActive(true);

        WinSound.StopBackground();
        LoseSound.Play();
     
    }

    void WinGame()
    {
        EndText.text = "VICTORY!";
        SetBackToMenuButton();
        Button.onClick.AddListener(GotoMenuAction);
        gameObject.SetActive(true);

        WinSound.StopBackground();
        WinSound.Play();
    }

    void SetBackToMenuButton()
    {
        Button.GetComponentInChildren<TextMeshProUGUI>().text = "Back to Menu";
    }

    void SetNextLevelButton()
    {
        Button.GetComponentInChildren<TextMeshProUGUI>().text = "Next Level";
    }

    void GotoMenuAction()
    {
        gameObject.SetActive(false);

        sceneLoader.LoadMenu();
    }

    void NextLevelAction()
    {
        gameObject.SetActive(false);

        sceneLoader.LoadNextLevel();
    }
}
