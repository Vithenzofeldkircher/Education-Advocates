using System.Collections;
using UnityEngine;

public class ScriptDialogo : MonoBehaviour
{
    public float typeDelay = 0.05f;
    public TMPro.TextMeshProUGUI textObject;

    public string fulltext;
    void Start()
    {
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        textObject.text = fulltext;
        textObject.maxVisibleCharacters = 0;
        for(int i = 0; i <= textObject.text.Length; i++)
        {
            textObject.maxVisibleCharacters = i;
            yield return new WaitForSeconds(typeDelay);
        }
    }

}
