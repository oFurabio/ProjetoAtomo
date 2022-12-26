using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveInimiga : MonoBehaviour {
    public Animator anim;
    public PolygonCollider2D colisor;
    public AudioSource expod;
    public Arma arma;

    [SerializeField] private float speed;
    [SerializeField] private float speedLate;

    private int dano;

    Vector2 pos;

    float centro;
    float ranAmp, ranFreq;

    [SerializeField] private float amp = 1;
    [SerializeField] private float freq = 1;
    [SerializeField] private float paraSeno;

    public bool invertido = false;
    public bool left = false;
    public bool right = false;

    private void Awake() {
        arma.enabled = true;
        colisor.enabled = true;

        dano = 1;

        centro = transform.position.x;
        
        ranAmp = Random.Range(0.1f, 9.5f);
        ranFreq = Random.Range(0.1f, 1.5f);
    }

    private void FixedUpdate() {
        pos = transform.position;

        pos.y -= speed * Time.fixedDeltaTime;

        if (pos.y < -10)
            Destroy(gameObject);

        transform.position = pos;

        float sin = Mathf.Sin(pos.y * freq) * amp;

        if (invertido)
            sin *= -1;
        

        if ((pos.y < paraSeno) && left)
            pos.x -= speedLate * Time.fixedDeltaTime;
        else if((pos.y < paraSeno) && right)
            pos.x += speedLate * Time.fixedDeltaTime;
        else
            pos.x = centro + sin;

        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            collision.GetComponent<Nave>().TomaDano(dano);
            expod.PlayOneShot(expod.clip, 0.75f);
            anim.SetTrigger("more");
        }

        Tiro tiro = collision.GetComponent<Tiro>();
        if (tiro != null) {
            expod.PlayOneShot(expod.clip, 0.75f);
            anim.SetTrigger("more");
            tiro.anim.SetTrigger("Explod");
        }
    }

    public void Destruir() {
        Destroy(gameObject);
    }

    public void Morreu() {
        speed = 0;
        speedLate = 0;
        colisor.enabled = false;
        arma.enabled = false;
    }
}
