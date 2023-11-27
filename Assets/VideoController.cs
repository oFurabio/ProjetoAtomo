using System.Collections;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VideoController : MonoBehaviour {

    private string SCENE_TO_LOAD = "RefatorasScene";
    [SerializeField] private RawImage rawImage;
    [SerializeField] private VideoPlayer videoPlayer;

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

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(SCENE_TO_LOAD);

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
