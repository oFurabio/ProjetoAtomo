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
        config.SetActive(true);
        menu.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(opPrimeiro);
    }

    public void Infinito() {
        SceneManager.LoadScene("Infinito");
    }

    public void Creditos() {
        creditos.SetActive(true);
        menu.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(credVoltar);
    }

    public void Menu() {
        menu.SetActive(true);
        config.SetActive(false);
        creditos.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(menJogar);
    }

    public void QuitGame() {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
