using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeactivationHandler : MonoBehaviour {
    
    private Animator animator;
    private CircleCollider2D colliderComponent;

    private void Awake() {
        animator = GetComponent<Animator>();
        colliderComponent = GetComponent<CircleCollider2D>();
    }

    public void DeactivationStarted() {
        colliderComponent.enabled = false;
        animator.SetTrigger("Explode");
    }

    public void DeactivationFinished() {
        Destroy(gameObject);
    }

}
