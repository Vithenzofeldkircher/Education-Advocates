using UnityEngine;

public class VidaDoPlayer : MonoBehaviour
{
    public int VidaMaximadoPlayer;

    public int VidaatualDoPlayer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        VidaatualDoPlayer = VidaMaximadoPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DanoAoPlayer(int DanoParaReceber)
    {
        VidaatualDoPlayer -= DanoParaReceber;

        if(VidaatualDoPlayer <= 0)
        {
            Debug.Log("game over");
        }
    }
}
