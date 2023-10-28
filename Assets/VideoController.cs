using System.Collections;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VideoController : MonoBehaviour {

    public RawImage rawImage;
    public VideoPlayer videoPlayer;

    void Awake() {
        videoPlayer.targetTexture = new RenderTexture(1920, 1080, 24);
        rawImage.texture = videoPlayer.targetTexture;
    }

    private void Start() {
        videoPlayer.Play();

        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync() {

        yield return null;

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("RefatorasScene");

        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone) {

            if (asyncOperation.progress >= 0.9f) {

                if (!videoPlayer.isPlaying) {
                    asyncOperation.allowSceneActivation = true;
                }
            }

            yield return null;
        }

    }

}
