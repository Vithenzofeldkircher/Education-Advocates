using System;
using TMPro;
using UnityEngine;
using System.Collections;

public enum STATE
{
    DISABLED,
    WAITING,
    TYPING
}

public class SistemaDialogo : MonoBehaviour
{
    public DialogueData dialogueData;

    int currentText = 0;
    bool finished = false;

    ScriptDialogo typeText;

    STATE state;

    void Awake()
    {
        typeText = FindObjectOfType<ScriptDialogo>();
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
    }

    public void Next()
    {
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
