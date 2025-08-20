using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManeger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TrocaDeCena()
    {
        SceneManager.LoadScene("Start");
    }
    public void TrocaDeCena1()
    {
        SceneManager.LoadScene("escola");
    }

    public void TrocaDeCena2()
    {
        SceneManager.LoadScene("Rua");
    }

    public void TrocaDeCena3()
    {
        SceneManager.LoadScene("Quarto");
    }

    public void TrocaDeCena4()
    {
        SceneManager.LoadScene("Mesa");
    }

    public void TrocaDeCena5()
    {
        SceneManager.LoadScene("Vithenzo");
    }
}
