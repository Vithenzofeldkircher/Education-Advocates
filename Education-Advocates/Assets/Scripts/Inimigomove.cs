using UnityEngine;

public class Inimigomove : MonoBehaviour
{
    public float speed = 2f; // Velocidade de movimento
    public Vector2 moveAreaMin = new Vector2(-8, -4); // Limite inferior esquerdo
    public Vector2 moveAreaMax = new Vector2(8, 4);   // Limite superior direito
    public float waitTime = 1f; // Tempo de espera entre os movimentos

    private Vector2 targetPosition;
    private float waitTimer = 0f;

    void Start()
    {
        PickNewTarget();
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, targetPosition);

        if (distance < 0.1f)
        {
            waitTimer += Time.deltaTime;

            if (waitTimer >= waitTime)
            {
                PickNewTarget();
                waitTimer = 0f;
            }
        }
        else
        {
            MoveToTarget();
        }
    }

    void PickNewTarget()
    {
        float x = Random.Range(moveAreaMin.x, moveAreaMax.x);
        float y = Random.Range(moveAreaMin.y, moveAreaMax.y);
        targetPosition = new Vector2(x, y);
    }

    void MoveToTarget()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            targetPosition,
            speed * Time.deltaTime
        );
    }

    // Mostrar a área no editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Vector2 center = (moveAreaMin + moveAreaMax) / 2f;
        Vector2 size = moveAreaMax - moveAreaMin;
        Gizmos.DrawWireCube(center, size);
    }
}