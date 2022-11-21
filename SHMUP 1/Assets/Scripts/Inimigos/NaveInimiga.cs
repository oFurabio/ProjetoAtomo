using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveInimiga : MonoBehaviour {
    private float dano;

    Vector2 pos;

    float centro;
    float ranAmp, ranFreq;
    public float amp = 1;
    public float freq = 1;

    public bool invertido = false;

    private void Awake() {
        dano = 1;

        centro = transform.position.x;
        
        ranAmp = Random.Range(0.1f, 7.5f);
        
        ranFreq = Random.Range(0.1f, 1.5f);
    }

    public float speed = 5;

    private void FixedUpdate() {
        pos = transform.position;

        pos.y -= speed * Time.fixedDeltaTime;

        if (pos.y < -10)
            Destroy(gameObject);

        transform.position = pos;

        float sin = Mathf.Sin(pos.y * freq) * amp;

        if (invertido)
            sin *= -1;
        
        pos.x = centro + sin;

        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            collision.GetComponent<Nave>().TomaDano(dano);
            Destroy(gameObject);
        }

        Tiro tiro = collision.GetComponent<Tiro>();
        if (tiro != null) {
            Destroy(gameObject);
            tiro.anim.SetTrigger("Explod");
        }
    }
}
