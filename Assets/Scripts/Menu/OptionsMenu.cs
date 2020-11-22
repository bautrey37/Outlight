using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Slider BackgroundVolume;
    public Slider EffectsVolume;

    private void Start()
    {
        BackgroundVolume.value = GameSettings.Instance.BackgroundVolume;
        EffectsVolume.value = GameSettings.Instance.EffectsVolume;
    }
}
