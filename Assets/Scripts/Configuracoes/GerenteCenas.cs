using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GerenteCenas : MonoBehaviour {
    public GameObject menu, config, creditos;
    public GameObject opPrimeiro, credVoltar, menJogar;

    private AudioManager audioManager;

    public string levelName;

    private void Awake() {
        Time.timeScale = 1f;
    }

    public void Jogar() {
        SceneManager.LoadScene(levelName);
    }

    public void Opcoes() {
        AtivaPainel(config);

        BotaoSelecionado(opPrimeiro);
    }

    public void Infinito() {
        Debug.LogWarning("Cena não incluída");
    }

    public void Creditos() {
        AtivaPainel(creditos);

        BotaoSelecionado(credVoltar);
    }

    public void Menu() {
        AtivaPainel(menu);

        BotaoSelecionado(menJogar);
    }

    public void QuitGame() {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    private void BotaoSelecionado(GameObject go)
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(go);
    }

    private void AtivaPainel(GameObject go)
    {
        menu.SetActive(false);
        config.SetActive(false);
        creditos.SetActive(false);

        go.SetActive(true);
    }
}
