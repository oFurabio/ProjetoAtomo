using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ConfiguracoesMenu : MonoBehaviour {
    public Slider volume;
    public Slider volumeEfe;
    public Slider volumeMus;

    public AudioMixer audioMixer;

    float dbVolume, dbVolumeEfe, dbVolumeMus;
    float volumeSlider, volumeEfeSlider, volumeMusSlider;

    public GameObject contaFPS;

    private void Start() {
        volumeSlider = 1;
        volumeEfeSlider = 1;
        volumeMusSlider = 1;

        LoadPrefs();
    }

    public void SetVolume(float decimalVolume) {
        dbVolume = Mathf.Log10(decimalVolume) * 20;
        
        if (decimalVolume == 0.0f)
            dbVolume = -80.0f;

        volumeSlider = volume.value;
        PlayerPrefs.SetFloat("sliderGer", volumeSlider);

        audioMixer.SetFloat("volume", dbVolume);
        PlayerPrefs.SetFloat("volume", dbVolume);
    }

    public void SetVolumeMus(float decimalVolume) {
        dbVolumeMus = Mathf.Log10(decimalVolume) * 20;
        
        if (decimalVolume == 0.0f)
            dbVolumeMus = -80.0f;

        volumeMusSlider = volumeMus.value;
        PlayerPrefs.SetFloat("sliderMus", volumeMusSlider);

        audioMixer.SetFloat("volumeMus", dbVolumeMus);
        PlayerPrefs.SetFloat("volumeMus", dbVolumeMus);
    }

    public void SetVolumeEfe(float decimalVolume) {
        dbVolumeEfe = Mathf.Log10(decimalVolume) * 20;
        
        if (decimalVolume == 0.0f)
            dbVolumeEfe = -80.0f;

        volumeEfeSlider = volumeEfe.value;
        PlayerPrefs.SetFloat("sliderEfe", volumeEfeSlider);

        audioMixer.SetFloat("volumeEfe", dbVolumeEfe);
        PlayerPrefs.SetFloat("volumeEfe", dbVolumeEfe);
    }

    public void SetFullscreen(bool isFullscreen) {
        Screen.fullScreen = isFullscreen;
    }

    public void SetShowFPS(bool fps) {
        contaFPS.SetActive(fps);
    }

    public void LoadPrefs() {
        dbVolume = PlayerPrefs.GetFloat("volume");
        dbVolumeEfe = PlayerPrefs.GetFloat("volumeEfe");
        dbVolumeMus = PlayerPrefs.GetFloat("volumeMus");

        volume.value = PlayerPrefs.GetFloat("sliderGer");
        volumeEfe.value = PlayerPrefs.GetFloat("sliderEfe");
        volumeMus.value = PlayerPrefs.GetFloat("sliderMus");
    }
}
