using UnityEngine;

public class DirecaoTiro : MonoBehaviour
{
    public float speed = 10f;
    public Vector2 direction;

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
    }

    void Update()
    {
        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }
}