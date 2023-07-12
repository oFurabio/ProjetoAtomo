using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour {
    public static AudioSource explodeSound;

    public static bool JogoPausado = true;

    public static bool ataqAtivo = false;
    public static bool dashAtivo = false;

    public static bool telaCheia = true;

    public static bool ganhou;

    public GameObject buttonUI, pauseMenuUI, barraDeVida, player, seletor, projetil, configuracao, limites, gameOver, progresso, inicio, tutorialUm, confirmacao;
    public GameObject seletorPrimeiro, pausePrimeiro, configPrimeiro, gameOverPrimeiro, voceGanhouDash, voceGanhouTiro, confirmacaoPrimeiro;

    private void Awake() {
        Time.timeScale = 1f;

        ataqAtivo = false;
        dashAtivo = false;

        explodeSound = GetComponent<AudioSource>();

        EventSystem.current.SetSelectedGameObject(seletorPrimeiro);
        //inicio.SetActive(true);

        ganhou = false;
    }

    void Update() {
        if (Input.GetButtonDown("Cancel") && !seletor.activeInHierarchy && !gameOver.activeInHierarchy && !ganhou && !inicio.activeInHierarchy) {
            if (JogoPausado) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        configuracao.SetActive(false);
        confirmacao.SetActive(false);
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

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(configPrimeiro);
    }

    public void LoadMenu() {
        JogoPausado = false;
        SceneManager.LoadScene("Menu");
    }

    public void Restart() {
        JogoPausado = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Ataque() {
        limites.SetActive(true);
        ataqAtivo = true;
        dashAtivo = false;
        seletor.SetActive(false);
        inicio.SetActive(false);
        Time.timeScale = 1f;
        tutorialUm.SetActive(true);
        projetil.SetActive(true);
        buttonUI.SetActive(true);
        barraDeVida.SetActive(true);
        JogoPausado = false;

    }

    public void Dash() {
        dashAtivo = true;
        ataqAtivo = false;
        seletor.SetActive(false);
        inicio.SetActive(false);
        tutorialUm.SetActive(true);
        buttonUI.SetActive(true);
        barraDeVida.SetActive(true);
        Time.timeScale = 1f;
        JogoPausado = false;
    }

    public void GameOver() {
        gameOver.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(gameOverPrimeiro);
    }

    public void VenceuDash() {
        Time.timeScale = 0f;

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(voceGanhouDash);
    }
    public void VenceuTiro() {
        Time.timeScale = 0f;

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(voceGanhouTiro);
    }

    public void Voltar() {
        configuracao.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(pausePrimeiro);
    }

    public void Sair()
    {
        confirmacao.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(confirmacaoPrimeiro);
    }

    public void Cancela()
    {
        confirmacao.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(pausePrimeiro);
    }

    public void FecharJogo() {
        Application.Quit();
        Debug.Log("Quit!");
    }
}
