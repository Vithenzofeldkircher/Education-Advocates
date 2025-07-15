using UnityEngine;

public class AtaqueInimigo : MonoBehaviour
{
    public float speed = 5f;
    public Transform target;
    public GameObject bullet;

    private Rigidbody2D body;
    private float shootCooldown = 1.0f;
    private float shootTimer = 0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (target != null)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            body.linearVelocity = direction * speed;

            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0f)
            {
                GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);

                Vector2 shootDirection = (target.position - transform.position).normalized;

                newBullet.GetComponent<DirecaoTiro>().SetDirection(shootDirection);

                shootTimer = shootCooldown;
            }
        }
        else
        {
            body.linearVelocity = Vector2.zero;
        }
    }

    void SeguirJogador()
    {

    }
}