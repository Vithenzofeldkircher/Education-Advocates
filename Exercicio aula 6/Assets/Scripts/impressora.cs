using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class impressora : MonoBehaviour
{

    [SerializeField] TMPro.TMP_InputField inputnumero;

    public void LerEContar()
    {
        if (!int.TryParse(inputnumero.text, out int numero) || numero < 1)
        {
            Debug.Log("Digite um número inteiro maior que zero.");
            return;
        }

        for (int i = 1; i <= numero; i++)
        {
            // Cria uma linha com 'i' repetido i vezes, separado por vírgula ou seja "3, 3, 3" tudo no debug.loog
            Debug.Log(string.Join(", ", Enumerable.Repeat(i.ToString(), i)));
        }
    }
}


