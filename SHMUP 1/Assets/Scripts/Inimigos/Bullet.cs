using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public Vector2 direction = new Vector2(0, -1);
    public float speed = 2;
    public float dano;
    Vector2 pos;

    private Rigidbody2D body;

    public Vector2 velocity;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = direction * speed;

        if (body.position.y < -9)
            Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos += velocity * Time.fixedDeltaTime;

        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Nave>().TomaDano(dano);
            Destroy(gameObject);
        }
    }
}
