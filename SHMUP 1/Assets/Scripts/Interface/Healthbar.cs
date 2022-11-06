using UnityEngine;
using UnityEngine.UI;


public class Healthbar : MonoBehaviour
{
    [SerializeField] private Nave pHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;

    private void Start()
    {
        totalHealthBar.fillAmount = pHealth.VidaAtual / 10;
    }
    private void Update()
    {
        currentHealthBar.fillAmount = pHealth.VidaAtual /10;
    }
}
