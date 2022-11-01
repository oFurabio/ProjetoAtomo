using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveUpDown : MonoBehaviour
{
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos.y -= speed * Time.fixedDeltaTime;

        if (pos.y < -10)
        {
            Destroy(gameObject);
        }

        transform.position = pos;
    }
}
