using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static GameSettings Instance;

    public float BackgroundVolume
    {
        get { return PlayerPrefs.GetFloat("BVolume"); }
        set
        {
            PlayerPrefs.SetFloat("BVolume", value);
        }
    }

    public float EffectsVolume
    {
        get { return PlayerPrefs.GetFloat("EVolume"); }
        set
        {
            PlayerPrefs.SetFloat("EVolume", value);
        }
    }

    void Awake()
    {
        Instance = this;
    }
}
