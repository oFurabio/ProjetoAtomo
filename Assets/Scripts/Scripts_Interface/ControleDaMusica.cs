using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDaMusica : MonoBehaviour
{
    public static ControleDaMusica instancia;

       private void Awake()
       {
            DontDestroyOnLoad(this.gameObject);
        
        if(instancia = null)
        {
            instancia = this;
        }
        else
        {
            Destroy(gameObject);
        }
       }
}
