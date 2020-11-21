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
    private void Awake()
    {
        gameObject.SetActive(false);
        EndGameButton.onClick.AddListener(RestartGame);

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
        Debug.Log("Level Won");
        EndGameText.text = "VICTORY!";
        gameObject.SetActive(true);
        WinSound.Play();
    }

    void LoseLevel()
    {
        Debug.Log("Level Lost");
        EndGameText.text = "LOST!";
        gameObject.SetActive(true);
    }

    void RestartGame()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
