using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DialogoSistema : MonoBehaviour
{
    [Header("Referências")]
    public DialogueData dialogueData;
    public TMP_Text dialogueText;
    public TMP_Text nomeText;
    public float typingSpeed = 0.03f;

    [Header("Configurações")]
    public bool mudaCenaAoTerminar = false;
    public string nextSceneName = "";

    int currentLine = 0;
    bool isTyping = false;
    public bool canAdvance = true; // tornamos público para debug (se quiser)

    void Start()
    {
        // NÃO iniciar diálogo automaticamente aqui — será feito por IniciarDialogo()
    }

    void Update()
    {
        if (!canAdvance)
            return;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (isTyping)
            {
                // completa a linha imediatamente
                StopAllCoroutines();
                if (dialogueData != null && currentLine < dialogueData.falas.Count)
                    dialogueText.text = dialogueData.falas[currentLine].texto;
                isTyping = false;
            }
            else
            {
                currentLine++;
                if (dialogueData != null && currentLine < dialogueData.falas.Count)
                {
                    MostrarFalaAtual();
                }
                else
                {
                    EncerrarDialogo();
                }
            }
        }

        // opcional: trocar cena no fim com tecla F
        if (!canAdvance && mudaCenaAoTerminar && Input.GetKeyDown(KeyCode.F))
        {
            TrocarCena();
        }
    }

    IEnumerator TypeLine(string line)
    {
        isTyping = true;
        dialogueText.text = "";

        for (int i = 0; i < line.Length; i++)
        {
            dialogueText.text += line[i];
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    void MostrarFalaAtual()
    {
        if (dialogueData == null || dialogueData.falas == null || dialogueData.falas.Count == 0)
            return;

        if (currentLine < 0 || currentLine >= dialogueData.falas.Count)
            return;

        var falaAtual = dialogueData.falas[currentLine];
        nomeText.text = falaAtual.nomePersonagem;
        // garante que qualquer typing em andamento seja parado antes de iniciar outro
        StopAllCoroutines();
        StartCoroutine(TypeLine(falaAtual.texto));
    }

    public void IniciarDialogo()
    {
        if (dialogueData == null || dialogueData.falas == null || dialogueData.falas.Count == 0)
        {
            Debug.LogWarning("[DialogoSistema] DialogueData vazio ao iniciar.");
            return;
        }

        currentLine = 0;
        canAdvance = true;
        // garante que o GameObject esteja ativo antes de iniciar
        if (!gameObject.activeSelf)
            gameObject.SetActive(true);

        // Para evitar que coroutines antigas continuem, limpa tudo
        StopAllCoroutines();
        MostrarFalaAtual();
    }

    void TrocarCena()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
            SceneManager.LoadScene(nextSceneName);
        else
            Debug.LogWarning("[DialogoSistema] nextSceneName vazio.");
    }

    public void EncerrarDialogo()
    {
        // evita múltiplas execuções
        if (!canAdvance && !gameObject.activeSelf) return;

        dialogueText.text = "";
        nomeText.text = "";
        canAdvance = false;

        if (mudaCenaAoTerminar)
        {
            Debug.Log("[DialogoSistema] Fim do diálogo aguardando tecla F para trocar de cena.");
        }
        else
        {
            if (GameManeger.instance != null)
            {
                Debug.Log("[DialogoSistema] Fim do diálogo, avisando GameManager.");
                GameManeger.instance.RetomarJogoAposDialogo();
            }

            // garante desativação do painel (fechamento do diálogo)
            if (gameObject.activeSelf)
                gameObject.SetActive(false);
        }
    }
}
