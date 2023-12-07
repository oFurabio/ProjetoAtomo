using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyOnContact : MonoBehaviour{

    public UnityEvent collisionDetected;
    [SerializeField] private List<string> collisionTags = new();

    private void OnTriggerEnter2D(Collider2D collision) {
        foreach(string tag in collisionTags) {
            if (collision.CompareTag(tag)) {
                collisionDetected.Invoke();
                break;
            }
        }
    }
}
