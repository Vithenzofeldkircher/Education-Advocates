using UnityEngine;

public class SceneMove : MonoBehaviour
{
    public float velocidade = 5f;

    private float limiteSuperiorY;
    private float limiteInferiorY;

    void Start()
    {
        // Calcula limites da câmera
        limiteSuperiorY = Camera.main.transform.position.y + Camera.main.orthographicSize;
        limiteInferiorY = Camera.main.transform.position.y - Camera.main.orthographicSize;

        // Começa em limite inferior (embaixo da tela)
        Vector3 pos = transform.position;
        pos.y = limiteInferiorY;
        transform.position = pos;
    }

    void Update()
    {
        transform.Translate(Vector3.up * velocidade * Time.deltaTime);

        if (transform.position.y > limiteSuperiorY)
        {
            Vector3 pos = transform.position;
            pos.y = limiteInferiorY;
            transform.position = pos;
        }
    }
}
