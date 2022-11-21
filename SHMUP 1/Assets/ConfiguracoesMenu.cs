using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ConfiguracoesMenu : MonoBehaviour {

    public AudioMixer audioMixer;

    public void SetVolume(float volume) {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetVolumeEfe(float volume)
    {
        audioMixer.SetFloat("volumeEfe", volume);
    }

    public void SetVolumeMus(float volume)
    {
        audioMixer.SetFloat("volumeMus", volume);
    }
}
