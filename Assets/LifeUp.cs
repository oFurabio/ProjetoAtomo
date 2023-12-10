using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeUp : MonoBehaviour, IMoveObject, IDeactivationHandler {

    [Header("- Movement -")]
    [SerializeField] private float initialMovementSpeed;
    [SerializeField] private float screenLimit;
    private float movementSpeed;

    [Header("- What to collide -")]
    [SerializeField] private string collisionTag;

    private CircleCollider2D lifeCollider;

    private void Awake() {
        lifeCollider = GetComponent<CircleCollider2D>();
    }

    private void Start() {
        ReenableMovement();
        Player.Instance.OnGainHealth += Player_OnGainHealth;
    }

    private void Player_OnGainHealth(object sender, System.EventArgs e) {
        DeactivationStarted();
        DisableMovement();
        DisableObject();
    }

    private void FixedUpdate() {
        MoveObject();
    }

    public void DeactivationStarted() {
        lifeCollider.enabled = false;
    }

    public void DisableMovement() {
        movementSpeed = 0f;
    }

    public void DisableObject() {
        gameObject.SetActive(false);
    }

    public void MoveObject() {
        Vector3 movement = movementSpeed * Time.deltaTime * Vector2.down;

        transform.position += movement;

        if (transform.position.y <= screenLimit)
            DisableObject();
    }

    public void OnTriggerEnter2D(Collider2D collider) { }

    public void ReenableMovement() {
        movementSpeed = initialMovementSpeed;
        lifeCollider.enabled = true;
    }
}
