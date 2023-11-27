using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyOnContact : MonoBehaviour{

    public UnityEvent collisionDetected;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            collisionDetected.Invoke();
        }
    }
}
