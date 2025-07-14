using UnityEngine;

public class Playermove : MonoBehaviour
{
    private float horizontal;
    private float vertical;

    public float speed;
    public GameObject bullet;

    Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Zera o movimento a cada frame
        horizontal = 0;
        vertical = 0;

        // Movimento com WASD
        if (Input.GetKey(KeyCode.A))
        {
            horizontal = -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            horizontal = 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            vertical = -1;
        }

        if (Input.GetKey(KeyCode.W))
        {
            vertical = 1;
        }

        // Aplica movimento
        body.linearVelocity = new Vector2(horizontal, vertical) * speed;

        // Disparo
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }
}


