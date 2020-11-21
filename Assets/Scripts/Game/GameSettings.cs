using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static GameSettings Instance;

    public float MusicVolume
    {
        get { return PlayerPrefs.GetFloat("IVolume"); }
        set
        {
            PlayerPrefs.SetFloat("MVolume", value);
        }
    }

    public float InteractionVolume
    {
        get { return PlayerPrefs.GetFloat("IVolume"); }
        set
        {
            PlayerPrefs.SetFloat("IVolume", value);
        }
    }

    void Awake()
    {
        Instance = this;
    }
}
