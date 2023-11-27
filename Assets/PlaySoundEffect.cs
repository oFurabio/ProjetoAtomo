using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundEffect : MonoBehaviour {

    private AudioSource soundEffect;

    private void Awake() {
        soundEffect = GetComponent<AudioSource>();
    }

    public void PlayOneTime() {
        soundEffect.PlayOneShot(soundEffect.clip);
    }

}
