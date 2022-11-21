using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveMent : MonoBehaviour
{
    private Rigidbody2D body;
    
    private float horizontalInput;
    private float verticalInput;

    [SerializeField] private float speed;

    Vector2 move;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        move = new Vector2(horizontalInput, verticalInput);
    }

    private void FixedUpdate()
    {
        body.MovePosition(body.position + (move * speed * Time.deltaTime));
    }
}
