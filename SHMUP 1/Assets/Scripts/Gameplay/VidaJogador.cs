using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaJogador : MonoBehaviour
{
    public int vida;
    public int vidaMaxima = 5;
    void Start()
    {
        vida = vidaMaxima;
    }
    public void TomarDano(int quantidade)
    {
        vida -= quantidade;
        if(vida <=0)
        {
            Destroy(gameObject);
        }
    }
}
