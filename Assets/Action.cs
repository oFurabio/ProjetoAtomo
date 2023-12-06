using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour {


    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bullet;


    private void Start() {
        Player.Instance.onShoot += Player_onShoot;
        Player.Instance.onDash += Player_onDash;
    }

    private void Player_onDash(object sender, System.EventArgs e) {
        Dash();
    }

    private void Player_onShoot(object sender, System.EventArgs e) {
        Shoot();
    }

    public void Shoot() {
        Instantiate(bullet, firePoint.position, Quaternion.identity);
    }

    public void Dash() {
        Debug.Log("Dash");
    }

}
