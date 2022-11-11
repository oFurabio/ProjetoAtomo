using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    private Animator anim;
    public Bullet bullet;
    Vector2 direction;

    public bool autoShoot;
    public float shootIntervalSeconds = 0.5f;
    public float shootDelaySeconds = 0.0f;
    float shootTimer = 0f;
    float delayTimer = 0f;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        direction = (transform.localRotation * Vector2.down).normalized;

        /*if (pos.y < 9)
            autoShoot = true;*/
            
        if (autoShoot)
        {
            if(delayTimer >= shootDelaySeconds)
            {
                if(shootTimer >= shootIntervalSeconds)
                {
                    Shoot();
                    shootTimer = 0;
                }
                else
                {
                    shootTimer += Time.deltaTime;
                }
                
            }
            else
            {
                delayTimer += Time.deltaTime;
            }
        }
    }

    /*private void FixedUpdate()
    {
        direction = (transform.localRotation * Vector2.down).normalized;

        if (autoShoot)
        {
            if (delayTimer >= shootDelaySeconds)
            {
                Shoot();
                shootTimer = 0;
            }
            else
            {
                shootTimer += Time.deltaTime;
            }
        }
        else
        {
            delayTimer += Time.deltaTime;
        }
    }*/

    public void Shoot()
    {
        anim.SetTrigger("atira");
        GameObject go = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
        Bullet goBullet = go.GetComponent<Bullet>();
        goBullet.direction = direction;
    }
}
