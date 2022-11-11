using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveUpDown : MonoBehaviour
{
    private Arma arma;
    private void Awake()
    {
        arma = GetComponent<Arma>();
    }

    public float speed = 5;

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos.y -= speed * Time.fixedDeltaTime;

        if (pos.y < -10)
        {
            Destroy(gameObject);
        }

        transform.position = pos;

        //if (pos.y < 7)
            //arma.autoShoot = true;
    }
}
