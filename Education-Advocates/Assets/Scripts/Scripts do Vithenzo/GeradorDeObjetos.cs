using UnityEngine;

public class GeradorDeObjetos : MonoBehaviour
{
    public Transform[] pontoDeSpawn;
    public GameObject[] objetosParaSpawnar;
    public float tempoMaximoEntreOsSpwans;
    public float TempoAtualDosSpwans;

    private bool podeSpawnar = true; 

    void Start()
    {
        TempoAtualDosSpwans = tempoMaximoEntreOsSpwans;
    }

    void Update()
    {
        if (!podeSpawnar) return; 

        TempoAtualDosSpwans -= Time.deltaTime;

        if (TempoAtualDosSpwans <= 0)
        {
            SpawnarObjeto();
        }
    }

    private void SpawnarObjeto()
    {
        int ObjetoAleatorio = Random.Range(0, objetosParaSpawnar.Length);
        int pontoAleatorio = Random.Range(0, pontoDeSpawn.Length);

        Instantiate(objetosParaSpawnar[ObjetoAleatorio],
            pontoDeSpawn[pontoAleatorio].position,
            Quaternion.Euler(0f, 0f, -90f));

        TempoAtualDosSpwans = tempoMaximoEntreOsSpwans;
    }

    // NOVOS MÉTODOS:
    public void PausarSpawns()
    {
        podeSpawnar = false;
    }

    public void RetomarSpawns()
    {
        podeSpawnar = true;
        TempoAtualDosSpwans = tempoMaximoEntreOsSpwans;
    }
}

