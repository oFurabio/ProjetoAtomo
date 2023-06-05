using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour {
    private Animator anim;
    public Bullet bullet;
    Vector2 direction;

    private Rigidbody2D body;

    [SerializeField] private bool autoShoot;

    [SerializeField] private float startShoot;
    [SerializeField] private float shootIntervalSeconds;
    [SerializeField] private float shootDelaySeconds;

    private float shootTimer = 0f;
    private float delayTimer = 0f;

    private void Start() {
        anim = GetComponent<Animator>();
        body = GetComponentInParent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        direction = (transform.localRotation * Vector2.down).normalized;

        if ((body.position.y < startShoot) && autoShoot)
        {
            if (delayTimer >= shootDelaySeconds)
            {
                if (shootTimer >= shootIntervalSeconds)
                {
                    anim.SetTrigger("atira");
                    shootTimer = 0;
                }
                else
                {
                    shootTimer += Time.fixedDeltaTime;
                }
            }
            else
            {
                delayTimer += Time.fixedDeltaTime;
            }
        }
    }

    public void Shoot() {
        GameObject go = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
        Bullet goBullet = go.GetComponent<Bullet>();
        goBullet.direction = direction;
    }
}
