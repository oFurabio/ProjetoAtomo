using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Video;

public class GetVideoPathScript : MonoBehaviour {

    private TextMeshProUGUI videoPathText;
    private VideoPlayer videoPlayer;

    private void Awake() {
        videoPathText = GetComponent<TextMeshProUGUI>();
        videoPlayer = GameObject.FindGameObjectWithTag("Video").GetComponent<VideoPlayer>();
    }

    private void Start() {
        videoPathText.text = videoPlayer.url;
    }

}
