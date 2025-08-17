using UnityEngine;
using Unity.UI;
using UnityEngine.UI;
public class VidaDoPlayer : MonoBehaviour
{
    public int VidaMaximadoPlayer;

    public int VidaatualDoPlayer;

    public Slider BarradeVidaDoplayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        VidaatualDoPlayer = VidaMaximadoPlayer;
        BarradeVidaDoplayer.maxValue = VidaMaximadoPlayer;
        BarradeVidaDoplayer.value = VidaatualDoPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DanoAoPlayer(int DanoParaReceber)
    {
        VidaatualDoPlayer -= DanoParaReceber;
        BarradeVidaDoplayer.value = VidaatualDoPlayer;
        if (VidaatualDoPlayer <= 0)
        {
            Debug.Log("game over");
        }
    }
}
