using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour {


    public static PlayerAction Instance { get; private set; }


    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletsArray;


    [Header("- Dash Values -")]
    [SerializeField] private float dashPower = 12f;
    [SerializeField] private float dashDuration = 0.2f;
    [SerializeField] private float dashCooldown = 1f;
    [HideInInspector] public bool isDashing;
    [Header("- Shoot Cooldown -")]
    [SerializeField] private float shootingCooldown = 1f;
    private float timer;


    private Rigidbody2D rb;
    private TrailRenderer trailRenderer;


    private List<GameObject> bullets = new();


    private void Awake() {
        if(Instance != null)
            Debug.LogError("There is more than one Action instance");

        Instance = this;

        rb = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        Player.Instance.OnShoot += Player_onShoot;
        Player.Instance.OnDash += Player_onDash;

        trailRenderer = GetComponentInChildren<TrailRenderer>();

        isDashing = false;
        Physics2D.IgnoreLayerCollision(7, 6, false);
        timer = 0f;

        for (int i = 0; i < bulletsArray.transform.childCount; i++) {
            Transform bulletTransform = bulletsArray.transform.GetChild(i);
            bullets.Add(bulletTransform.gameObject);
        }
    }

    private void Update() {
        timer += Time.deltaTime;
    }

    private void Destroy_bulletDestroyed(object sender, System.EventArgs e) {
        bullets.Clear();

        for (int i = 0; i < bulletsArray.transform.childCount-1; i++) {
            Transform bulletTransform = bulletsArray.transform.GetChild(i);
            bullets.Add(bulletTransform.gameObject);
        }
            Debug.Log("Bullets available " + bullets.Count);
    }

    private void Player_onDash(object sender, System.EventArgs e) {
        if (timer >= dashCooldown && Player.Instance.IsMoving() && Player.Instance.canMove) {
            timer = 0f;
            Dash();
        }
    }

    private void Player_onShoot(object sender, System.EventArgs e) {
        if(timer >= shootingCooldown) {
            timer = 0f;
            Shoot();
        }
    }

    public void Shoot() {
        foreach (GameObject bullet in bullets) {
            if (!bullet.activeInHierarchy) {
                bullet.transform.position = firePoint.position;
                bullet.SetActive(true);
                break;
            }
        }
    }

    public void Dash() {
        StartCoroutine(Dashing());
    }

    private IEnumerator Dashing() {
        isDashing = true;
        rb.velocity = new Vector2(Player.Instance.movementDirection.x * dashPower, Player.Instance.movementDirection.y * dashPower);
        trailRenderer.emitting = true;
        Physics2D.IgnoreLayerCollision(7, 6, true);
        yield return new WaitForSeconds(dashDuration);
        trailRenderer.emitting = false;
        isDashing = false;
        rb.velocity = Vector2.zero;
        Physics2D.IgnoreLayerCollision(7, 6, false);
    }
}
