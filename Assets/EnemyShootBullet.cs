using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootBullet : MonoBehaviour {

    private EnemyShootBullet esb;
    private Animator animator;

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firePosition;

    [SerializeField] private float cooldownDuration;
    private float lasTimeFired;

    private void Awake() {
        esb = GetComponent<EnemyShootBullet>();
        animator = GetComponent<Animator>();
    }

    private void Update() {
        if(Time.time - lasTimeFired >= cooldownDuration) {
            animator.SetTrigger("Fire");
            lasTimeFired = Time.time;
        }
    }

    public void Fire() {
        Instantiate(bullet, firePosition.position, Quaternion.identity);
    }

    public void DeactivateShooting() {
        esb.enabled = false;
    }

}
