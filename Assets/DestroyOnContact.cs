using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyOnContact : MonoBehaviour{

    public UnityEvent collisionDetected;
    [SerializeField] private string COLLISION_TAG;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag(COLLISION_TAG)) {
            collisionDetected.Invoke();
        }
    }
}
