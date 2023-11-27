using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour {
    public static Player Instance { get; private set; }

    public UnityEvent shooting;

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameInput gameInput;

    private void Awake() {
        if (Instance != null) {
            Debug.LogError("There is more than one player instance");
        }
        Instance = this;
    }

    private void Update() {
        HandleMovement();

        if (Input.GetMouseButton(0)) {
            shooting.Invoke();
        }
    }

    private void HandleMovement() {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveDir = new(inputVector.x, inputVector.y, 0f);

        float moveDistance = moveSpeed * Time.deltaTime;
        bool canMove = true;

        if (canMove) {
            transform.position += moveDir * moveDistance;
        }
    }

}
