using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


    public static Player Instance { get; private set; }


    public Defense defense;
    private bool isMoving;


    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameInput gameInput;

    public event EventHandler onShoot;
    public event EventHandler onDash;


    public enum Defense {
        Shoot,
        Dash
    }


    private void Awake() {
        if (Instance != null)
            Debug.LogError("There is more than one player instance");

        Instance = this;
    }

    private void Start() {
        gameInput.OnFireAction += GameInput_OnFireAction;
    }

    private void Update() {
        HandleMovement();
    }

    private void GameInput_OnFireAction(object sender, System.EventArgs e) {
        if (!GameHandler.Instance.IsGamePlaying()) return;

        if (defense == Defense.Dash)
            onDash?.Invoke(this, EventArgs.Empty);

        if (defense == Defense.Shoot)
            onShoot?.Invoke(this, EventArgs.Empty);

    }

    public bool IsMoving() {
        return isMoving;
    }

    private void HandleMovement() {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveDir = new(inputVector.x, inputVector.y);

        float moveDistance = moveSpeed * Time.deltaTime;

        transform.position += moveDir * moveDistance;
    }
}
