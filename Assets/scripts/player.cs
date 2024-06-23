using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Public variables accessible in the Unity Inspector
    public float jumpForce = 8f;
    public float gravity = 9.81f * 2f;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public int maxHealth = 100;
    public HealthBar healthBar;
    public float moveSpeed = 5f;

    // Private variables for internal use
    private Vector3 direction;
    private int currentHealth;
    private bool isGameOver;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        isGameOver = false;
        Debug.Log("Player initialized with health: " + currentHealth); // Log initial health
    }

    private void OnEnable()
    {
        direction = Vector3.zero;
    }

    private void Update()
    {
        if (isGameOver)
        {
            return; // Stop updating if the game is over
        }

        // Handle jumping
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        // Handle shooting
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot(Vector2.right); // Assuming the player shoots to the right
        }

        // Handle movement
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);
    }

    void Shoot(Vector2 direction)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<DinoBullet>().SetDirection(direction);
    }

    void RestoreHealth()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth = Mathf.Min(currentHealth + 1, maxHealth); // Ensure health doesn't exceed maxHealth
            healthBar.SetHealth(currentHealth);
            Debug.Log("Health restored to: " + currentHealth); // Log health restoration
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered by: " + other.gameObject.name); // Log what triggered the collision
        if (other.CompareTag("BirdBullet") || other.CompareTag("Bird"))
        {
            TakeDamage(20); // Assuming 20 is the damage taken from a bird bullet
        }
        else if (other.CompareTag("obstacle"))
        {
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        Debug.Log("Took damage: " + damage + ", Current health: " + currentHealth); // Log damage and current health
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isGameOver = true;
        Debug.Log("Player died"); // Log player death
        GameManager.Instance.GameOver(); // Call the Game Over method in the GameManager
    }

    public void Restart()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
        isGameOver = false;
        Debug.Log("Player health restored to: " + currentHealth); // Log health restoration
    }
}
