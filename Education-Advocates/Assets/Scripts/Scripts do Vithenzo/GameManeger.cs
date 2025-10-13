using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManeger : MonoBehaviour
{
    public int SaberAtual;
    public int pontosParaVitoria = 150;

    public static GameManeger instance;

    [SerializeField] TMP_Text TextodeSaberAtual;
    public GameObject telaVitoria;
    public GameObject telaDerrota;

    // Variável para a referência do script de vida do player
    private VidaDoPlayer VidaatualDoPlayer;

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

            VidaatualDoPlayer = playerObject.GetComponent<VidaDoPlayer>();
        }

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
        // Verifica se a referência é válida E se a vida <= 0
        if (VidaatualDoPlayer != null && VidaatualDoPlayer.VidaatualDoPlayer <= 0)
        {
            
            if (Time.timeScale == 0f) return;

            // Mostra a tela de derrota
            if (telaDerrota != null)
            {
                telaDerrota.SetActive(true);
            }

            Time.timeScale = 0f;
        }
    }
}