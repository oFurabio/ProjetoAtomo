using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour {
    [Header("Basic Movement")]
    [SerializeField] private float speed;           //  Velocidade da nave
    [SerializeField] private AudioSource shootSound;
    [SerializeField] private AudioSource dashSound;
    private Rigidbody2D body;                       //  Instancia o RigidBody2D
    private Animator anim;                          //  Instancia o Animator
    private PolygonCollider2D colisor;              //  Instancia o Collider
    Vector2 move;

    private float horizontalInput;
    private float verticalInput;

    public float limitX;
    public float limitY;

    [Header("Health")]

    [SerializeField] private float vidaInicial;
    public float VidaAtual { get; private set; }
    public static bool dead;

    [Header("Fire")]

    [SerializeField] private float attackCooldown;  //  Cooldown do Ataque
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] tiros;
    private float cooldownTimer = 6.0f;

    [Header("Dash")]

    [SerializeField] private TrailRenderer tr;
    [SerializeField] private float dashingPower;
    [SerializeField] private float dashingTime = 0.2f;
    [SerializeField] private float dashCooldown = 2f;
    private bool canDash = true;
    private bool isDashing;

    private void Awake() {
        colisor = GetComponent<PolygonCollider2D>();
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        dead = false;
        VidaAtual = vidaInicial;
        isDashing = false;
    }

    void FixedUpdate() {
        body.MovePosition(body.position + (move * speed * Time.deltaTime));

        if (GameManager.dashAtivo) {
            if (Input.GetButton("Fire1") && canDash)
                StartCoroutine(Dash());
        } else if (GameManager.ataqAtivo) {
            if (Input.GetButton("Fire1") && cooldownTimer > attackCooldown && canAttack())
                Attack();
        }

        cooldownTimer += Time.deltaTime;
    }

    private void Update() {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        move = new Vector2(horizontalInput, verticalInput);

        if (!GameManager.JogoPausado) {
            anim.SetBool("Up", verticalInput > 0.01f);
            anim.SetBool("Right", horizontalInput > 0.01f);
            anim.SetBool("Left", horizontalInput < -0.01f);
        }

        if (transform.position.x < -limitX) {
            transform.position = new Vector2(-limitX, transform.position.y);
        } else if (transform.position.x > limitX) {
            transform.position = new Vector2(limitX, transform.position.y);
        } else if (transform.position.y < -limitY) {
            transform.position = new Vector2(transform.position.x, -limitY);
        } else if (transform.position.y > limitY) {
            transform.position = new Vector2(transform.position.x, limitY);
        }
    }

    public bool canAttack() {
        return !GameManager.JogoPausado;
    }

    private void Attack() {
        anim.SetTrigger("Ataq");
        shootSound.Play();
        cooldownTimer = 0;

        tiros[FindTiro()].transform.position = firePoint.position;
        tiros[FindTiro()].GetComponent<Tiro>().SetDirection(Mathf.Sign(transform.localScale.y));
    }

    private int FindTiro() {
        for (int i = 0; i < tiros.Length; i++) {
            if (!tiros[i].activeInHierarchy)
                return i;
        }
        return 0;
    }

    private IEnumerator Dash() {
        anim.SetTrigger("Dash");
        dashSound.Play();
        canDash = false;
        isDashing = true;
        if(horizontalInput != 0 && verticalInput != 0)
            body.MovePosition(body.position + (move * ((speed * dashingPower)/2) * Time.deltaTime));
        else
            body.MovePosition(body.position + (move * (speed * dashingPower) * Time.deltaTime));
        tr.emitting = true;
        colisor.enabled = false;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        isDashing = false;
        colisor.enabled = true;
        yield return new WaitForSeconds(dashCooldown);
    }

    public void PodeDasha() {
        canDash = true;
    }

    public void TomaDano(float dano) {
        VidaAtual = Mathf.Clamp(VidaAtual - dano, 0, vidaInicial);

        if (VidaAtual > 0) {
            anim.SetTrigger("hurt");
        } else {
            if (!dead) {
                anim.SetTrigger("die");
                gameObject.SetActive(false);
                dead = true;
            }
        }
    }

    public void AddVida(float _valor) {
        VidaAtual = Mathf.Clamp(VidaAtual + _valor, 0, vidaInicial);
    }
}
