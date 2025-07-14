using UnityEngine;

public class SceneMove : MonoBehaviour
{
    public float speed = 5f;
    public float screenLimitY = 1920f; // limite vertical

    void Update()
    {
        // Movimento contínuo para cima no eixo Y
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        // Loop infinito vertical: reaparece embaixo quando ultrapassa o topo
        if (transform.position.y > screenLimitY)
        {
            transform.position = new Vector3(transform.position.x, -screenLimitY, transform.position.z);
        }
    }
}

