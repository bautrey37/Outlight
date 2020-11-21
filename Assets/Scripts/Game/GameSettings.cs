using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static GameSettings Instance;

    private float musicVolume;
    public float MusicVolume
    {
        get { return musicVolume; }
        set { musicVolume = value; }
    }

    private float interactionVolume;
    public float InteractionVolume
    {
        get { return interactionVolume; }
        set { interactionVolume = value; }
    }

    void Awake()
    {
        Instance = this;

        MusicVolume = 1;
        InteractionVolume = 1;
    }
}
