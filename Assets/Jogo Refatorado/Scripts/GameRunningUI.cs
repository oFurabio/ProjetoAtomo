using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameRunningUI : MonoBehaviour {

    [SerializeField] private Button pauseButton;
    [SerializeField] private Image healthBar;

    [SerializeField] private List<Sprite> healthBarSprites;

    private void Awake() {
        pauseButton.onClick.AddListener(() => {
            GameHandler.Instance.TogglePauseGame();
        });
    }

    private void Start() {
        GameHandler.Instance.OnGamePaused += GameHandler_OnGamePaused;
        GameHandler.Instance.OnGameResume += GameHandler_OnGameResume;
        PlayerHealth.Instance.OnHealthChanged += PlayerHealth_OnHealthChanged;

        Show();
    }

    private void PlayerHealth_OnHealthChanged(object sender, System.EventArgs e) {
        ChangeHealth();
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

    public void ChangeHealth() {
        healthBar.sprite = healthBarSprites[PlayerHealth.Instance.currentHealth];
    }
}
