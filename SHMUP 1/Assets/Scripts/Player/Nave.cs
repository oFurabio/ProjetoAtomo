using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

public class Nave : MonoBehaviour {
    [Header("Basic Movement")]
    [SerializeField] private float speed;           //  Velocidade da nave
    [SerializeField] private AudioSource shootSound;
    [SerializeField] private AudioSource dashSound;
    [SerializeField] private AudioSource coletou;
    //[SerializeField] private AudioSource explodeSound;
    public GameObject morte;
    [SerializeField] private GameManager gm;
    private Rigidbody2D body;                       //  Instancia o RigidBody2D
    private SpriteRenderer sprite;
    private Animator anim;                          //  Instancia o Animator

    Vector2 move;

    private float horizontalInput;
    private float verticalInput;

    [SerializeField] private float limitX;
    [SerializeField] private float limitY;

    [Header("Health")]

    [SerializeField] private int vidaInicial;
    [SerializeField] private float invulne;
    public int VidaAtual;
    public static bool dead;
    Color c;

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

    [SerializeField] private GameObject fogo;
    [SerializeField] private GameObject cooldown;

    private void Awake() {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        Physics2D.IgnoreLayerCollision(6, 7, false);

        c = sprite.material.color;

        dead = false;
        VidaAtual = vidaInicial;
        isDashing = false;

        fogo.SetActive(true);
        cooldown.SetActive(true);
    }

    void FixedUpdate() {
        body.MovePosition(body.position + (move * speed * Time.deltaTime));

        if (GameManager.dashAtivo) {
            if (Input.GetButton("Fire1") && canDash && !dead) {
                if (horizontalInput != 0 || verticalInput != 0) {
                    anim.SetTrigger("Dash");
                    StartCoroutine("Dash");
                }
            }
        } else if (GameManager.ataqAtivo) {
            if (Input.GetButton("Fire1") && cooldownTimer > attackCooldown && CanAttack())
                Attack();
        }

        cooldownTimer += Time.deltaTime;
    }

    private void Update() {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

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

    public bool CanAttack() {
        return !GameManager.JogoPausado && !dead;
    }

    private void Attack() {
        shootSound.PlayOneShot(shootSound.clip, 0.75f);
        anim.SetTrigger("Ataq");
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
        dashSound.Play();
        canDash = false;
        isDashing = true;
        if(horizontalInput != 0 && verticalInput != 0)
            body.MovePosition(body.position + (((speed * dashingPower)/2) * Time.deltaTime * move));
        else if (horizontalInput == 0 && verticalInput == 0) {
            body.MovePosition(body.position + (((speed * dashingPower) / 2) * Time.deltaTime * move));
        } else
            body.MovePosition(body.position + ((speed * dashingPower) * Time.deltaTime * move));
        tr.emitting = true;
        Physics2D.IgnoreLayerCollision(6, 7, true);
        yield return new WaitForSeconds(dashingTime);
        Physics2D.IgnoreLayerCollision(6, 7, false);
        tr.emitting = false;
        isDashing = false;
        yield return new WaitForSecondsRealtime(dashCooldown);
    }

    public void PodeDasha() {
        canDash = true;
    }

    public void TomaDano(int dano) {
        VidaAtual = VidaAtual - dano;

        if (VidaAtual > 0) {
            StartCoroutine("FicaInvulneravel");
            anim.SetTrigger("hurt");
        } else {
            if (!dead) {
                GameManager.explodeSound.PlayOneShot(GameManager.explodeSound.clip, 0.75f);
                Physics2D.IgnoreLayerCollision(6, 7, true);
                anim.SetTrigger("die");
            }
        }
    }

    public void AddVida(int _valor) {
        coletou.PlayOneShot(coletou.clip, 0.75f);
        if (VidaAtual <= 9)
            VidaAtual = VidaAtual + _valor;
    }

    public void Morreu() {
        morte.SetActive(true);
        dead = true;
        fogo.SetActive(false);
        cooldown.SetActive(false);
        speed = 0;
    }

    IEnumerator FicaInvulneravel() {
        Physics2D.IgnoreLayerCollision(6, 7, true);
        c.a = 0.5f;
        sprite.material.color = c;
        yield return new WaitForSeconds(invulne);
        Physics2D.IgnoreLayerCollision(6, 7, false);
        c.a = 1f;
        sprite.material.color = c;
    }

    public void Desabilito() {
        gm.GameOver();
        Time.timeScale = 0.25f;
        Destroy(gameObject);
    }
}
