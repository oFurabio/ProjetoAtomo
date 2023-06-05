using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public VidaJogador vidajogador;
    public int dano =1;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
    if(collision.gameObject.tag == "Player")
    {
        vidajogador.TomarDano(1);
    }
    }
}
