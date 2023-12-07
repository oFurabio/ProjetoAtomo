using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour {


    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletsArray;

    private List<GameObject> bullets = new();


    private void Start() {
        Player.Instance.onShoot += Player_onShoot;
        Player.Instance.onDash += Player_onDash;

        for (int i = 0; i < bulletsArray.transform.childCount; i++) {
            Transform bulletTransform = bulletsArray.transform.GetChild(i);
            bullets.Add(bulletTransform.gameObject);
        }
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
        Dash();
    }

    private void Player_onShoot(object sender, System.EventArgs e) {
        Shoot();
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
        //Physics2D.IgnoreCollision()
    }

}
