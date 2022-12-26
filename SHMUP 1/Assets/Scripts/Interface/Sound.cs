using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound {

    public string name;

    public AudioClip clip;

    public AudioMixerGroup audioMixer;

    [Range(0f, 1f)]
    public float volume;
    [Range(0f, 1f)]
    public float volumeVariance;

    [Range(.1f, 3f)]
    public float pitch;
    [Range(.1f, 3f)]
    public float pitchVariance;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}

