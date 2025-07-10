using UnityEngine;

public class Playermove : MonoBehaviour

{

    private float horizontal;

    private float vertical;

    public float speed;

    public GameObject bullet;

    Rigidbody2D body;//Necessário para programar física

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()

    {

        //Pega o componente que está no mesmo GameObject

        body = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame

    void Update()

    {
        if (Input.GetKey(KeyCode.A))
        {
            // Move pra esquerda
            horizontal = -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            // Move pra direita
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
        //Input.GetKeyDown(KeyCode.Escape);

        body.linearVelocity = new Vector2(horizontal, vertical) * speed;

        if (Input.GetButtonDown("Fire1"))

        {

            Instantiate(bullet, transform.position, transform.rotation);

        }

    }

}

