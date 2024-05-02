using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {


    public static PlayerHealth Instance;

    private PolygonCollider2D playerCollider;
    private bool invulnerable;

    [SerializeField] private float invincibilityTime;
    [SerializeField] private int maxHealth;

    [SerializeField] private List<string> damageTags = new();
    [SerializeField] private List<string> powerUpTags = new();

    public int currentHealth { get; private set; }

    public event EventHandler OnPlayerDeath;
    public event EventHandler OnHealthChanged;

    public event EventHandler OnLoseHealth;
    public event EventHandler OnGainHealth;

    List<GameObject> collisions = new();

    Coroutine teste;
    int damageTaken;
    bool gettingDamaged;

    private void Awake() {
        if (Instance != null)
            Debug.Log("There is more than one playerHealth instance");

        Instance = this;

        OnGainHealth += PlayerHealth_OnGainHealth;
        OnLoseHealth += PlayerHealth_OnLoseHealth;
    }

    private void Start() {
        currentHealth = maxHealth;
        Physics2D.IgnoreLayerCollision(7, 6, false);
        playerCollider = GetComponent<PolygonCollider2D>();
    }

    private void LateUpdate() {
        if (damageTaken > 1) {
            Debug.Log("--- start of frame ---");
            Debug.Log($"damageTaken = {damageTaken}");
            int i = 0;
            foreach (GameObject obj in collisions) {
                Debug.Log($"{i}: {obj.name}");
                i++;
            }
            Debug.Log("--- end of frame ---");
        }
        damageTaken = 0;
        collisions.Clear();
    }

    private void PlayerHealth_OnGainHealth(object sender, EventArgs e) {
        if (currentHealth < maxHealth)
            currentHealth++;
        OnHealthChanged?.Invoke(this, EventArgs.Empty);
    }

    private void PlayerHealth_OnLoseHealth(object sender, EventArgs e) {
        teste = StartCoroutine(BecomeInvincible());

        if (currentHealth == 0) {
            OnPlayerDeath?.Invoke(this, EventArgs.Empty);
            return;
        }

        OnHealthChanged?.Invoke(this, EventArgs.Empty);
    }

    private IEnumerator BecomeInvincible() {
        currentHealth--;
        yield return new WaitForSeconds(invincibilityTime);
        gettingDamaged = false;
        Physics2D.IgnoreLayerCollision(7, 6, false);
        teste = null;
    }

    public void OnTriggerEnter2D(Collider2D collider) {
        if (powerUpTags.Contains(collider.tag)) {
            OnGainHealth?.Invoke(this, EventArgs.Empty);
        } else if (damageTags.Contains(collider.tag)) {
            Physics2D.IgnoreLayerCollision(7, 6, true);
            if (teste == null) {
                gettingDamaged = true;
                damageTaken++;
                collisions.Add(collider.gameObject);
                OnLoseHealth?.Invoke(this, EventArgs.Empty);
            }
        }
    }

}
