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
    public bool mudaCenaAoTerminar = false; // define se troca de cena ou não
    public string nextSceneName = "";       // nome da cena para mudaasred

    int currentLine = 0;
    bool isTyping = false;
    bool canAdvance = true;

    void Start()
    {
        if (dialogueData == null || dialogueData.falas.Count == 0)
        {
            Debug.LogError("DialogueData não configurado ou vazio");
            return;
        }

        MostrarFalaAtual();
    }

    void Update()
    {
        if (!canAdvance)
        {
            // Se deve mudar de cena no final
            if (mudaCenaAoTerminar && Input.GetKeyDown(KeyCode.F))
            {
                TrocarCena();
            }
            return;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (isTyping)
            {
                StopAllCoroutines();
                dialogueText.text = dialogueData.falas[currentLine].texto;
                isTyping = false;
            }
            else
            {
                currentLine++;
                if (currentLine < dialogueData.falas.Count)
                {
                    MostrarFalaAtual();
                }
                else
                {
                    EncerrarDialogo();
                }
            }
        }
    }

    IEnumerator TypeLine(string line)
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char c in line)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    void MostrarFalaAtual()
    {
        if (currentLine < 0 || currentLine >= dialogueData.falas.Count)
            return;

        var falaAtual = dialogueData.falas[currentLine];
        nomeText.text = falaAtual.nomePersonagem;
        dialogueText.text = "";
        StartCoroutine(TypeLine(falaAtual.texto));
    }

    void TrocarCena()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            Debug.Log("Carregando próxima cena: " + nextSceneName);
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogWarning("Nome da próxima cena não configurado.");
        }
    }

    void EncerrarDialogo()
    {
        dialogueText.text = "";
        nomeText.text = "";
        canAdvance = false;

        // ✅ Se deve mudar de cena no final
        if (mudaCenaAoTerminar)
        {
            Debug.Log("Fim do diálogo — aguardando tecla F para trocar de cena.");
        }
        else
        {
            // ✅ Se for dentro do jogo, retoma o spawn dos inimigos
            if (GameManeger.instance != null)
            {
                Debug.Log("Fim do diálogo — retomando jogo normalmente.");
                GameManeger.instance.RetomarJogoAposDialogo();
            }

            // Desativa o painel de diálogo (já é feito no GameManeger)
            gameObject.SetActive(false);
        }
    }
}
