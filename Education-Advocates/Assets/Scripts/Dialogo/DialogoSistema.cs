using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class DialogoSistema : MonoBehaviour
{

    [Header("Referências")]
    public DialogueData dialogueData;     // arraste seu DialogueData pra ca
    public TMP_Text dialogueText;         //  o TextMeshPro da UI
    public float typingSpeed = 0.03f;     // velocidade da digitação aqiu

    int currentLine = 0;
    bool isTyping = false;
    bool canAdvance = true;

    void Start()
    {
        if (dialogueData == null || dialogueData.falas.Count == 0)
        {
            Debug.LogError("DialogueData não configurado ou vazi");
            return;
        }

        dialogueText.text = "";
        StartCoroutine(TypeLine(dialogueData.falas[currentLine]));
    }

    void Update()
    {
        if (!canAdvance) return;

        // Avança o texto com Enter
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (isTyping)
            {
                // pula digitação e mostra texto completo
                StopAllCoroutines();
                dialogueText.text = dialogueData.falas[currentLine];
                isTyping = false;
            }
            else
            {
                // próxima fala
                currentLine++;
                if (currentLine < dialogueData.falas.Count)
                {
                    StartCoroutine(TypeLine(dialogueData.falas[currentLine]));
                }
                else
                {
                    dialogueText.text = "";
                    canAdvance = false; // diálogo acabou
                }
            }
        }

        // Troca de cena com F
        if (Input.GetKeyDown(KeyCode.F))
        {
            TrocarCena();
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

    void TrocarCena()
    {
        // Aqui você define a próxima cena
        string cenaAtual = SceneManager.GetActiveScene().name;

    }
}
