using UnityEngine;

public class TirodoPlayer : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Faz a bala se mover para a direita
            rb.linearVelocity = new Vector2(bulletSpeed, 0f);
        }
    }
}
