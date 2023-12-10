using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullets : MonoBehaviour, IMoveObject, IDeactivationHandler {


    [Header("- Movement -")]
    [SerializeField] private float initialMovementSpeed;
    [SerializeField] private float screenLimit;
    private float movementSpeed;

    [Header("- What to collide -")]
    [SerializeField] private string collisionTag;

    private CircleCollider2D playerBulletCollider;
    private Animator animator;


    private void Awake() {
        animator = GetComponent<Animator>();
        playerBulletCollider = GetComponent<CircleCollider2D>();
    }

    private void Start() {
        ReenableMovement();
    }

    private void FixedUpdate() {
        MoveObject();
    }

    public void MoveObject() {
        Vector3 movement = movementSpeed * Time.deltaTime * Vector2.up;

        transform.position += movement;

        if (transform.position.y >= screenLimit)
            DisableObject();
    }

    public void DeactivationStarted() {
        playerBulletCollider.enabled = false;
        animator.SetTrigger("Explode");
    }

    public void DisableMovement() { movementSpeed = 0f; }

    public void ReenableMovement() {
        movementSpeed = initialMovementSpeed;
        playerBulletCollider.enabled = true;
    }

    public void DisableObject() { gameObject.SetActive(false); }

    public void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag(collisionTag)) {
            DeactivationStarted();
            DisableMovement();
        }
    }
}
