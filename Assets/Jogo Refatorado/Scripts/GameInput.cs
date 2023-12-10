using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour {

    public static GameInput Instance { get; private set; }

    public event EventHandler OnPauseAction;
    public event EventHandler OnChangeAction;

    private PlayerInputActions playerInputActions;

    private void Awake() {
        if (Instance != null)
            Debug.LogError("There is more than one GameInput instance");

        Instance = this;

        playerInputActions = new PlayerInputActions();

        playerInputActions.Player.Enable();

        playerInputActions.Player.Pause.performed += Pause_performed;
        playerInputActions.Player.ChangeAction.performed += ChangeAction_performed;
    }

    private void OnDestroy() {
        playerInputActions.Player.Pause.performed -= Pause_performed;
        playerInputActions.Player.ChangeAction.performed -= ChangeAction_performed;

        playerInputActions.Dispose();
    }

    private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnPauseAction?.Invoke(this, EventArgs.Empty);
    }

    private void ChangeAction_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnChangeAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVectorNormalized() {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;

        return inputVector;
    }
}
