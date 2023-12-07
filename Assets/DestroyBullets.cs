using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullets : MonoBehaviour {

    public static DestroyBullets Instance;

    public event EventHandler bulletDestroyed;
    [SerializeField] private GameObject bulletsArray;
    private int bullet;

    private void Awake() {
        Instance = this;
    }

    public void DestroyOnePlayerBullet() {
        bullet = bulletsArray.transform.childCount;

        for (int i = bullet-1; i >= 0; i--) {
            Debug.Log("Bullet {" + (i+1) + "} Deleted");
            Transform toDestoy = bulletsArray.transform.GetChild(i);
            Destroy(toDestoy.gameObject);
            bulletDestroyed?.Invoke(this, EventArgs.Empty);
        }
    }

}
