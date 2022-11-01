using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;  //  Cooldown do Ataque
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] tiros;
    private Animator anim;
    private Movement playerMovement;
    private float cooldownTimer = 6.0f;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<Movement>();
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && cooldownTimer > attackCooldown && playerMovement.canAttack())
            Attack();

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        anim.SetTrigger("Ataq");
        cooldownTimer = 0;

        tiros[FindTiro()].transform.position = firePoint.position;
        tiros[FindTiro()].GetComponent<Tiro>().SetDirection(Mathf.Sign(transform.localScale.y));
    }

    private int FindTiro()
    {
        for (int i = 0; i < tiros.Length; i++)
        {
            if (!tiros[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
