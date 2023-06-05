using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public Vector2 direction = new Vector2(0, -1);
    public float speed = 2;
    public int dano;

    public Vector2 velocity;
    
    void Update() {
        velocity = direction * speed;
    }

    private void FixedUpdate() {
        Vector2 pos = transform.position;

        pos += velocity * Time.fixedDeltaTime;

        transform.position = pos;

        if(pos.y < -9.5f)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            collision.GetComponent<Nave>().TomaDano(dano);
            Destroy(gameObject);
        }
    }
}
