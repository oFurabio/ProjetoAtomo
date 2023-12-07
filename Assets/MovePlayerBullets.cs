using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerBullets : MonoBehaviour {

    [SerializeField] private bool up;
    [SerializeField] private bool down;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float screenLimit;

    private void FixedUpdate() {
        Vector3 movement = movementSpeed * Time.deltaTime * Vector2.up;

        transform.position += movement;

        if (up) {
            if (transform.position.y >= screenLimit) { gameObject.SetActive(false); }
        } else if (down) {
            if (transform.position.y <= screenLimit) { gameObject.SetActive(false); }
        }
    }

    public void DisableMovement() {
        movementSpeed = 0f;
    }

}
