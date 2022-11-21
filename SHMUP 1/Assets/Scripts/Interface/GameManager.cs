using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour {
    public static bool JogoPausado = true;

    public static bool ataqAtivo = false;
    public static bool dashAtivo = false;

    public GameObject buttonUI, pauseMenuUI, barraDeVida, player, seletor, projetil, configuracao, limites, gameOver;
    public GameObject seletorPrimeiro, pausePrimeiro;

    private void Awake() {
        EventSystem.current.SetSelectedGameObject(seletorPrimeiro);
    }

    void Update() {
        if (pauseMenuUI.activeInHierarchy || seletor.activeInHierarchy) {
            Time.timeScale = 0f;
        }

        if (Input.GetButtonDown("Cancel") && !seletor.activeInHierarchy) {
            if (JogoPausado) {
                Resume();
            } else {
                Pause();
            }
        }

        if (Nave.dead)
            GameOver();
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        configuracao.SetActive(false);
        buttonUI.SetActive(true);
        Time.timeScale = 1f;
        JogoPausado = false;
    }

    public void Pause() {
        pauseMenuUI.SetActive(true);
        buttonUI.SetActive(false);
        Time.timeScale = 0f;
        JogoPausado = true;

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(pausePrimeiro);
    }

    public void Configuracao() {
        configuracao.SetActive(true);
    }

    public void LoadMenu() {
        Time.timeScale = 1f;
        JogoPausado = false;
        SceneManager.LoadScene("Menu");
    }

    public void Restart() {
        Time.timeScale = 1f;
        JogoPausado = false;
        SceneManager.LoadScene("Game");
    }

    public void Ataque() {
        limites.SetActive(true);
        ataqAtivo = true;
        dashAtivo = false;
        seletor.SetActive(false);
        Time.timeScale = 1f;
        projetil.SetActive(true);
        buttonUI.SetActive(true);
        barraDeVida.SetActive(true);
        JogoPausado = false;

    }

    public void Dash() {
        dashAtivo = true;
        ataqAtivo = false;
        seletor.SetActive(false);
        buttonUI.SetActive(true);
        barraDeVida.SetActive(true);
        Time.timeScale = 1f;
        JogoPausado = false;
    }

    public void Voltar() {
        configuracao.SetActive(false);
    }

    public void GameOver() {
        gameOver.SetActive(true);
        Time.timeScale = 0f;
    }
}
