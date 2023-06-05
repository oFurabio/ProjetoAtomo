using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class BotaoSkip : MonoBehaviour {
    public GameObject nada, cubotao;

    public GameObject nadinha, coBotao, Skipo;

    void Start() {
        nada.SetActive(true);
        cubotao.SetActive(false);

        EventSystem.current.SetSelectedGameObject(nadinha);
    }

    public void AtivaBotao() {
        cubotao.SetActive(true);
        nada.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(Skipo);
    }

    public void DesativaBotao() {
        nada.SetActive(true);
        cubotao.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(nadinha);
    }

    public void Skipa() {
        SceneManager.LoadScene("Game");
    }
}
