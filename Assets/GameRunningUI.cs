using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameRunningUI : MonoBehaviour {

    [SerializeField] private Button pauseButton;

    private void Awake() {
        pauseButton.onClick.AddListener(() => {
            GameHandler.Instance.TogglePauseGame();
        });
    }

    private void Start() {
        GameHandler.Instance.OnGamePaused += GameHandler_OnGamePaused;
        GameHandler.Instance.OnGameResume += GameHandler_OnGameResume;

        Show();
    }

    private void GameHandler_OnGameResume(object sender, System.EventArgs e) {
        Show();
    }

    private void GameHandler_OnGamePaused(object sender, System.EventArgs e) {
        Hide();
    }

    private void Show() {
        pauseButton.gameObject.SetActive(true);
    }

    private void Hide() {
        pauseButton.gameObject.SetActive(false);
    }
}
