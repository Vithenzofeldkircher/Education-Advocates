using UnityEngine;
using UnityEngine.UI;

public class GameManeger : MonoBehaviour
{
    public int SaberAtual;

    //Uma variavel unica
    public static GameManeger instance;

    public Text TextodeSaberAtual;
    void Awake()
    {
        instance = this; 
        //quando o jogo iniciar a variavel instance ira dar como valor o scrip GameManeger. 
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SaberAtual = 0;
        TextodeSaberAtual.text = "Saber: " + SaberAtual;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AumentarSaber(int SaberParaGanhar)
    {
        SaberAtual += SaberParaGanhar;
        TextodeSaberAtual.text = "Saber: " + SaberAtual;
    }
}
