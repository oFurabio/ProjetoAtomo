using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Tiro tiro = collision.GetComponent<Tiro>();
        if (tiro != null)
        {
            Destroy(gameObject);
            tiro.anim.SetTrigger("Explod");
        }
    }
}
