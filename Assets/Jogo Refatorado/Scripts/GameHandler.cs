using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.CullingGroup;

public class GameHandler : MonoBehaviour {

    public static GameHandler Instance { get; private set; }

    public event EventHandler OnStateChanged;
    public event EventHandler OnGamePaused;
    public event EventHandler OnGameResume;

    private enum State {
        WaitingToStart,
        GamePlaying,
        GamePaused,
        GameOver
    }

    [SerializeField] private float gamePlayingTimerMax = 10f;

    [SerializeField] private State state;
    private float waitingToStartTimer = 1f;
    private float gamePlayingTimer;
    private bool isGamePaused = false;

    private void Awake() {
        Instance = this;

        state = State.WaitingToStart;
    }

    private void Start() {
        GameInput.Instance.OnPauseAction += GameInput_OnPauseAction;
    }

    private void PlayerHealth_OnPlayerDeath(object sender, EventArgs e) {
        state = State.GameOver;
        OnStateChanged?.Invoke(this, EventArgs.Empty);
    }

    private void GameInput_OnPauseAction(object sender, EventArgs e) {
        TogglePauseGame();
    }

    private void Update() {

#if DEVELOPMENT_BUILD || UNITY_EDITOR
        if (Input.GetKey(KeyCode.LeftShift)) {
            if (Input.GetKeyDown(KeyCode.F1))
                Application.targetFrameRate = 10;
            if (Input.GetKeyDown(KeyCode.F2))
                Application.targetFrameRate = 20;
            if (Input.GetKeyDown(KeyCode.F3))
                Application.targetFrameRate = 30;
            if (Input.GetKeyDown(KeyCode.F4))
                Application.targetFrameRate = 60;
            if (Input.GetKeyDown(KeyCode.F5))
                Application.targetFrameRate = 900;
        }
#endif

        switch (state) {
            case State.WaitingToStart:
                Time.timeScale = 1f;
                waitingToStartTimer -= Time.deltaTime;
                if (waitingToStartTimer < 0f) {
                    state = State.GamePlaying;
                    gamePlayingTimer = gamePlayingTimerMax;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;

            case State.GamePlaying:
                gamePlayingTimer -= Time.deltaTime;
                if (gamePlayingTimer < 0f) {
                    state = State.GameOver;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;

            case State.GameOver:
                Time.timeScale = 0.5f;
                break;
        }
    }


    public bool IsGamePlaying() {
        return state == State.GamePlaying;
    }

    public bool IsGamePaused() {
        return state == State.GamePaused;
    }

    public bool IsGameOver() {
        return state == State.GameOver;
    }

    public float GetGamePlayingTimerNormalized() {
        return 1 - (gamePlayingTimer / gamePlayingTimerMax);
    }

    public void TogglePauseGame() {
        if (IsGamePlaying() || IsGamePaused()) {
            isGamePaused = !isGamePaused;
            if (isGamePaused) {
                Time.timeScale = 0f;
                state = State.GamePaused;
                OnGamePaused?.Invoke(this, EventArgs.Empty);
            } else {
                Time.timeScale = 1f;
                state = State.GamePlaying;
                OnGameResume?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
