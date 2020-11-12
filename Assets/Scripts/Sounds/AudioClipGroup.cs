using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/AudioClipGroup")]
public class AudioClipGroup : ScriptableObject
{
    [Range(0, 2)]
    public float VolumeMin = 1;
    [Range(0, 2)]
    public float VolumeMax = 1;
    [Range(0, 2)]
    public float PitchMin = 1;
    [Range(0, 2)]
    public float PitchMax = 1;
    public float Cooldown = 0.1f;

    public List<AudioClip> Clips;

    private float timestamp;

    private void OnEnable()
    {
        timestamp = 0;
    }

    public void Play()
    {
        if (AudioSourcePool.Instance == null) return;

        Play(AudioSourcePool.Instance.GetSource());
    }

    public void Play(AudioSource source)
    {
        if (timestamp > Time.time) return;
        if (Clips.Count <= 0) return;

        timestamp = Time.time + Cooldown;

        source.volume = Random.Range(VolumeMin, VolumeMax);
        source.pitch = Random.Range(PitchMin, PitchMax);
        source.clip = Clips[Random.Range(0, Clips.Count)];
        source.Play();
    }
}
