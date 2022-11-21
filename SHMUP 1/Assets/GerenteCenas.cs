using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GerenteCenas : MonoBehaviour {
    public GameObject menu, config, comoJogar, creditos;
    public GameObject opPrimeiro, comoVoltar, credVoltar, menJogar;

    private AudioManager audioManager;

    public string levelName;

    public void Jogar() {
        SceneManager.LoadScene(levelName);
    }

    public void Opcoes() {
        config.SetActive(true);
        menu.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(opPrimeiro);
    }

    public void ComoJogar() {
        comoJogar.SetActive(true);
        menu.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(comoVoltar);
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
        comoJogar.SetActive(false);
        creditos.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(menJogar);
    }

    public void QuitGame() {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
