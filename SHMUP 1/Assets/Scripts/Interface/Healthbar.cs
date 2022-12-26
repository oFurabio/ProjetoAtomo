using System;
using UnityEngine;
using UnityEngine.UI;


public class Healthbar : MonoBehaviour {
    public SpriteRenderer sprites;

    public Nave jogador;

    public Sprite[] spriteArray;

    public int vidaInt;

    private void Start() {
        vidaInt = jogador.VidaAtual;
    }

    private void Update() {
        if (vidaInt != jogador.VidaAtual) {
            MudarSprite();
            vidaInt = jogador.VidaAtual;
        }
    }

    void MudarSprite() {
        if(vidaInt > jogador.VidaAtual)
            sprites.sprite = spriteArray[vidaInt - 1];
        else
            sprites.sprite = spriteArray[vidaInt + 1];
    }
}
