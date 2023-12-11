using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpaceship : MonoBehaviour, IMoveObject, IDeactivationHandler {


    [Header("- Movement -")]
    [SerializeField] private float initialMovementSpeed;
    [SerializeField] private float screenLimit;
    private float movementSpeed;
    
    
    [Header("- What to collide -")]
    [SerializeField] private List<string> collisionTags = new();
    

    public event EventHandler OnHit;
    private Animator animator;
    private AudioSource audioSource;
    private CircleCollider2D spaceshipCollider;
    


    private void Awake() {
        animator = GetComponent<Animator>();
        spaceshipCollider = GetComponent<CircleCollider2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start() {
        OnHit += EnemySpaceship_OnHit;

        movementSpeed = initialMovementSpeed;
    }

    private void FixedUpdate() {
        MoveObject();
    }

    private void EnemySpaceship_OnHit(object sender, EventArgs e) {
        DisableMovement();
        DeactivationStarted();
    }

    public void MoveObject() {
        Vector3 movement = movementSpeed * Time.deltaTime * Vector2.down;

        transform.position += movement;

        if (transform.position.y <= screenLimit)
            DisableObject();
    }

    public void DisableMovement() { movementSpeed = 0f; }

    public void ReenableMovement() { movementSpeed = initialMovementSpeed; }

    public void DeactivationStarted() {
        spaceshipCollider.enabled = false;
        animator.SetTrigger("Explode");
        audioSource.PlayOneShot(audioSource.clip);
    }

    public void DisableObject() { Destroy(gameObject); }

    public void OnTriggerEnter2D(Collider2D collision) {
        foreach (string tag in collisionTags) {
            if (collision.CompareTag(tag)) {
                OnHit?.Invoke(this, EventArgs.Empty);
                break;
            }
        }
    }
}