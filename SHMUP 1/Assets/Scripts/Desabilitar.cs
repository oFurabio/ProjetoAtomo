using UnityEngine;

public class Desabilitar : MonoBehaviour
{
    public GameObject quasi, tutorialUm, tutorialDois, progresso, infinito;

    public void Desabilita() {
        quasi.SetActive(false);
    }

    public void DesabilitaTutorial() {
        tutorialDois.SetActive(true);
        tutorialUm.SetActive(false);
    }

    public void DesabilitaTutorialDois() {
        progresso.SetActive(true);
        tutorialDois.SetActive(false);
    }

    public void Infinito()
    {
        infinito.SetActive(true);
        tutorialDois.SetActive(false);
    }
}
