using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameDuringCutscene : MonoBehaviour {

    private void Start() {
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync() {

        yield return null;

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("GameScene");

        asyncOperation.allowSceneActivation = false;
        Debug.Log("Pro :" + asyncOperation.progress);

        while (!asyncOperation.isDone) {

            if (asyncOperation.progress >= 0.9f) {
                Debug.Log("Completo!");

                if(Input.GetKeyDown(KeyCode.Space)) {
                    asyncOperation.allowSceneActivation = true;
                }
            }

            yield return null;
        }

    }

}
