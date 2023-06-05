using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSin : MonoBehaviour
{

    float centro;
    float ranAmp, ranFreq;
    public float amp = 1;
    public float freq = 1;

    public bool invertido = false;

    // Start is called before the first frame update
    void Start()
    {
        centro = transform.position.x;
        ranAmp = Random.Range(0.1f, 7.5f);
        ranFreq = Random.Range(0.1f, 1.5f);
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        float sin = Mathf.Sin(pos.y * freq) * amp;
        if (invertido)
        {
            sin *= -1;
        }
        pos.x = centro + sin;

        transform.position = pos;
    }
}
