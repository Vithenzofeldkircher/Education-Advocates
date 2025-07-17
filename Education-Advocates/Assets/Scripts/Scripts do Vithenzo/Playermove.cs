using UnityEngine;

public class Playermove : MonoBehaviour
{
    public GameObject laserDojogador;

    public Transform LocalDoDisparo;

    public float velocidadeDaNave;

    private Vector2 TeclasApertadas;

    public Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        AtirarlazerDoPlayer();

        MovimentarJogador();
    }

    public void MovimentarJogador()
    {
        TeclasApertadas = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        body.linearVelocity = TeclasApertadas.normalized * velocidadeDaNave;
    }
    
    public void AtirarlazerDoPlayer()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(laserDojogador, LocalDoDisparo.position, LocalDoDisparo.rotation);
        }
    }

    
}

