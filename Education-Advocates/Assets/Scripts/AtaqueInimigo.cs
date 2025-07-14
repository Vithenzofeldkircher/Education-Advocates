using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class AtaqueInimigo : MonoBehaviour
{
    private float horizontal;
    private float vertical;

    public float speed;
    public Transform target;
    public GameObject bullet;

    Rigidbody2D body;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        body.linearVelocity = new Vector2(horizontal, vertical) * speed;

        while (target != null)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
