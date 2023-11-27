using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour {

    [SerializeField] private bool up;
    [SerializeField] private bool down;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float screenLimit;

    private void Update() {
        Vector3 direction = new(0f, 1f, 0f);

        Vector3 movement = direction * movementSpeed * Time.deltaTime;

        transform.position = transform.position + movement;

        if (up) {
            if (transform.position.y >= screenLimit) { Destroy(gameObject); }
        } else if (down) {
            if (transform.position.y <= screenLimit) { Destroy(gameObject); }
        }
    }

    public void DisableMovement() {
        movementSpeed = 0f;
    }

}
