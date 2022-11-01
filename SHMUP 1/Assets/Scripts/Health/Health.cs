using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float vidaInicial;
    public float vidaAtual { get; private set; }
    private Animator anim;
    public GameObject fogo;
    public bool dead;

    private void Awake()
    {
        vidaAtual = vidaInicial;
        anim = GetComponent<Animator>();
    }

    public void TomaDano(float dano)
    {
        vidaAtual = Mathf.Clamp(vidaAtual - dano, 0, vidaInicial);

        if (vidaAtual > 0)
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("die");
                fogo.SetActive(false);
                GetComponent<Movement>().enabled = false;
                dead = true;
            }
        }
    }

    public void AddVida(float _valor)
    {
        vidaAtual = Mathf.Clamp(vidaAtual + _valor, 0, vidaInicial);
    }
}
