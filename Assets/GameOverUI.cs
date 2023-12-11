using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour {


    [SerializeField] private Button restartButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button quitButton;


    private void Awake() {
        restartButton.onClick.AddListener(() => {
            Loader.Load(Loader.Scene.RefatorasScene);
        });
        mainMenuButton.onClick.AddListener(() => {
            Loader.Load(Loader.Scene.MainMenuScene);
        });
        quitButton.onClick.AddListener(() => {
            Application.Quit();
        });
    }

    private void Start() {
        GameHandler.Instance.OnStateChanged += GameHandler_OnStateChanged;

        Hide();
    }

    private void GameHandler_OnStateChanged(object sender, System.EventArgs e) {
        if (GameHandler.Instance.IsGameOver()) {
            Show();
        } else {
            Hide();
        }
    }

    private void Show() {
        gameObject.SetActive(true);
        restartButton.Select();
    }

    private void Hide() {
        gameObject.SetActive(false);
    }
}
