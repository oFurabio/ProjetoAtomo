using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fire : MonoBehaviour {

    [SerializeField] private GameObject playerBullet;
    [SerializeField] private Transform firePoint;

    public void FireWeapon() {
        Instantiate(playerBullet, firePoint.position, Quaternion.identity);
    }

}
