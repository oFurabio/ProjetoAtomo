using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coletavel : MonoBehaviour {
    [SerializeField] private int valorVida;
    [SerializeField] private float speed;

    Vector2 pos;

    private void FixedUpdate() {
        pos = transform.position;

        pos.y -= speed * Time.fixedDeltaTime;

        if (pos.y < -10)
            Destroy(gameObject);

        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            collision.GetComponent<Nave>().AddVida(valorVida);
            gameObject.SetActive(false);
        }
    }
}
