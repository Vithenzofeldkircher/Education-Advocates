
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
            return;

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
                    dialogueText.text = "";
                    nomeText.text = "";
                    canAdvance = false;

                    // uando terminr, avisa o GameManager
                    if (GameManeger.instance != null)
                        GameManeger.instance.RetomarJogoAposDialogo();
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
}
