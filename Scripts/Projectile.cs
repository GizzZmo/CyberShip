using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 5f;
    public int scoreValue = 10;

    void Start()
    {
        // Destroy projectile after lifetime to prevent memory leaks
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Move projectile forward
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if projectile hits an enemy
        if (other.CompareTag("Enemy"))
        {
            // Add score for destroying enemy
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddScore(scoreValue);
            }
            
            // Destroy enemy
            Destroy(other.gameObject);
            // Destroy projectile
            Destroy(gameObject);
        }
        // Destroy projectile if it hits any other collider
        else if (!other.CompareTag("Player") && !other.CompareTag("PlayerProjectile"))
        {
            Destroy(gameObject);
        }
    }
}