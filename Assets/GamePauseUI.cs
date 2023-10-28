using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePauseUI : MonoBehaviour {


    [SerializeField] private Button resumeButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button quitButton;

    private void Awake() {
        resumeButton.onClick.AddListener(() => {
            GameHandler.Instance.TogglePauseGame();
        });
        restartButton.onClick.AddListener(() => {
            GameHandler.Instance.TogglePauseGame();
            Loader.Load(Loader.Scene.RefatorasScene);
        });
        optionsButton.onClick.AddListener(() => {
            Debug.Log("Options Called!");
        });
        mainMenuButton.onClick.AddListener(() => {
            Loader.Load(Loader.Scene.MainMenuScene);
        });
        quitButton.onClick.AddListener(() => {
            Application.Quit();
            Debug.Log("Quit Called!");
        });
    }

    private void Start() {
        GameHandler.Instance.OnGamePaused += GameHandler_OnGamePaused;
        GameHandler.Instance.OnGameResume += GameHandler_OnGameResume;

        Hide();
    }

    private void GameHandler_OnGameResume(object sender, System.EventArgs e) {
        Hide();
    }

    private void GameHandler_OnGamePaused(object sender, System.EventArgs e) {
        Show();

        resumeButton.Select();
    }

    private void Show() {
        gameObject.SetActive(true);
    }

    private void Hide() {
        gameObject.SetActive(false);
    }


}
