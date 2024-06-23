using UnityEngine;

public class DinoBullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 20;

    private Vector2 direction;

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log("Dino bullet hit: " + hitInfo.name); // Log what the bullet hit

        Bird bird = hitInfo.GetComponent<Bird>();
        if (bird != null)
        {
            bird.TakeDamage(damage); // Assuming Bird has a TakeDamage method
            Destroy(gameObject);
        }
    }
}
