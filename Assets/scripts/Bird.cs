using UnityEngine;

public class Bird : MonoBehaviour
{
    public int health = 20;

    public GameObject birdBulletPrefab;
    public Transform firePoint;
    public float fireInterval = 2f;
    private float fireTimer;

    private void Start()
    {
        fireTimer = fireInterval;
    }

    private void Update()
    {
        fireTimer -= Time.deltaTime;
        if (fireTimer <= 0f)
        {
            Shoot();
            fireTimer = fireInterval;
        }
    }

    void Shoot()
    {
        GameObject birdBullet = Instantiate(birdBulletPrefab, firePoint.position, firePoint.rotation);
        BirdBullet bulletScript = birdBullet.GetComponent<BirdBullet>();
        bulletScript.SetTarget(FindObjectOfType<Player>().transform);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Bird took damage: " + damage + ", Current health: " + health);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
