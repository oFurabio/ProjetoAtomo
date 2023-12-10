using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootBullet : MonoBehaviour {

    private EnemySpaceship enemySpaceship;
    private Animator animator;

    [SerializeField] private Transform enemyBulletPrefab;
    [SerializeField] private Transform firePosition;

    [Header("- Time between shooting -")]
    [SerializeField] private float shootingCooldown;
    private float timer;

    private void Awake() {
        enemySpaceship = GetComponent<EnemySpaceship>();
        animator = GetComponent<Animator>();
    }

    private void Start() { enemySpaceship.OnHit += EnemySpaceship_OnHit; }

    private void EnemySpaceship_OnHit(object sender, System.EventArgs e) {
        DeactivateShooting();
    }

    private void Update() {
        if (timer >= shootingCooldown) {
            animator.SetTrigger("Fire");
            timer = 0f;
        }

        timer += Time.deltaTime;
    }

    public void Fire() { Instantiate(enemyBulletPrefab, firePosition.position, Quaternion.identity); }

    public void DeactivateShooting() { this.enabled = false; }

}
