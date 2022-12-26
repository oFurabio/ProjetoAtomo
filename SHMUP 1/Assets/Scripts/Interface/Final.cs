using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final : MonoBehaviour {
    public GameObject finalDash, finalTiro, ini1, ini2, ini3, quaseLa, hubble, terra, ovoPas;

    public void TocarFinal() {
        if (Nave.dead)
            Time.timeScale = 0;
        else {
            GameManager.ganhou = true;
            if (GameManager.dashAtivo) {
                finalDash.SetActive(true);
            } else if (GameManager.ataqAtivo) {
                finalTiro.SetActive(true);
            }
        }
    }
    public void PrimeiroGrupo() {
            ini1.SetActive(true);
    }

    public void SegundoGrupo() {
        if (Nave.dead)
            Time.timeScale = 0;
        else
            ini2.SetActive(true);
    }

    public void TerceiroGrupo() {
        if (Nave.dead)
            Time.timeScale = 0;
        else {
            quaseLa.SetActive(true);
            ini3.SetActive(true);
        }
    }

    public void AtivaHubble() {
        hubble.SetActive(true);
    }

    public void AtivaTerra() {
        terra.SetActive(true);
    }

    public void AtivaEaster() {
        ovoPas.SetActive(true);
    }
}
