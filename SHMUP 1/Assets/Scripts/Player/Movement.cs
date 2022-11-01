using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;           //  Velocidade da nave
    private Rigidbody2D body;                       //  Instancia o RigidBody2D
    private Animator anim;                          //  Instancia o Animator
    Vector2 move;
    private float horizontalInput;
    private float verticalInput;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        body.MovePosition(body.position + (move * speed * Time.deltaTime));
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        move = new Vector2(horizontalInput, verticalInput);

        if (!uiManager.JogoPausado)
        {
            anim.SetBool("Up", verticalInput > 0.01f);
            anim.SetBool("Right", horizontalInput > 0.01f);
            anim.SetBool("Left", horizontalInput < -0.01f);
        }
    }

    public bool canAttack()
    {
        return !uiManager.JogoPausado;
    }
}
