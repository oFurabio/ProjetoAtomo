using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Player;

public class Player : MonoBehaviour {


    public static Player Instance { get; private set; }

    public Vector3 movementDirection { get; private set; }
    public Defense defense { get; private set; }
    public bool canMove { get; private set; }
    private bool isMoving;


    private GameInput gameInput;
    private PlayerHealth playerHealth;


    [Header("- Spaceship Speed -")]
    [SerializeField] private float InitialMoveSpeed = 7f;
    private float moveSpeed;
    [Header("- Wall check -")]
    [SerializeField] private float distance = 0.75f;
    [SerializeField] private float radius = 0.5f;
    [SerializeField] private LayerMask wallLayer;
    [Header("- What to collide -")]
    [SerializeField] private List<string> damageTags = new();
    [SerializeField] private List<string> powerUpTags = new();


    public event EventHandler OnShoot;
    public event EventHandler OnDash;
    public event EventHandler OnLoseHealth;
    public event EventHandler OnGainHealth;
    

    private PlayerInputActions playerInputActions;


    public enum Defense {
        Shoot,
        Dash
    }


    private void Awake() {
        if (Instance != null)
            Debug.LogError("There is more than one player instance");

        Instance = this;

        gameInput = GameObject.FindGameObjectWithTag("GameInput").GetComponent<GameInput>();
        playerHealth = GetComponent<PlayerHealth>();

        playerInputActions = new PlayerInputActions();

        playerInputActions.Player.Enable();

        gameInput.OnChangeAction += GameInput_OnChangeAction;

        playerHealth.OnPlayerDeath += PlayerHealth_OnPlayerDeath;
    }

    private void Start() {
        moveSpeed = InitialMoveSpeed;
    }

    private void PlayerHealth_OnPlayerDeath(object sender, EventArgs e) {
        moveSpeed = 0f;
    }

    private void GameInput_OnChangeAction(object sender, EventArgs e) {
        ChangeDefense();
    }

    private void Update() {
        if (PlayerAction.Instance.isDashing)
            return;

        HandleMovement();

        if (playerInputActions.Player.Action.IsInProgress()) {
            if (!GameHandler.Instance.IsGamePlaying())
                return;
            else if (defense == Defense.Dash)
                OnDash?.Invoke(this, EventArgs.Empty);
            else if (defense == Defense.Shoot)
                OnShoot?.Invoke(this, EventArgs.Empty);
            else
                Debug.LogError("OK, definitivamente não era pra isso ter ocorrido!");
        }
    }

    public bool IsMoving() {
        return isMoving;
    }

    private void HandleMovement() {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        movementDirection = new(inputVector.x, inputVector.y);

        float movementDistance = moveSpeed * Time.deltaTime;
        canMove = !Physics2D.CircleCast(transform.position, radius, movementDirection, distance, wallLayer);

        if (!canMove) {
            Vector3 movementDirectionX = new Vector3(movementDirection.x, 0, 0).normalized;
            canMove = movementDirection.x != 0 && !Physics2D.Raycast(transform.position, movementDirectionX, distance, wallLayer);

            if(canMove)
                movementDirection = movementDirectionX;
            else {
                //  Não consegue se mover no eixo X

                //  Tenta se mover só no eixo Y
                Vector3 movementDirectionY = new Vector3(0, movementDirection.y, 0).normalized;
                canMove = movementDirection.y != 0 && !Physics2D.Raycast(transform.position, movementDirectionY, distance, wallLayer);
                if (canMove)
                    movementDirection = movementDirectionY;
                /*else {
                    //  Não consegue se mover em nenhuma direção
                }*/
            }
        }
        if (canMove)
            transform.position += movementDirection * movementDistance;

        isMoving = movementDirection != Vector3.zero;
    }

    private void ChangeDefense() {
        if (defense == Defense.Shoot)
            defense = Defense.Dash;
        else
            defense = Defense.Shoot;
    }

    public void OnTriggerEnter2D(Collider2D collider) {
        if (powerUpTags.Contains(collider.tag)) {
            OnGainHealth?.Invoke(this, EventArgs.Empty);
        } else if (damageTags.Contains(collider.tag)) {
            OnLoseHealth?.Invoke(this, EventArgs.Empty);
        }
    }
}
