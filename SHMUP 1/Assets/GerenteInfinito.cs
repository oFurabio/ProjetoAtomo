using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenteInfinito : MonoBehaviour {
    public GameObject inimigo;

    [SerializeField] private float bordaX;
    [SerializeField] private float bordaY;

    [SerializeField] private float atrasoInicial;
    [SerializeField] private float intervaloGeracao;

    void Start() {
        InvokeRepeating("GerarInimigosAleatorios", atrasoInicial, intervaloGeracao);
    }

    void GerarInimigosAleatorios() {
        Vector2 criarPos = new Vector2(Random.Range(-bordaX, bordaX), 12);
        Instantiate(inimigo, criarPos, inimigo.transform.rotation);
    }
}
