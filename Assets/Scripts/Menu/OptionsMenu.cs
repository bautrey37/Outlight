using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public static OptionsMenu Instance;

    public float MusicVolume
    {
        get { return GameSettings.Instance.MusicVolume; }
        set { GameSettings.Instance.MusicVolume = value; }
    }

    public float InteractionVolume
    {
        get { return GameSettings.Instance.InteractionVolume; }
        set { GameSettings.Instance.InteractionVolume = value; }
    }

    private void Awake()
    {
        Instance = this;
    }
}
