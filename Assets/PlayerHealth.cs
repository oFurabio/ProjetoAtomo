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
    public int currentHealth { get; private set; }

    public event EventHandler OnPlayerDeath;
    public event EventHandler OnHealthChanged;


    private void Awake() {
        if (Instance != null)
            Debug.Log("There is more than one playerHealth instance");

        Instance = this;

        Player.Instance.OnLoseHealth += PlayerHealth_OnLoseHealth;
        Player.Instance.OnGainHealth += PlayerHealth_OnGainHealth;
    }

    private void Start() {
        currentHealth = maxHealth;
        Physics2D.IgnoreLayerCollision(7, 6, false);
        playerCollider = GetComponent<PolygonCollider2D>();
    }

    private void PlayerHealth_OnGainHealth(object sender, EventArgs e) {
        if (currentHealth < maxHealth)
            currentHealth++;
        OnHealthChanged?.Invoke(this, EventArgs.Empty);
    }

    private void PlayerHealth_OnLoseHealth(object sender, EventArgs e) {
        if (currentHealth == 1) {
            currentHealth--;
            OnPlayerDeath?.Invoke(this, EventArgs.Empty);
        } else if (currentHealth > 1) {
            currentHealth--;
            StartCoroutine(BecomeInvincible());
        }
        OnHealthChanged?.Invoke(this, EventArgs.Empty);
    }

    private IEnumerator BecomeInvincible() {
        Physics2D.IgnoreLayerCollision(7, 6, true);
        yield return new WaitForSeconds(invincibilityTime);
        Physics2D.IgnoreLayerCollision(7, 6, false);
    }

}
