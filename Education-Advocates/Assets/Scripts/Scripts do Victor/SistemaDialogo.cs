using System;
using TMPro;
using UnityEngine;

public enum STATE
{
    DISABLED,
    WAITING,
    TYPING
}

public class SistemaDialogo : MonoBehaviour
{
    public DialogueData dialogueData;

    bool dialogoIniciado = false;
    int currentText = 0;
    bool finished = false;

    ScriptDialogo typeText;
    DialogueUI dialogueUI;
    GameManeger GameManeger;

    STATE state;

    void Awake()
    {
        typeText = FindAnyObjectByType<ScriptDialogo>();
        dialogueUI = FindAnyObjectByType<DialogueUI>();
        GameManeger = GameManeger.instance; // acesso ao GameManeger

        typeText.TypeFinished = OnTypeFinished;
    }

    void Start()
    {
        state = STATE.DISABLED;
    }

    void Update()
    {
        if (state == STATE.DISABLED) return;

        switch (state)
        {
            case STATE.WAITING:
                Waiting();
                break;
            case STATE.TYPING:
                Typing();
                break;
        }

        // Teste: tecla S aumenta o saber
        if (Input.GetKeyDown(KeyCode.S))
        {
            GameManeger.AumentarSaber(100);
        }

        // Inicia o diálogo quando alcançar 700 de saber
        if (!dialogoIniciado && GameManeger.SaberAtual >= 40)
        {
            dialogoIniciado = true;
            state = STATE.WAITING;
            Next();
        }
    }

    public void Next()
    {
        if (currentText == 0)
        {
            dialogueUI.Enable();
        }

        dialogueUI.SetName(dialogueData.talkScript[currentText].name);

        typeText.fullText = dialogueData.talkScript[currentText++].text;
        if (currentText == dialogueData.talkScript.Count) finished = true;
        typeText.StartTyping();
        state = STATE.TYPING;
    }

    void OnTypeFinished()
    {
        state = STATE.WAITING;
    }

    void Waiting()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!finished)
            {
                Next();
            }
            else
            {
                dialogueUI.Disable();
                state = STATE.DISABLED;
                currentText = 0;
                finished = false;
            }
        }
    }

    void Typing()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            typeText.Skip();
            state = STATE.WAITING;
        }
    }
}
