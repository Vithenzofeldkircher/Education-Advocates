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
    public void TrocaDeCenaStart()
    {
        SceneManager.LoadScene("Start");
    }
    public void TrocaDeCenaEscola()
    {
        SceneManager.LoadScene("escola");
    }

    public void TrocaDeCenaRua()
    {
        SceneManager.LoadScene("Rua");
    }

    public void TrocaDeCenaQuarto()
    {
        SceneManager.LoadScene("Quarto");
    }

    public void TrocaDeCenaMesa()
    {
        SceneManager.LoadScene("Mesa");
    }

    public void TrocaDeCenaGame()
    {
        SceneManager.LoadScene("Vithenzo");
    }
    
    public void TrocaDeCenaFim()
    {
        SceneManager.LoadScene("Fim");
    }

    public void TrocaDeCenaCreditos()
    {
        SceneManager.LoadScene("Créditos");
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Sair()
    {
        Application.Quit();
    }
}
