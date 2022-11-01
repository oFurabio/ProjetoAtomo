using UnityEngine;
using UnityEngine.UI;


public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health pHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;

    private void Start()
    {
        totalHealthBar.fillAmount = pHealth.vidaAtual / 10;
    }
    private void Update()
    {
        currentHealthBar.fillAmount = pHealth.vidaAtual /10;
    }
}
