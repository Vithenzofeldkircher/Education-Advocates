using TMPro;
using UnityEngine;

public class ScriptNome : MonoBehaviour
{
    TextMeshProUGUI nameText;

    public void SetName(string name)
    { 
        nameText.text = name; 
    }
}
