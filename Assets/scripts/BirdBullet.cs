using UnityEngine;

public class BirdBullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 20;

    private Vector2 targetDirection;

    public void SetTarget(Transform target)
    {
        targetDirection = (target.position - transform.position).normalized;
        GetComponent<Rigidbody2D>().velocity = targetDirection * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log("Bird bullet hit: " + hitInfo.name); // Log what the bullet hit

        Player dino = hitInfo.GetComponent<Player>();
        if (dino != null)
        {
            dino.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
