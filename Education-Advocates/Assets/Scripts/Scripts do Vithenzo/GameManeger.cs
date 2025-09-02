using UnityEngine;
using UnityEngine.UI;

public class GameManeger : MonoBehaviour
{
    public int SaberAtual;
    public int pontosParaVitoria = 150;

    //Uma variavel unica
    public static GameManeger instance;

    public Text TextodeSaberAtual;
    public GameObject telaVitoria;

    void Awake()
    {
        instance = this; 
        //quando o jogo iniciar a variavel instance ira dar como valor o scrip GameManeger. 
    }

    void Start()
    {
        SaberAtual = 0;
        TextodeSaberAtual.text = "Saber: " + SaberAtual;

        if (telaVitoria != null)
            telaVitoria.SetActive(false);
    }

    public void AumentarSaber(int SaberParaGanhar)
    {
        SaberAtual += SaberParaGanhar;
        TextodeSaberAtual.text = "Saber: " + SaberAtual;
    }

    public void TelaDeVitoria()
    {
        if (SaberAtual >= pontosParaVitoria)
        {
            if (telaVitoria != null)
                telaVitoria.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
