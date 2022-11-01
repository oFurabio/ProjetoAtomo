using UnityEngine;

public class Tiro : MonoBehaviour
{
    [SerializeField] private float speed;
    private float direction;
    private bool hit;

    private CircleCollider2D circleCollider;
    public Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        if (hit) return;
        float moveSpeed = speed * Time.deltaTime * direction;
        transform.Translate(0, moveSpeed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        circleCollider.enabled = false;
        anim.SetTrigger("Explod");
    }

    public void SetDirection(float _direction)
    {
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        circleCollider.enabled = true;

        float localScaleY = transform.localScale.y;
        if (Mathf.Sign(localScaleY) != _direction)
            localScaleY = -localScaleY;

        transform.localScale = new Vector3(transform.localScale.y, localScaleY, transform.localScale.z);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
