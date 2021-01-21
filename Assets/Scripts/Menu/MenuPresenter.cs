using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPresenter : MonoBehaviour
{
    public MainMenu MainMenu;
    public LevelsMenu LevelsMenu;
    public OptionsMenu OptionsMenu;
    public AudioClipGroup MenuBackgroundSound;
    public AudioClipGroup ButtonClickSound;

    public void Start()
    {
        MenuBackgroundSound.PlayBackground();
        Button[] buttons = GetComponentsInChildren<Button>(true);
        foreach (Button b in buttons)
        {
            b.onClick.AddListener(PlayButtonSound);
        }

    }

    void PlayButtonSound()
    {
        ButtonClickSound.Play();
    }
    /*
     * Tried to get animation to close and open different panels, but it was tricky to get working
     */

    //public void OpenMainMenu()
    //{
    //    if (gameObject.activeSelf)
    //        return;

    //    MainMenu.enabled = true;
    //    MainMenu.OpeningAnimation.enabled = true;
    //}

    //public void OpenLevelsMenu()
    //{
    //    if (LevelsMenu.enabled)
    //        return;

    //    MainMenu.ClosingAnimation.enabled = true;
    //    MainMenu.enabled = false;

    //    LevelsMenu.OpeningAnimation.enabled = true;
    //    LevelsMenu.enabled = true;
    //}

    //public void OpenOptionsMenu()
    //{

    //}

    //public void Close()
    //{
    //    if (!gameObject.activeSelf)
    //        return;

    //    ClosingAnimation.enabled = true;
    //}

    //public void CloseFinished()
    //{
    //    gameObject.SetActive(false);
    //}
}
