using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DisableOnContact : MonoBehaviour, IDeactivationHandler {

    public UnityEvent collisionDetected;
    [SerializeField] private List<string> collisionTags = new();

    public void DeactivationStarted() {

    }

    public void DestroyObject() {
        
    }

    public void DisableObject() {
        
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        foreach (string tag in collisionTags) {
            if (collision.CompareTag(tag)) {
                collisionDetected.Invoke();
                break;
            }
        }
    }
}
