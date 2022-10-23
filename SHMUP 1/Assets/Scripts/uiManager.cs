using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class uiManager : MonoBehaviour
{
    public static bool JogoPausado = false;
    public GameObject buttonUI, pauseMenuUI, player, seletor, projetil;

    public GameObject seletorPrimeiro, pausePrimeiro;

    private void Awake()
    {
        EventSystem.current.SetSelectedGameObject(seletorPrimeiro);
    }

    void Update()
    {
        if (pauseMenuUI.activeInHierarchy || seletor.activeInHierarchy)
        {
            Time.timeScale = 0f;
        }

        if (Input.GetButtonDown("Cancel") && !seletor.activeInHierarchy)
        {
            if (JogoPausado)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        //settingsUI.SetActive(false);
        buttonUI.SetActive(true);
        Time.timeScale = 1f;
        JogoPausado = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        buttonUI.SetActive(false);
        Time.timeScale = 0f;
        JogoPausado = true;

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(pausePrimeiro);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        JogoPausado = false;
        SceneManager.LoadScene("Menu");
    }

    public void Ataque()
    {
        Time.timeScale = 1f;
        projetil.SetActive(true);
        seletor.SetActive(false);
        buttonUI.SetActive(true);
        
    }

    public void Fecha()
    {
        seletor.SetActive(false);
        buttonUI.SetActive(true);
        Time.timeScale = 1f;
        GetComponent<PlayerAttack>().enabled = false;
    }
}
