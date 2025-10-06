using UnityEngine;
using UnityEngine.UI;

public class GameManeger : MonoBehaviour
{
    public int SaberAtual;
    public int pontosParaVitoria = 150;

    public static GameManeger instance;

    public Text TextodeSaberAtual;
    public GameObject telaVitoria;
    public GameObject telaDerrota;

    // Variável para a referência do script de vida do player
    private VidaDoPlayer VidaDoPlayerScript;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            
            VidaDoPlayerScript = playerObject.GetComponent<VidaDoPlayer>();
        }

        // Configurações iniciais
        Time.timeScale = 1f;
        SaberAtual = 0;
        TextodeSaberAtual.text = "Saber: " + SaberAtual;

        // Desativa as telas ao iniciar
        if (telaVitoria != null)
            telaVitoria.SetActive(false);
        if (telaDerrota != null) 
            telaDerrota.SetActive(false);
    }

    
    void Update()
    {
        // Verificamos a cada frame se alguma das condições foi alcançada
        TelaDeVitoria();
        TelaDeDerrota();
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
            // Se o jogo já está pausado, não faça nada.
            if (Time.timeScale == 0f) return;

            if (telaVitoria != null)
                telaVitoria.SetActive(true);

            
            Time.timeScale = 0f;
        }
    }

    public void TelaDeDerrota()
    {
        // 1. Verifica se a referência é válida E se a vida <= 0
        if (VidaDoPlayerScript != null && VidaDoPlayerScript.VidaatualDoPlayer <= 0)
        {
            
            if (Time.timeScale == 0f) return;

            // 2. Mostra a tela de derrota tlg
            if (telaDerrota != null)
            {
                telaDerrota.SetActive(true);
            }

            // 3. PAUSA O JOGO na hora da play
            Time.timeScale = 0f;
        }
    }
}