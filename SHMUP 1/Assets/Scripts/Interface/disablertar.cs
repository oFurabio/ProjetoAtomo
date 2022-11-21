using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class disablertar : MonoBehaviour {

    public GameObject botao;

    /*private void Update() {
        if (Input.GetAxis)
        {

        }
    }*/

    public void TrocaCena() {
        SceneManager.LoadScene("Game");
    }

    public void HabilitaBotao() {
        botao.SetActive(true);
    }
}
