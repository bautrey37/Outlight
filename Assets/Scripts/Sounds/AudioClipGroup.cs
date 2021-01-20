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

    public AudioSource backgroundSource;
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

        source.volume = Random.Range(VolumeMin, VolumeMax) * GameSettings.Instance.EffectsVolume;
        source.pitch = Random.Range(PitchMin, PitchMax);
        source.clip = Clips[Random.Range(0, Clips.Count)];
        source.Play();
    }

    public void PlayBackground()
    {
        if (AudioSourcePool.Instance == null) return;
        if (Clips.Count <= 0) return;

        backgroundSource = AudioSourcePool.Instance.GetSource();
        backgroundSource.volume = GameSettings.Instance.BackgroundVolume;
        backgroundSource.pitch = 1;
        backgroundSource.clip = Clips[Random.Range(0, Clips.Count)];
        backgroundSource.PlayDelayed(1.5f);

        backgroundSource.loop = backgroundSource.isPlaying;
    }

    // TODO: put background music in a persisted state, not in teh clip file
    public void StopBackground()
    {
        Debug.Log("StopBackground1");
        if (backgroundSource == null) return;
        Debug.Log("StopBackground2");
        backgroundSource.Stop();
    }

}
