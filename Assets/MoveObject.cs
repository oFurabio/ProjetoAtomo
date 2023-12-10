using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour {

    [Header("")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float screenLimit;


    private void FixedUpdate() {
        Vector3 movement = movementSpeed * Time.deltaTime * Vector2.up;

        transform.position += movement;

        if (transform.position.y <= screenLimit) { Destroy(gameObject); }
    }

    public void DisableMovement() { movementSpeed = 0f; }

}
