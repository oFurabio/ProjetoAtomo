using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Ataque")]
    [SerializeField] private float attackCd;
    [SerializeField] private float range;
    //[SerializeField] private int dano;

    [Header("Ataque Ranged")]
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] fireballs;

    [Header("Colisor")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Camada Jogador")]
    [SerializeField] private LayerMask playerLayer;
    //private float cooldownTimer = Mathf.Infinity;

    private Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void RangedAttack()
    {
        //cooldownTimer = 0;
        //fireballs[0].transform.parent = firepoint.position;
        //fireballs[0].GetComponent<EnemyProjectile>().ActivateProjectile();
    }

    private void Attack()
    {
        anim.SetTrigger("atira");
    }
}
