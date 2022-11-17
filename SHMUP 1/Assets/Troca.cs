using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Troca : MonoBehaviour
{
    private Animator anim;
    private float hInput;

    public GameObject dash, tiro;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        hInput = Input.GetAxisRaw("Horizontal");

        if (hInput > 0.01f) {
            anim.SetTrigger("direita");
            dash.SetActive(false);
            tiro.SetActive(true);
        } else if (hInput < -0.01f) {
            anim.SetTrigger("esquerda");
            tiro.SetActive(false);
            dash.SetActive(true);
        }
    }
}
