using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerBullets : MonoBehaviour {

    [SerializeField] private float initialMovementSpeed;
    [SerializeField] private float screenLimit;
    private float movementSpeed;

    private void Start() {
        movementSpeed = initialMovementSpeed;
    }

    private void FixedUpdate() {
        Vector3 movement = movementSpeed * Time.deltaTime * Vector2.up;

        transform.position += movement;

        if (transform.position.y >= screenLimit) {
            gameObject.SetActive(false);
        }
    }

    public void DisableMovement() {
        movementSpeed = 0f;
    }

    public void ReenableMovement() {
        movementSpeed = initialMovementSpeed;
    }
}
