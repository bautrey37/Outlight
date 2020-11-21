using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Slider MusicVolume;
    public Slider InteractionVolume;

    private void Start()
    {
        MusicVolume.value = GameSettings.Instance.MusicVolume;
        InteractionVolume.value = GameSettings.Instance.InteractionVolume;
    }
}
