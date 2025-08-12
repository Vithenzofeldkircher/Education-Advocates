using UnityEngine;

public class Inimigos : MonoBehaviour
{
    public GameObject LaserDoInimigo;

    public Transform LocalDoDisparo;

    public float velocidadeDoInimigo;

    public float tempoMaximoEntreOsLasers;

    public float tempoAtualDosLasers;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovimentarInimigo();
    }

    public void MovimentarInimigo()
    {
        transform.Translate(Vector3.down * velocidadeDoInimigo * Time.deltaTime);
    }

    private void AtirarLaser()
    {
        tempoAtualDosLasers -= Time.deltaTime;
    }

}
