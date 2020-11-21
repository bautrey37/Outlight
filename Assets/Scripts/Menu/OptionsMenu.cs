using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public static OptionsMenu Instance;

    private float optionsVolume;
    public float OptionsVolume
    {
        get { return this.optionsVolume; }
        set { Debug.Log(value);  this.optionsVolume = value; }
    }

    public void Awake()
    {
        Instance = this;
    }

}
