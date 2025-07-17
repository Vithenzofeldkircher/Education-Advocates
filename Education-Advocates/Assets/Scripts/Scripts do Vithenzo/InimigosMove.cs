using UnityEngine;
using UnityEngine.Rendering;

public class InimigosMove : MonoBehaviour
{
    public float velocidadeDoinimigo;

    public GameObject LaserDoinimigo;

    public Transform localDOdisparo;

    public float tempoMaximoEntreosDIsparos;

    public float tempoAtualdosDisparos;

    public bool inimigoAtirador;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inimigoAtirador == true)
        {
            AtiraDisparo();
        }

        MovimentarInimigo();
    }

    private void MovimentarInimigo()
    {
        transform.Translate(Vector3.down * velocidadeDoinimigo * Time.deltaTime);
    }

    private void AtiraDisparo()
    {
        tempoAtualdosDisparos -= Time.deltaTime; //diminui o time para o proximo disparo

        if (tempoAtualdosDisparos <= 0) //verefica caso chegue a 0 ou menor disparo um disparo
        {
            Instantiate(LaserDoinimigo, localDOdisparo.position, Quaternion.Euler(0f,0f,90f));// coloca os disparos deles no angulo de 90 graus
            tempoAtualdosDisparos = tempoMaximoEntreosDIsparos;
        }
    }
}
